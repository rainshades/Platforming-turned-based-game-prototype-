using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class DeckBuildHandler : MonoBehaviour
    {
        public GameManager gm;
        public Party Party;
        public Deck Deck;

        public GameObject selectedMonster;
        public GameObject selectedSpell;

        public GameObject SpellListPrefab;
        public GameObject SpellListContent;

        public Image PreviewImage;
        public Image SpellPreview;
        public Image[] PartyPreview;
        public Image[] PartyPreview2;

        // Start is called before the first frame update
        void Start()
        {
            gm = FindObjectOfType<GameManager>();
            Party = gm.currentParty;
            Deck = gm.currentDeck;
        }

        // Update is called once per frame
        void Update()
        {

            for (int i = 0; i < 3; i++)
            {
                PartyPreview[i].sprite = null;
                PartyPreview2[i].sprite = null;
            }

            if (Party.PartyMembers.Count > 0)
            {
                for (int i = 0; i < Party.PartyMembers.Count; i++)
                {
                    if (Party.PartyMembers[i] != null)
                        PartyPreview[i].sprite = Party.PartyMembers[i].artwork;
                    else
                        PartyPreview[i].sprite = null;
                }
                for (int i = 0; i < Party.PartyMembers.Count; i++)
                {
                    if (Party.PartyMembers[i] != null)
                        PartyPreview2[i].sprite = Party.PartyMembers[i].artwork;
                    else
                        PartyPreview2[i].sprite = null;
                }
            }
        }

        public void addToParty(Monster mon)
        {
            if (Party.PartyMembers.Count < 3) Party.PartyMembers.Add(mon);
        }

        public void addToParty()
        {
            if (Party.PartyMembers.Count < 3)
            {
                Party.PartyMembers.Add(selectedMonster.GetComponent<MonsterListObject>().mon);
                Destroy(selectedMonster);
            }
        }

        public void addToDeck(SpellCard spell)
        {
            Deck.Add(spell);
            GameObject newObj = Instantiate(SpellListPrefab, SpellListContent.transform);
            newObj.GetComponent<SpellListObject>().UpdatePrefab(spell, spell.name, spell.artwork);
        }

        public void addToDeck()
        {
            Deck.Add(selectedSpell.GetComponent<SpellListObject>().spell);
            GameObject newObj = Instantiate(SpellListPrefab, SpellListContent.transform);
            newObj.GetComponent<SpellListObject>().UpdatePrefab(selectedSpell.GetComponent<SpellListObject>().spell,
                selectedSpell.GetComponent<SpellListObject>().spell.name, 
                selectedSpell.GetComponent<SpellListObject>().spell.artwork);
            Destroy(selectedSpell);
        }

        public void removeFromParty(Monster mon)
        {
            if (Party.PartyMembers.Contains(mon))
            {
                Party.PartyMembers.Remove(mon);
            }
        }
        public void removeFromParty(int index)
        {
            Party.PartyMembers.RemoveAt(index);
        }
        public void removeFromDeck(SpellCard spell)
        {

        }

        public void setDeck()
        {
            gm.currentDeck = this.Deck;
            gm.SetDeck(Deck);
        }
        public void setParty()
        {
            gm.currentParty = this.Party;
            gm.SetParty(Party);
        }

        public void saveDeck(string DeckName)
        {
            FileStream file = File.Create(Application.persistentDataPath + "/Deck.json");
            string json = JsonUtility.ToJson(Deck);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, json);
            file.Close();
        }

        public static void LoadDeck(Deck d)
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Deck.json", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string json = (string)bf.Deserialize(file);

            d = JsonUtility.FromJson<Deck>(json);

            file.Close();
        }

        public void saveParty()
        {
            FileStream file = File.Create(Application.persistentDataPath + "/Parties.json");
            string json = JsonUtility.ToJson(Party);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, json);
            file.Close();
                
        }


        public static void LoadParty(Party party)
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Parties.json", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string json = (string)bf.Deserialize(file);

            party = JsonUtility.FromJson<Party>(json);

            file.Close();

        }
    }
}