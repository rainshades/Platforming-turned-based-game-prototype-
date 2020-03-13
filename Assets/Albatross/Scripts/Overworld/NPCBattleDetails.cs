using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class NPCBattleDetails : PhysicsObject
    {

        public Party party;
        public Deck deck;
        public Animator animator;
        public bool isAlive;
        public int NPC_identifier; 

        void Awake()
        {
            if (!isAlive)
            {
                GameObject.Destroy(gameObject);
            }
        }


        void OnCollisionEnter2D(Collision2D collision2D)
        {
            if(collision2D.gameObject.tag == "Player")
            {
                GameManager Gm = FindObjectOfType<GameManager>();
                Gm.enemyParty = party;
                Gm.enemyDeck = deck;
            }
        }

        protected override void ComputeVelocity()
        {
            animator.SetBool("Grounded", grounded);
        }
    }
}
