using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class NPCBattleDetails: MonoBehaviour
    {

        public Party party;
        public Deck deck;
        public bool isAlive = true;
        
        void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (isAlive)
            {
                if (collision2D.gameObject.tag == "Player")
                {
                    GameManager Gm = FindObjectOfType<GameManager>();
                    Gm.enemyParty = party;
                    Gm.enemyDeck = deck;
                }
            }
        }
    }
}
