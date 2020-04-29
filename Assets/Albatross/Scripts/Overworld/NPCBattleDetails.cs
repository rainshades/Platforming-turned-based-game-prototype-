using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    
    [CreateAssetMenu(fileName = "New Battle Status", menuName = "Battle Details")]
    public class NPCBattleDetails: ScriptableObject
    {
        public Party party;
        public Deck deck;
        public bool isDefeated = false;

    }
}
