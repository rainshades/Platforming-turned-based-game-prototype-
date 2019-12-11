/* Project Albatross 
 * Prepared by Eddie Fulton
 * Unpublished/Unfinished
 * Purpose: Holds a group of Spell ScritableObjects
 * Status: Member: Testing 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
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
}