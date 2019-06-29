using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    int currentTurn;
    int turnNumber;

    [SerializeField]
    MonsterObject CurrentMonster;
    [SerializeField]
    MonsterObject NextMonster;

    public List<MonsterObject> TurnOrder = new List<MonsterObject>();

    BattleManager bm;

    void Start()
    {
        bm = FindObjectOfType<BattleManager>();
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

    }

}
