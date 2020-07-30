using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the moment to moment parts of the battle
/// </summary>
namespace Albatross
{
    public class BattleManager : MonoBehaviour
    {
        GameManager gm;
        TurnManager tm;
        FieldSpawner fs;

        [SerializeField]
        List<SpellCard> SpellsDisplay = new List<SpellCard>();

        [SerializeField]
        GameObject cardPrefab = null;

        MonsterObject CurrentMonster = null;

        [SerializeField]
        int NPCBATTLENUMBER;

        public List<MonsterObject> AllyField;
        public List<MonsterObject> EnemyField;

        [SerializeField]
        int BraveryReward; 

        void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            tm = GetComponentInChildren<TurnManager>();
            fs = GetComponentInChildren<FieldSpawner>();

            NPCBATTLENUMBER = gm.CurrentNPCNumber;
            BraveryReward = gm.BattleDetailsAt(NPCBATTLENUMBER).BraveryAward;
        }

        public void FightRotation()
        {
            if (!BattleFinish())
            {
                for (int i = 0; i < EnemyField.Count; i++)
                {
                    if (EnemyField[i].health <= 0 && EnemyField[i] != null)
                    {
                        EnemyField.RemoveAt(i);
                    }
                }

                for (int i = 0; i < AllyField.Count; i++)
                {
                    if (AllyField[i].health > 1)
                    {
                        //Percent of Healthbar coincide with Damage taken
                    }
                    if (AllyField[i].health <= 1 && AllyField[i] != null)
                    {
                        AllyField.RemoveAt(i);
                    }
                }
            }
        }

        bool BattleFinish()
        {

            if (AllyField.Count == 0)
            {
                FindObjectOfType<Player>().Bravery += BraveryReward;
                gm.SetBattleResults(true, NPCBATTLENUMBER);
                gm.ToOverworldScene(); //Not Final
            }

            if(EnemyField.Count == 0)
            {
                FindObjectOfType<Player>().Bravery += BraveryReward;
                gm.SetBattleResults(false, NPCBATTLENUMBER);
                gm.ToOverworldScene(); //Will load Overworld Scene
            }

            return false; 

        }
    }
}