using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Field and Deck", menuName = "Field and Deck Storage")]
public class DeckAndField : ScriptableObject
{
    [SerializeField]
    List<Monster> Party = new List<Monster>();
    [SerializeField]
    List<SpellCard> Deck = new List<SpellCard>();
    [SerializeField]
    int MaxSpells = 0;

    public DeckAndField()
    {

    }

    public List<Monster> GetParty()
    {
        return Party;
    }
    public List<SpellCard> GetDeck()
    {
        return Deck;
    }

    public void addToParty(Monster mon)
    {
        if (Party.Count < 3) {
            Party.Add(mon);
        }
    }

    public void removeFromParty(int index)
    {
        Party.RemoveAt(index);
    }

    public void addToDeck(SpellCard spell)
    {
        if(Deck.Count < MaxSpells)
        {
            Deck.Add(spell);
        }
    }

    public void removeFromDeck(int index)
    {
        Deck.RemoveAt(index);
    }

}
