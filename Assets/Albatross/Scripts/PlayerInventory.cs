using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    [System.Serializable]
    public class PlayerInventory //Manages Player's inventory of Spells and Possible Party Members
    {
        public List<Monster> MonstersInInventory = new List<Monster>();
        public List<SpellCard> SpellsInInventory = new List<SpellCard>();


        public void AddToMonsters(Monster mon)
        {
           
        }

        public void AddToSpells(SpellCard spell)
        {

        }

        public void RemoveFromMonsters(Monster mon)
        {

        }

        public void RemoveFromSpells(SpellCard spell)
        {

        }
    }
}