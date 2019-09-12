using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class Player : MonoBehaviour
    {
        public int HumanHealth = 0;
        public float OverWorldManaPool = 0;
        public int AttackDamage;

        GameManager gm;
        public Party p;
        public Deck d;

        List<Monster> PotentialPartyMembers = new List<Monster>();
        List<SpellCard> CardInventory = new List<SpellCard>();

        void Awake()
        {
            gm = FindObjectOfType<GameManager>();

            if (gm == null)
            {
                GameObject go = new GameObject("Game Manager");
                gm = go.AddComponent<GameManager>();
            }

            gm.currentParty = p;
            gm.currentDeck = d;
        }

        public List<Monster> GetPotentialPartyMembers()
        {
            return PotentialPartyMembers;
        }

        public List<SpellCard> GetCardInventory()
        {
            return CardInventory;
        }
    }
}