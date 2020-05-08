using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class Player : MonoBehaviour 
	//Contains the player's data
    {
        public int HumanHealth = 5;
        public float OverWorldManaPool = 0;

        List<Monster> PotentialPartyMembers = new List<Monster>();
        List<SpellCard> CardInventory = new List<SpellCard>();

        public int AttackDamage;

        public List<Monster> GetPotentialPartyMembers()
        {
            return PotentialPartyMembers;
        }

        public List<SpellCard> GetCardInventory()
        {
            return CardInventory;
        }

        void Update()
        {
            if (HumanHealth < 1)
            {
                Respawn();
            }
        }

        void Respawn()
        {
            transform.position = GetComponent<PlayerController>().getRespawnPoint();
        }
    }
}