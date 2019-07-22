using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<SpellCard> spells = new List<SpellCard>();

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
}
