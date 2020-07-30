using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container for Player 
/// Not Persistant, meant for calls to other MonoBehaviours like GameManager, PlayerController, NPCs etc. 
/// </summary>

namespace Albatross
{
    public class Player : MonoBehaviour 
    {
        public int HumanHealth = 5;
        public float OverWorldManaPool = 100;
        public int AttackDamage;
        public int Bravery; 
        //Bravery is gained from winning battles, lost be being defeated or spent at a library to learn new spells from a spellsinger

    }
}