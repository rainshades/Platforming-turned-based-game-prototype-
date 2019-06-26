using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuildHandler : MonoBehaviour
{
    public GameManager gm;
    public Party Party;
    public Deck Deck;

    public GameObject SpellListPrefab;
    public GameObject SpellListContent;

    public Image PreviewImage;
    public Image[] PartyPreview;


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

        if (Party != null)
        {
            for (int i = 0; i < Party.PartyMembers.Count; i++)
            {
                if(Party.PartyMembers[i] != null)
                PartyPreview[i].sprite = Party.PartyMembers[i].artwork;
            }
        }
    }

    public void addToParty(Monster mon)
    {
        if(Party.PartyMembers.Count < 3) Party.PartyMembers.Add(mon);
    }
    public void addToDeck(SpellCard spell)
    {
        Deck.Add(spell);
        GameObject newObj = Instantiate(SpellListPrefab,SpellListContent.transform);
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
    }

    public void LoadDeck(string DeckName)
    {

    }

    public void saveParty()
    {
        FileStream file = File.Create("Assets/Parties/Party1.txt");
        string json = JsonUtility.ToJson(Party);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, json);
        file.Close();
    }


    public void LoadParty(string PartyName)
    {
        FileStream file = File.Open("Assets/Parties/Party1.txt", FileMode.Open);

        Party = JsonUtility.FromJson<Party>(PartyName);

    }
}
