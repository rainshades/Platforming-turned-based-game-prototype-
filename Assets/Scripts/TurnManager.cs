using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    int currentTurn;

    public Phase currentPhase;

    BattleManager bm;

    void Start()
    {
        bm = FindObjectOfType<BattleManager>();
    }

    public void nextPhase()
    {
        currentPhase.NextPhase();
    }
}
