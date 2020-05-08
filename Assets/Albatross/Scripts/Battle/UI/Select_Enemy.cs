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
            { //Enacts the action given to it by the turn manager
                case Action.Attack:
                    currentMon.AttackTarget(TargetMon);
                    populate.Depopulate();
                    Debug.Log(currentMon.name + " basic attacked " + TargetMon.name);
                    Debug.Log(TargetMon.name + " has " + TargetMon.health + " left");
                    tm.CanvasOff(CanvasToTurnOff);
                    tm.EndTurn();
                    break;

                case Action.ActiveAbility:
                    Debug.Log("Ability the target");
                    if (currentMon.CanTarget())
                    {
                        currentMon.ActivateAbility(TargetMon);
                        populate.Depopulate();
                        Debug.Log(currentMon.name + " used an ability towards " + TargetMon.name);
                        Debug.Log(TargetMon.name + " has " + TargetMon.health + " left");
                        tm.CanvasOff(CanvasToTurnOff);
                        tm.EndTurn();
                    }
                    else
                    {
                        currentMon.ActivateAbility();
                        populate.Depopulate();
                        tm.CanvasOff(CanvasToTurnOff);
                        tm.EndTurn();
                    }
                    break;
                case Action.Cast:
                    Debug.Log("Cast " + sm.getCurrentSpell().name + " on " + TargetMon);
                    sm.getCurrentSpell().CastToTarget(TargetMon);
                    tm.EndTurn();
                    break;
                case Action.Defend:
                    Debug.Log("Defended Yourself");
                    Debug.Log(currentMon.name + " defends itself ");
                    Debug.Log(currentMon.name + " has " + currentMon.health + " left");
                    tm.EndTurn();
                    break;
            }
        }
    }
}