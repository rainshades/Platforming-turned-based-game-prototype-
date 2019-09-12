using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class TargetUI : MonoBehaviour
    {
        public BattleManager bm;
        public List<MonsterObject> Monsters;
        [SerializeField]
        List<GameObject> HPList;
        public int numberToCreate;

        public GameObject prefabSprite;
        public Transform TextHealthUI;
        public Font font;

        // Start is called before the first frame update
        void Start()
        {
            HPList = new List<GameObject>();
            bm = FindObjectOfType<BattleManager>();
            Monsters = bm.AllyField;
            Populate();
            PopulateHealth();
        }

        // Update is called once per frame
        void Update()
        {
            //Updates the Health Every Frame
            for (int i = 0; i < HPList.Count; i++)
            {
                HPList[i].GetComponent<Text>().text = "HP: " + Monsters[i].health;
            }
        }

        public void Populate()
        {
            GameObject newObj;

            numberToCreate = Monsters.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                prefabSprite.GetComponent<Image>().sprite = Monsters[i].thisMonster.artwork;
                newObj = Instantiate(prefabSprite, transform);
                //Debug.Log(newObj.name + " has been born");
            }
        }
        public void PopulateHealth()
        {
            numberToCreate = Monsters.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                GameObject newObj = new GameObject();
                newObj.transform.SetParent(TextHealthUI);
                newObj.AddComponent<Text>().text = "HP:" + Monsters[i].health;
                newObj.GetComponent<Text>().font = font;
                newObj.GetComponent<Text>().fontSize = 40;
                HPList.Add(newObj);
                //Debug.Log(newObj.name + " has been born");
            }
        }
    }
}