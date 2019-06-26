using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateSpellList : MonoBehaviour
{
    [SerializeField]
    List<SpellCard> FullListOfSpells = new List<SpellCard>();

    public GameObject prefab;

    public int numberToCreate;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Populate()
    {
        GameObject newObj;
        numberToCreate = FullListOfSpells.Count;

        for (int i = 0; i < numberToCreate; i++)
        {
            prefab.GetComponent<SpellListObject>().setSpell(FullListOfSpells[i]);
            newObj = Instantiate(prefab, transform);
            Debug.Log(newObj.name + " has been born");
        }
    }
}
