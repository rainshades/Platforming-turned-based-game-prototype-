using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action { NoAction, Ability, Attack, Cast, Defend}
public class TurnManager : MonoBehaviour
{
    int currentTurn;
    int turnNumber;
    public int a = 0;

    [SerializeField]
    MonsterObject CurrentMonster;
    [SerializeField]
    MonsterObject NextMonster;
    [SerializeField]
    Action currentAction;
    [SerializeField]
    MonsterObject TargetMon;

    public List<MonsterObject> TurnOrder = new List<MonsterObject>();

    BattleManager bm;

    void Start()
    {
        bm = FindObjectOfType<BattleManager>();
        determineTurnOrder(TurnOrder);

        CurrentMonster = TurnOrder[0];
        NextMonster = TurnOrder[1];
    }

    public List<MonsterObject> determineTurnOrder(List<MonsterObject> A)
    {
        List<MonsterObject> tmp = new List<MonsterObject>();
        for (int i = 0; i < A.Count; i++)
        {
            tmp.Add(A[i]);
            for (int j = 0; j < A.Count - 1; j++)
            {
                if (A[j].speed < A[i].speed)
                {
                    MonsterObject holder = A[i];
                    A[i] = A[j];
                    A[j] = holder;
                   // Debug.Log(A[i].name + "is replaced by" + A[j].name);
                }
            }
        }
        return tmp;
    }

    public void EndTurn()
    {
        CurrentMonster = NextMonster;
    }

    void Update()
    {
        determineTurnOrder(TurnOrder);

        if (a == 1)
        {
            currentAction = Action.Attack;
        }
        if (a == 2)
        {
            currentAction = Action.Ability;
        }
        if (a == 3)
        {
            currentAction = Action.Cast;
        }
        if (a == 4)
        {
            currentAction = Action.Defend;
        }

    }

    public void GoToSelect(int action)
    {
        a = action;
    }

    public void Select(MonsterObject mon)
    {
        TargetMon = mon;
    }

    public void Act(MonsterObject target)
    {

    }
    public void Act(MonsterObject target, SpellCard card)
    {

    }

}
