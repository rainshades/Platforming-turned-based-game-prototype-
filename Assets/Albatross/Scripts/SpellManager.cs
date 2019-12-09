using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField]
        SpellObject CurrentSelectedSpell = null;
        BattleUi battleui = null;
        [SerializeField]
        MonsterObject currentMonster;

        void Awake()
        {
            TurnManager tm = FindObjectOfType<TurnManager>();
            currentMonster = tm.getCurrentMonster();
        }
        
        public void setSpell(SpellObject spell)
        {
            CurrentSelectedSpell = spell;
        }

        public SpellObject getCurrentSpell()
        {
            return CurrentSelectedSpell;
        }
    }
}