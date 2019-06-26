using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public List<SpellCard> spells = new List<SpellCard>();
    public List<SpellCard> Hand = new List<SpellCard>();

    public string name;

    public void Add(SpellCard sc)
    {
        spells.Add(sc);
    }

    public Deck()
    {
        spells = new List<SpellCard>();
        name = "Deck";
    }

    public Deck(string name)
    {
        spells = new List<SpellCard>();
        this.name = name;
    }


    public void DrawCard()
    {
        if (spells.Count > 0)
        {
            Hand.Add(spells[0]);
            spells.RemoveAt(0);
        }
    }
}
