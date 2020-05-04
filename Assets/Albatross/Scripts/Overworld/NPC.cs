using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;

namespace Albatross
{
    public class NPC : PhysicsObject //A non playerable character that contains dialog options
    {
        public enum NPCTYPE { Neutral, Hostile, Friendly }
        
        [SerializeField]
        protected NPCTYPE thisNPC;
        public string[] overworld_dialog;
        int current_overworld_dialog_iterator = 0;
        private Flowchart flow;
        
        [SerializeField]
        private Animator animator;
        string current_dialog_option = "";

        public string VictoryDialog;
        public string InnitDialog;
        public string DefeatDialog; 

        [SerializeField]
        bool isBattleNPC = false; 
        [SerializeField]
        int NPCBattleDataNumber; 

        private void Awake()
        {
            flow = FindObjectOfType<Flowchart>();
        }

        protected override void ComputeVelocity()
        {
            animator.SetBool("Grounded", grounded);

        }

        public NPCTYPE GetNpcType()
        {
            return thisNPC;
        }

        public void ExecuteBlock(string BlockName)
        {
            flow.ExecuteBlock(BlockName);
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {

                PlayerController Player = col.GetComponent<PlayerController>();
                GameManager gm = FindObjectOfType<GameManager>();
                gm.currentNPCNumber = NPCBattleDataNumber;
                NPCBattleDetails BattleDetails = gm.BattleDetailsAt(NPCBattleDataNumber);
                gm.setCurrentBattleDetails(BattleDetails);


                if (isAbleToBattle())
                {
                    Player.maxSpeed = 0;
                }
                ExecuteBlock(current_dialog_option);
                
            }
        }

        private bool isAbleToBattle()
        {
            if (isBattleNPC)
            {
                GameManager gm = FindObjectOfType<GameManager>();
                if(gm.currentParty.PartyMembers.Count >= 1)
                {
                    if (gm.CanBattle(NPCBattleDataNumber))
                    {
                        current_dialog_option = InnitDialog;
                        return true; 
                    }
                    else current_dialog_option = VictoryDialog;
                    return false;
                }
            }
            return false; 
        }
    }
}