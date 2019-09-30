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
        
        void Update()
        {
            tm = FindObjectOfType<TurnManager>();
            en = FindObjectOfType<Populate_Enemy>().gameObject;
            mon = tm.getCurrentMonster();
        }

        public void AttackButton()
        {
            targetBox.gameObject.SetActive(true);
            tm.setAction(Action.Attack);
            en.gameObject.GetComponent<Populate_Enemy>().Populate();
        }

        public void AbilityButton()
        {
            tm.setAction(Action.ActiveAbility);
            tm.CanvasOn(targetBox.gameObject);
            en.gameObject.GetComponent<Populate_Enemy>().Populate();
        }

        public void DefendButton()
        {
            tm.setAction(Action.Defend);
            mon.health += 10;
            tm.EndTurn();
        }
        public void SpellButton()
        {
            tm.CanvasOn(Hand.gameObject);
        }
    }
}