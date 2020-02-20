/* Project Albatross 
 * Prepared by Eddie Fulton
 * Purpose: The battle state manager: Handles battle phases, transitions them, and established win/loss battle condition 
 * Status: Member: Testing 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        public string PostBattleScene;

        [SerializeField]
        List<SpellCard> SpellsDisplay = new List<SpellCard>();

        [SerializeField]
        GameObject cardPrefab = null;

        MonsterObject CurrentMonster = null;
      
        void Start()
        {
            TargetUI = FindObjectOfType<TargetUI>();

            gm = FindObjectOfType<GameManager>();
            tm = FindObjectOfType<TurnManager>();
            fs = FindObjectOfType<FieldSpawner>();

            AllyField = fs.AllyField;

            EnemyField = fs.EnemyField;
        }

        void Update()
        {

            for(int i = 0; i < EnemyField.Count; i++)
            {
                if(EnemyField[i].health <= 0 && EnemyField[i] != null)
                {
                    EnemyField.RemoveAt(i);
                }               
            }

            for(int i = 0; i < AllyField.Count; i++)
            {
                if (AllyField[i].health > 1)
                {
                 //   TargetUI.GetHPObjects()[i].GetComponent<Text>().text = "HP: " + AllyField[i].health;
                }
                if(AllyField[i].health <= 1 && AllyField[i] != null)
                {
                    TargetUI.GetHPObjects()[i].GetComponent<Text>().text = "HP: " + 0;
                    AllyField.RemoveAt(i);
                }
            }
            
            switch (AllyField.Count)
            {
                case 1:
                    if (AllyField[0].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads the beginning of the Level
                    break;
                case 2:
                    if (AllyField[0].health == 0 && AllyField[1].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }
                    break;
                case 3:
                    if (AllyField[0].health == 0 && AllyField[1].health == 0 && AllyField[2].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }
                    break;
                
            }
            switch (EnemyField.Count)
            {
                case 1:
                    if (EnemyField[0].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }
                    break;
                case 2:
                    if (EnemyField[0].health == 0 && EnemyField[1].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
					}
                    break;
                case 3:
                    if (EnemyField[0].health == 0 && EnemyField[1].health == 0 && EnemyField[2].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads where the player was before the battle, the enemy defeated.
                     //Sets the players party health to the same amount of health they had at the end of the battle
                     //If one of party members died it sets them to 1hp
                    break;
            }
         }
    }
}