using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class PopulateMonsterContentBox : MonoBehaviour
    {
		
        [SerializeField]
        List<Monster> FullListOfMonsters = new List<Monster>();
        [SerializeField]
        GameObject DemoGameManager;
        GameManager gm;
        
		public GameObject prefab;
        public int numberToCreate;


        void Awake()
        {

            gm = FindObjectOfType<GameManager>();
            FullListOfMonsters = gm.DemoInventory.MonstersInInventory; // Only for DEMO TODO: REMOVE

        }

        void Start()
        {
            InnitPopulate();
        }

        public void InnitPopulate()
        {
            GameObject newObj;
            numberToCreate = FullListOfMonsters.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                prefab.GetComponent<MonsterListObject>().SetMon(FullListOfMonsters[i]);
                newObj = Instantiate(prefab, transform);
            }
        }
    }
}
