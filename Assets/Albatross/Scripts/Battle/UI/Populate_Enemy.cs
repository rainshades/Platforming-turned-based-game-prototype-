using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class Populate_Enemy : MonoBehaviour
    {
        public BattleManager bm;
        public List<MonsterObject> Monsters;
        public int numberToCreate;

        public GameObject prefabSprite;
        // Start is called before the first frame update
        void Start()
        {
            bm = FindObjectOfType<BattleManager>();
            Monsters = bm.EnemyField;
            Populate();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Populate()
        {
            GameObject newObj;

            numberToCreate = Monsters.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                prefabSprite.GetComponent<Image>().sprite = Monsters[i].thisMonster.artwork;
                prefabSprite.GetComponent<Select_Enemy>().TargetMon = Monsters[i];
                newObj = Instantiate(prefabSprite, transform);
                //Debug.Log(newObj.name + " has been born");
            }
        }
    }
}

