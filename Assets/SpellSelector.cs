using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Albatross
{
    public class SpellSelector : MonoBehaviour
    {
        
        public SpellCard currentSpell;
        SpellObject spell;
        int CurrentSpellNumber = 0;
        Deck PlayerSpells;
        GameManager gm;
        SpellManager sm;

        public GameObject spellPrefab;

        void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            sm = FindObjectOfType<SpellManager>();

            PlayerSpells = gm.currentDeck;
            currentSpell = PlayerSpells.spells[CurrentSpellNumber];

            spellPrefab.GetComponent<SpellObject>().spell = currentSpell;
            GameObject go = Instantiate(spellPrefab, transform);

        }

        public void CycleUp()
        {
            ++CurrentSpellNumber;
        }

        public void CycleDown()
        {
            --CurrentSpellNumber;
        }

    }
}