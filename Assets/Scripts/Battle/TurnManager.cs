using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Action { Attack, ActiveAbility, PassiveAbility, Cast, Defend }
public class TurnManager : MonoBehaviour
{

    int currentTurn;
    int turnNumber;
    [SerializeField]
    Action a;

    [SerializeField]
    int currentMonIndex = 0;

    [SerializeField]
    Canvas PlayerControls = null;

    [SerializeField]
    MonsterObject CurrentMonster;
    [SerializeField]
    MonsterObject NextMonster;
    [SerializeField]
    MonsterObject TargetMon;

    public List<MonsterObject> TurnOrder = new List<MonsterObject>();

    BattleManager bm;

    void Start()
    {
        bm = FindObjectOfType<BattleManager>();

        TurnOrder = determineTurnOrder(TurnOrder);
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
        if(currentMonIndex < TurnOrder.Count)
        {
            Debug.Log("Goes to next Monster");
            currentMonIndex++;
        }
        else
        {
            Debug.Log("The cycle begins again");
            currentMonIndex = 0;
        }

        bm.DrawCard();
    }

    void Update()
    {
        CurrentMonster = TurnOrder[currentMonIndex];
        NextMonster = TurnOrder[currentMonIndex + 1];

        if (CurrentMonster.ownedByPlayer)
        {
            PlayerControls.gameObject.SetActive(true);
        }
        else
        {
            PlayerControls.gameObject.SetActive(false);
        }
    }

    public void Select(MonsterObject mon)
    {
        TargetMon = mon;
    }

    public void CanvasOn(GameObject c)
    {
        c.gameObject.SetActive(true);
    }

    public void CanvasOff(GameObject c)
    {
        c.gameObject.SetActive(false);
    }

    public MonsterObject getCurrentMonster()
    {
        return CurrentMonster;
    }

    public Action getAction()
    {
        return a;
    }

    public void setAction(Action a)
    {
        this.a = a;
    }
}
