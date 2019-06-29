using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateMonsterContentBox : MonoBehaviour
{

    [SerializeField]
    List<Monster> FullListOfMonsters = new List<Monster>();

    public GameObject prefab;

    public int numberToCreate;

    // Start is called before the first frame update
    void Start()
    {
        InnitPopulate();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InnitPopulate()
    {
        GameObject newObj;
        numberToCreate = FullListOfMonsters.Count;

        for(int i = 0; i < numberToCreate; i++)
        {
            prefab.GetComponent<MonsterListObject>().setMon(FullListOfMonsters[i]);
            newObj = Instantiate(prefab, transform);
            //Debug.Log(newObj.name + " has been born");
        }
    }
}
