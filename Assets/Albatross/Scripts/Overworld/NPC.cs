using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class NPC : MonoBehaviour //A non playerable character that contains dialog options
    {
        public enum NPCTYPE { Neutral, Hostile, Friendly }
        [SerializeField]
        protected NPCTYPE thisNPC;
        NPCBattleDetails NpcPartyAndDeck; 
        public string overworld_dialog;

        public NPCTYPE GetNpcType()
        {
            return thisNPC;
        }

    }
}