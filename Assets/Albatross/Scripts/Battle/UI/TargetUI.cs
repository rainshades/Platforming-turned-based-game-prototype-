using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class TargetUI : MonoBehaviour
    {
        FieldSpawner fs;
        GameManager gm;
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
            gm = FindObjectOfType<GameManager>();
            HPList = new List<GameObject>();
            fs = FindObjectOfType<FieldSpawner>();
            Monsters = fs.AllyField;
            Populate();
            PopulateHealth();
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
        public List<GameObject> GetHPObjects()
        {
            return HPList;
        }
    }
}