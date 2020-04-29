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

        
        void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            tm = FindObjectOfType<TurnManager>();
            bm = FindObjectOfType<BattleManager>();

            AllyParty = gm.currentParty;
            EnemyParty = gm.getEnemyParty();

            PopulateField();

            bm.AllyField = this.AllyField;
            bm.EnemyField = this.EnemyField; 
        }

        void UnhidPartySpace()
        {
            if(AllyField.Count == 2)
            {
                SpawnPoints[1].gameObject.SetActive(true);
            }
            if(AllyField.Count == 3)
            {
                SpawnPoints[1].gameObject.SetActive(true);
                SpawnPoints[2].gameObject.SetActive(true);
            }
            if(EnemyField.Count == 2)
            {
                EnemySpawnPoints[1].gameObject.SetActive(true);
            }
            if(EnemyField.Count == 3)
            {
                EnemySpawnPoints[1].gameObject.SetActive(true);
                EnemySpawnPoints[2].gameObject.SetActive(true);
            }
        }
        
        void PopulateField()
        {
            UnhidPartySpace();

            int AlliesToCreate = AllyParty.PartyMembers.Count;
            int EnemiesToCreate = EnemyParty.PartyMembers.Count;

            for (int i = 0; i < AlliesToCreate; i++)
            {
                monPrefab.GetComponent<MonsterObject>().thisMonster = AllyParty.PartyMembers[i];
                GameObject go = Instantiate(monPrefab, SpawnPoints[i]);
                go.GetComponent<MonsterObject>().ownedByPlayer = true;
                go.SetActive(true);
                AllyField.Add(go.GetComponent<MonsterObject>());
                tm.TurnOrder.Add(go.GetComponent<MonsterObject>());
            }

            for (int i = 0; i < EnemiesToCreate; i++)
            {
                enemyMonPrefab.GetComponent<MonsterObject>().thisMonster = EnemyParty.PartyMembers[i];
                GameObject go = Instantiate(enemyMonPrefab, EnemySpawnPoints[i]);
                EnemyField.Add(go.GetComponent<MonsterObject>());
                tm.TurnOrder.Add(go.GetComponent<MonsterObject>());
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