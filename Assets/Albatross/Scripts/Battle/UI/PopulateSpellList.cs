using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class PopulateSpellList : MonoBehaviour
    {
        [SerializeField]
        List<SpellCard> FullListOfSpells = new List<SpellCard>();
        [SerializeField]
        GameObject DemoGameManager;
        GameManager gm;

        public GameObject prefab;
        public int numberToCreate;
		
        void Awake()
        {

            if (FindObjectOfType<GameManager>() == null)
            {
                Instantiate(DemoGameManager);
                FullListOfSpells = DemoGameManager.GetComponent<GameManager>().DemoInventory.SpellsInInventory; // Only for DEMO TODO: REMOVE
            }
            else
            {

                gm = FindObjectOfType<GameManager>();
                FullListOfSpells = gm.DemoInventory.SpellsInInventory; // Only for DEMO TODO: REMOVE

            }

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
                prefab.GetComponent<SpellListObject>().setSpell(FullListOfSpells[i]);
                newObj = Instantiate(prefab, transform);
            }
        }
    }
}
