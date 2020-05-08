using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class Populate_Enemy : MonoBehaviour
    {
        public BattleManager Bm;
        public GameObject PrefabSprite;

        void Start()
        {
            Bm = FindObjectOfType<BattleManager>();
        }

        public void Populate( List<MonsterObject> Monsters)
        {
            GameObject newObj;

            int numberToCreate = Monsters.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                PrefabSprite.GetComponent<Image>().sprite = Monsters[i].ThisMonster.artwork;
                PrefabSprite.GetComponent<Select_Enemy>().TargetMon = Monsters[i];
                newObj = Instantiate(PrefabSprite, transform);
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

