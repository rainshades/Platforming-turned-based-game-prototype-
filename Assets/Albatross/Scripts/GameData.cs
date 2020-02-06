using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    [System.Serializable]
    public class GameData //Holds GameData to be Serialized 
    {

        //Player Persistant Game Data
        public Vector3 PlayerLocation = Vector3.zero;
        public int HumanHealth = 0;
        public float OverWorldManaPool = 0.0f;

        public Deck currentDeck = null;
        public Party currentParty = null;

        public PlayerInventory inv = null;

        //NPC Persistant Game Data
        public bool[] AreTheyAlive = {true};

        //Script Persistant Game Data
        public Vector3 CameraLocation = Vector3.zero;

    }
}