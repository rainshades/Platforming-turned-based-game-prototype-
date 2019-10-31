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
        public Canvas Hand;
        [SerializeField]
        MonsterObject mon;
        [SerializeField]
        GameObject en;
        BattleManager bm;
        

        void Update()
        {
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
            en.gameObject.GetComponent<Populate_Enemy>().Depopulate();
            tm.CanvasOn(Hand.gameObject);
        }
    }
}