/* Project Albatross 
 * Prepared by Eddie Fulton
 * Purpose: The battle state manager: Handles battle phases, transitions them, and established win/loss battle condition 
 * Status: Member: Testing 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Albatross
{
    public class BattleManager : MonoBehaviour
    {
        GameManager gm;
        TurnManager tm;
        TargetUI TargetUI;
        FieldSpawner fs;

        public List<MonsterObject> AllyField;
        public List<MonsterObject> EnemyField;

        [SerializeField]
        List<SpellCard> SpellsDisplay = new List<SpellCard>();

        [SerializeField]
        GameObject cardPrefab = null;

        MonsterObject CurrentMonster = null;

        [SerializeField]
        int NPCBATTLENUMBER; 
      
        void Awake()
        {
            TargetUI = FindObjectOfType<TargetUI>();

            gm = FindObjectOfType<GameManager>();
            tm = GetComponentInChildren<TurnManager>();
            fs = GetComponentInChildren<FieldSpawner>();

            NPCBATTLENUMBER = gm.currentNPCNumber;
        }


        void Update()
        {
            for(int i = 0; i < EnemyField.Count; i++)
            {
                if(EnemyField[i].health <= 0 && EnemyField[i] != null)
                {
                    Debug.Log("Enemy " + i + " Down");

                    EnemyField.RemoveAt(i);
                }               
            }

            for(int i = 0; i < AllyField.Count; i++)
            {
                if (AllyField[i].health > 1)
                {
                    //Percent of Healthbar coincide with Damage taken
                }
                if(AllyField[i].health <= 1 && AllyField[i] != null)
                {
                    TargetUI.GetHPObjects()[i].GetComponent<Text>().text = "HP: " + 0;
                    AllyField.RemoveAt(i);
                }
            }
            BattleFinish();
         }

        bool BattleFinish()
        {
            if(AllyField.Count == 0)
            {
                gm.SetBattleResults(true, NPCBATTLENUMBER);
                gm.ToOverworldScene();
            }

            if(EnemyField.Count == 0)
            {
                gm.SetBattleResults(false, NPCBATTLENUMBER);
                gm.ToOverworldScene();
            }

            return false; 

        }
    }
}