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
        public void addToDeck(SpellCard spell)
        {
            Deck.Add(spell);
            GameObject newObj = Instantiate(SpellListPrefab, SpellListContent.transform);
            newObj.GetComponent<SpellListObject>().UpdatePrefab(spell, spell.name, spell.artwork);
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
        }
        public void setParty()
        {
            gm.currentParty = this.Party;
        }

        public void saveDeck(string DeckName)
        {
            FileStream file = File.Create(Application.persistentDataPath + "/Deck");
            string json = JsonUtility.ToJson(Deck);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, json);
            file.Close();
        }

        public void LoadDeck(string DeckName)
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Deck", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string json = (string)bf.Deserialize(file);
            Debug.Log(json);

            Deck = JsonUtility.FromJson<Deck>(json);

            file.Close();
        }

        public void saveParty()
        {
            FileStream file = File.Create(Application.persistentDataPath + "/Parties");
            string json = JsonUtility.ToJson(Party);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, json);
            file.Close();
                
        }


        public void LoadParty(string PartyName)
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Parties", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string json = (string)bf.Deserialize(file);
            Debug.Log(json);

            Party = JsonUtility.FromJson<Party>(json);

            file.Close();

        }
    }
}