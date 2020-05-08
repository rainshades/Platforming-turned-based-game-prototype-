using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Handles the UI of the Battle Scene
/// </summary>
namespace Albatross
{
    public class BattleUi : MonoBehaviour
    {
        [SerializeField]
        TurnManager tm;
        [SerializeField]
        MonsterObject mon;
        [SerializeField]
        GameObject en; 
        BattleManager bm;
        SpellManager sm;

        public Canvas TargetBox;

        void Awake()
        {
            sm = FindObjectOfType<SpellManager>();
            tm = FindObjectOfType<TurnManager>();
            mon = tm.GetCurrentMonster();
            bm = FindObjectOfType<BattleManager>();
        }

        public void AttackButton()
        {
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            TargetBox.gameObject.SetActive(true);
            tm.SetAction(Action.Attack);
            en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.EnemyField);
        }

        public void AbilityButton()
        {
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            tm.SetAction(Action.ActiveAbility);
            tm.CanvasOn(TargetBox.gameObject);
            en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.EnemyField);
        }

        public void DefendButton()
        {
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            tm.SetAction(Action.Defend);
            mon.health += 10;
            tm.EndTurn();
        }
        public void SpellButton()
        {
            SpellObject spell = sm.getCurrentSpell();

            if (spell != null)
            {
                switch (spell.GetTargetType())
                {
                    case TargetType.AllyMonster:
                        en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
                        TargetBox.gameObject.SetActive(true);
                        tm.SetAction(Action.Cast);
                        en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.AllyField);
                        break;
                    case TargetType.EnemyMonster:
                        en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
                        TargetBox.gameObject.SetActive(true);
                        tm.SetAction(Action.Cast);
                        en.gameObject.GetComponent<Populate_Enemy>().Populate(bm.EnemyField);
                        break;
                    case TargetType.Self:
                        tm.SetAction(Action.Cast);
                        spell.Cast();
                        break;
                    case TargetType.NoTarget:
                        tm.SetAction(Action.Cast);
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