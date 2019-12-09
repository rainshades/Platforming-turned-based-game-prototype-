using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class FieldSpawner : MonoBehaviour
    {
        GameManager gm;
        TurnManager tm;
        BattleManager bm;

        [SerializeField]
        Transform[] SpawnPoints = null;
        [SerializeField]
        Transform[] EnemySpawnPoints = null;

        [SerializeField]
        Transform BattleArea;

        [SerializeField]
        GameObject monPrefab = null;
        [SerializeField]
        GameObject enemyMonPrefab = null;

        Party AllyParty = null;
        Party EnemyParty = null;

        public List<MonsterObject> AllyField;
        public List<MonsterObject> EnemyField;


        // Start is called before the first frame update
        void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            tm = FindObjectOfType<TurnManager>();

            AllyParty = gm.currentParty;
            EnemyParty = gm.enemyParty;

            PopulateField();

        }
        
        void PopulateField()
        {
            int numberToCreate = 6;

            for(int i = 0; i <= numberToCreate - 1; i++)
            {
                if(i < 3)//Player's Party
                {
                    if (AllyParty.PartyMembers[i] != null)
                    {
                        monPrefab.GetComponent<MonsterObject>().thisMonster = AllyParty.PartyMembers[i];
                        GameObject go = Instantiate(monPrefab, SpawnPoints[i]);
                        go.GetComponent<MonsterObject>().ownedByPlayer = true;
                        AllyField.Add(go.GetComponent<MonsterObject>());
                        tm.TurnOrder.Add(go.GetComponent<MonsterObject>());
                    }
                }
                else //Enemy's Party
                {
                    if (EnemyParty.PartyMembers[i - 3] != null)
                    {
                        enemyMonPrefab.GetComponent<MonsterObject>().thisMonster = EnemyParty.PartyMembers[i - 3];
                        GameObject go = Instantiate(enemyMonPrefab, EnemySpawnPoints[i - 3]);
                        EnemyField.Add(go.GetComponent<MonsterObject>());
                        tm.TurnOrder.Add(go.GetComponent<MonsterObject>());
                    }

                }
            }
        }


        public void setAllyParty(Party p)
        {
            AllyParty = p;
        }

        public void SetEnemyParty(Party p)
        {
            EnemyParty = p;
        }
    }
}