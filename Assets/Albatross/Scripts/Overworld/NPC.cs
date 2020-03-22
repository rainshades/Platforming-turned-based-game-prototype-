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
        public string overworld_dialog;
        public Flowchart flow;
        
        [SerializeField]
        private Animator animator;
        public string[] dialog_options;
        string current_dialog_option = null;


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
            flow.ExecuteBlock("LinaOne");
        }

        public void CycletoBlock(int i)
        {
            current_dialog_option = dialog_options[i]; 
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                ExecuteBlock(current_dialog_option);
            }
        }
    }
}