using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class BattleUi : MonoBehaviour
    {
        [SerializeField]
        TurnManager tm;
        public Canvas targetBox;
        [SerializeField]
        MonsterObject mon;
        [SerializeField]
        GameObject en; 
        BattleManager bm;
        SpellManager sm; 
        

        void Awake()
        {
            sm = FindObjectOfType<SpellManager>();
            tm = FindObjectOfType<TurnManager>();
            mon = tm.getCurrentMonster();
            bm = FindObjectOfType<BattleManager>();
        }

        public void AttackButton()
        {
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            targetBox.gameObject.SetActive(true);
            tm.setAction(Action.Attack);
            en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.EnemyField);
        }

        public void AbilityButton()
        {
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            tm.setAction(Action.ActiveAbility);
            tm.CanvasOn(targetBox.gameObject);
            en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.EnemyField);
        }

        public void DefendButton()
        {
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            tm.setAction(Action.Defend);
            mon.health += 10;
            tm.EndTurn();
        }
        public void SpellButton()
        {
            SpellObject spell = sm.getCurrentSpell();

            if (spell != null)
            {
                switch (spell.getTargetType())
                {
                    case TargetType.AllyMonster:
                        en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
                        targetBox.gameObject.SetActive(true);
                        tm.setAction(Action.Cast);
                        en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.AllyField);
                        break;
                    case TargetType.EnemyMonster:
                        en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
                        targetBox.gameObject.SetActive(true);
                        tm.setAction(Action.Cast);
                        en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.EnemyField);
                        break;
                    case TargetType.Self:
                        tm.setAction(Action.Cast);
                        spell.Cast();
                        break;
                    case TargetType.NoTarget:
                        tm.setAction(Action.Cast);
                        spell.Cast();
                        break;
                    case TargetType.AllySpell:
                        break;
                    case TargetType.EnemySpell:
                        break;
                    default:
                        Debug.LogError("This Spell is flawed");
                        break;
                }
                en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            }
            else
            {
                Debug.LogError("No spell selected");
            }
        }
    }
}