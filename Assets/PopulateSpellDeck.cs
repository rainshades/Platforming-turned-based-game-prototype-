using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    public class PopulateSpellDeck : MonoBehaviour
    {
        GameManager gm;

        [SerializeField]
        List<SpellCard> SpellsinDeck;
        [SerializeField]
        GameObject DemoGameManager;

        public GameObject prefab;

        public int numberToCreate;


        void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            SpellsinDeck = gm.currentDeck.spells;
        }

        // Start is called before the first frame update
        void Start()
        {
            InnitPopulate();
        }

        public void InnitPopulate()
        {
            GameObject newObj;
            numberToCreate = SpellsinDeck.Count;

            for (int i = 0; i < numberToCreate; i++)
            {
                prefab.GetComponent<SpellListObject>().setSpell(SpellsinDeck[i]);
                newObj = Instantiate(prefab, transform);
                //Debug.Log(newObj.name + " has been born");
            }
        }
    }
}

