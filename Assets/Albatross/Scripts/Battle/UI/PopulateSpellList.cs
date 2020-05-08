using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class PopulateSpellList : MonoBehaviour
    {
        [SerializeField]
        List<SpellCard> FullListOfSpells = new List<SpellCard>();
        GameManager gm;

        public GameObject prefab;
        public int numberToCreate;
		
        void Awake()
        {
                gm = FindObjectOfType<GameManager>();
                FullListOfSpells = gm.DemoInventory.SpellsInInventory; 
        }

        void Start()
        {
            Populate();
        }


        public void Populate()
        {
            GameObject newObj;
            numberToCreate = FullListOfSpells.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                prefab.GetComponent<SpellListObject>().SetSpell(FullListOfSpells[i]);
                newObj = Instantiate(prefab, transform);
            }
        }
    }
}
