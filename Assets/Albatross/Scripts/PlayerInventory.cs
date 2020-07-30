using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player inventory Container
/// </summary>
namespace Albatross
{
    [System.Serializable]
    public class PlayerInventory //Manages Player's inventory of Spells and Possible Party Members
    {
        public List<Monster> MonstersInInventory = new List<Monster>();
        public List<SpellCard> SpellsInInventory = new List<SpellCard>();
    }
}