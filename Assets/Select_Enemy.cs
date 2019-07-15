using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Select_Enemy : MonoBehaviour, IPointerClickHandler
{
    TurnManager tm;
    public MonsterObject TargetMon;
    MonsterObject currentMon;
    public GameObject CanvasToTurnOff;

    void Start()
    {
        CanvasToTurnOff = transform.parent.gameObject;
        tm = FindObjectOfType<TurnManager>();
        currentMon = tm.getCurrentMonster();
    }

    public void OnPointerClick(PointerEventData PE)
    {
        switch (tm.getAction())
        {
            case Action.Attack:
                currentMon.AttackTarget(TargetMon);
                tm.CanvasOff(CanvasToTurnOff);
                tm.EndTurn();
                break;
            case Action.ActiveAbility:
                Debug.Log("Ability the target");
                tm.EndTurn();
                break;
            case Action.Cast:
                Debug.Log("Cast Spell on the Target");
                tm.EndTurn();
                break;
            case Action.Defend:
                Debug.Log("Defend Yourself");
                tm.EndTurn();
                break;
        }
    }
}
