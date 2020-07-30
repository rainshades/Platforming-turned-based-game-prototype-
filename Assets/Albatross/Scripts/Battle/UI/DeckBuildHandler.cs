using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used to build and customize Parties and Decks through UI
/// </summary>
namespace Albatross
{
    public class DeckBuildHandler : MonoBehaviour
    {
        public GameManager Gm;
        public Party Party;
        public Deck Deck;
        public GameObject SelectedMonster; //Previews the selected ID
        public GameObject SelectedSpell; //Previews the current Spell 
        public GameObject SpellListPrefab;
        public GameObject SpellListContent;
        public Image PreviewImage;
        public Image SpellPreview;
        public Image[] PartyPreview;
        public Image[] PartyPreview2;

        void Start()
        {
            Gm = FindObjectOfType<GameManager>();
            Party = Gm.currentParty;
            Deck = Gm.currentDeck;
        }

        void Update()
        {
            ///TODO: See if this can be moved from Update as to not be checked for every frame
            for (int i = 0; i < 3; i++)
            {
                if (PartyPreview[i] != null || PartyPreview2[i] != null)
                {
                    PartyPreview[i].sprite = null;
                    PartyPreview2[i].sprite = null;
                }
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

        public void AddToParty(Monster mon)
        {
            if (Party.PartyMembers.Count < 3) Party.PartyMembers.Add(mon);
        }

        public void AddToParty()
        {
            if (Party.PartyMembers.Count < 3)
            {
                Party.PartyMembers.Add(SelectedMonster.GetComponent<MonsterListObject>().Mon);
                Destroy(SelectedMonster);
            }
        }

        public void AddToDeck(SpellCard spell)
        {
            Deck.Add(spell);
            GameObject newObj = Instantiate(SpellListPrefab, SpellListContent.transform);
            newObj.GetComponent<SpellListObject>().UpdatePrefab(spell, spell.name, spell.artwork);
        }

        public void AddToDeck()
        {
            Deck.Add(SelectedSpell.GetComponent<SpellListObject>().Spell);
            GameObject newObj = Instantiate(SpellListPrefab, SpellListContent.transform);
            newObj.GetComponent<SpellListObject>().UpdatePrefab(SelectedSpell.GetComponent<SpellListObject>().Spell,
                SelectedSpell.GetComponent<SpellListObject>().Spell.name, 
                SelectedSpell.GetComponent<SpellListObject>().Spell.artwork);
            Destroy(SelectedSpell);
        }

        public void RemoveFromParty(Monster mon)
        {
            if (Party.PartyMembers.Contains(mon))
            {
                Party.PartyMembers.Remove(mon);
            }
        }
        public void RemoveFromParty(int index)
        {
            Party.PartyMembers.RemoveAt(index);
        }
        public void RemoveFromDeck(int index)
        {
            Deck.Spells.RemoveAt(index);
        }

        public void SetDeck()
        {
            Gm.currentDeck = this.Deck;
            Gm.SetDeck(Deck);
        }
        public void SetParty()
        {
            Gm.currentParty = this.Party;
            Gm.SetParty(Party);
        }

    }
}