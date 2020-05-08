using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Holds the battle party and spells of a specific enemy
namespace Albatross
{   
    [CreateAssetMenu(fileName = "New Battle Status", menuName = "Battle Details")]
    public class NPCBattleDetails: ScriptableObject
    {
        public Party Party = new Party();
        public Deck Deck = new Deck();
        public bool IsDefeated = false;
    }
}
