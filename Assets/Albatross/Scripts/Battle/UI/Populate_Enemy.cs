using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class Populate_Enemy : MonoBehaviour
    {
		//Populates the enemy selectors for an action 
		//and depopulates it so that actions cannot be taken twice
        
		public BattleManager bm;
        public GameObject prefabSprite;
		
        void Start()
        {
            bm = FindObjectOfType<BattleManager>();
        }

        public void Populate( List<MonsterObject> Monsters)
        {
            GameObject newObj;

            int numberToCreate = Monsters.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                prefabSprite.GetComponent<Image>().sprite = Monsters[i].thisMonster.artwork;
                prefabSprite.GetComponent<Select_Enemy>().TargetMon = Monsters[i];
                newObj = Instantiate(prefabSprite, transform);
                //Debug.Log(newObj.name + " has been born");
            }
        }

        public void Depopulate()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}

