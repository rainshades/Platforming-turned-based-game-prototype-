using UnityEngine;
using UnityEngine.EventSystems;


namespace Albatross
{
    /// <summary>
    /// Selects an Enemy to target during battle
    /// After A spell has been selected
    /// OR 
    /// An Attack order has been issued
    /// </summary>
    public class Select_Enemy : MonoBehaviour, IPointerClickHandler
    {
        TurnManager tm;
        SpellManager sm;
        MonsterObject currentMon;
        Populate_Enemy populate;

        public MonsterObject TargetMon;
        public GameObject CanvasToTurnOff;

        void Start()
        {
            CanvasToTurnOff = transform.parent.gameObject;
            tm = FindObjectOfType<TurnManager>();
            sm = FindObjectOfType<SpellManager>();
            currentMon = tm.GetCurrentMonster();
            populate = FindObjectOfType<Populate_Enemy>();
        }

        public void OnPointerClick(PointerEventData PE)
        {
            switch (tm.GetAction())
            { 
                //Enacts the action given to it by the turn manager
                case Action.Attack:

                    currentMon.AttackTarget(TargetMon);
                    populate.Depopulate();
                    tm.CanvasOff(CanvasToTurnOff);

                    sm.SetTrigger(Trigger.Attack);
                    sm.SetTrigger(Trigger.AllyAttack);

                    tm.EndTurn();
                    break;

                case Action.ActiveAbility:
                    Debug.Log("Ability the target");
                    if (currentMon.CanTarget())
                    {
                        currentMon.ActivateAbility(TargetMon);
                        populate.Depopulate();
                        tm.CanvasOff(CanvasToTurnOff);

                        sm.SetTrigger(Trigger.Ability);
                        sm.SetTrigger(Trigger.AllyAbility);

                        tm.EndTurn();
                    }
                    else
                    {
                        currentMon.ActivateAbility();
                        
                        sm.SetTrigger(Trigger.Ability);
                        sm.SetTrigger(Trigger.AllyAbility);

                        populate.Depopulate();
                        tm.CanvasOff(CanvasToTurnOff);
                        tm.EndTurn();
                    }
                    break;

                case Action.Cast:
                    if (tm.GetCurrentMonster().mana > sm.getCurrentSpell().cost)
                    {
                        sm.getCurrentSpell().CastToTarget(TargetMon);
                        tm.CanvasOff(CanvasToTurnOff);
                        
                        sm.SetTrigger(Trigger.SpellCast);
                        sm.SetTrigger(Trigger.AllyCast);

                        tm.EndTurn();
                    }
                    else
                    {
                        Debug.Log("Not Enough Mana");
                    }
                    break;

                case Action.Defend:
                    if(tm.GetCurrentMonster().mana > tm.GetCurrentMonster().defence_value)
                    {
                        Debug.Log("Defended Yourself");
                        Debug.Log(currentMon.name + " defends itself ");
                        Debug.Log(currentMon.name + " has " + currentMon.health + " left");

                        sm.SetTrigger(Trigger.Defend);
                        sm.SetTrigger(Trigger.AllyDefend);
                        
                        tm.EndTurn();
                    }
                    else
                    {
                        Debug.Log("Not Enough Mana");
                    }
                    break;
            }
        }
    }
}