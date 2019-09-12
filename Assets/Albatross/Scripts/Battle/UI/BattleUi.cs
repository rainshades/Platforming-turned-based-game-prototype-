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

        void Start()
        {
            tm = FindObjectOfType<TurnManager>();
        }
        void Update()
        {
            mon = tm.getCurrentMonster();
        }

        public void AttackButton()
        {
            tm.setAction(Action.Attack);
            tm.CanvasOn(targetBox.gameObject);
        }

        public void AbilityButton()
        {
            tm.setAction(Action.ActiveAbility);
            tm.CanvasOn(targetBox.gameObject);
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