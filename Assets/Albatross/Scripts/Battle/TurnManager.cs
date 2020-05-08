using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages how the turns in a battle are organized
/// </summary>

namespace Albatross
{
    public class TurnManager : MonoBehaviour
    {
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

        public int TurnNumber;

        public Phases current_phase = Phases.Start;
        public bool SlowSpellFlag = false; 

        void Start()
        {
            bm = FindObjectOfType<BattleManager>();

            TurnOrder = DetermineTurnOrder(TurnOrder);
        }

        public List<MonsterObject> DetermineTurnOrder(List<MonsterObject> A)
        {
            List<MonsterObject> tmp = new List<MonsterObject>();

            for (int i = 0; i < A.Count-1; i++)
            {
                if (A[i].health > 0)
                {
                    tmp.Add(A[i]);
                }
                if (A.Count > 1)
                {
                    for (int j = 0; j < A.Count; j++)
                    {
                        if (A[i] != null && A[j] != null)
                        {
                            if (A[j].speed > A[i].speed)
                            {
                                MonsterObject holder = A[i];
                                A[i] = A[j];
                                A[j] = holder;
                            }
                        }
                    }
                }
            }
            return tmp;
        }


        public void Turn()
        {
            switch (current_phase)
            {
                case Phases.Start:
                    SpellManager sm = FindObjectOfType<SpellManager>();
                    SlowSpellFlag = false; 
                    sm.DrawCard();
                    current_phase = Phases.Main;
                    break;
                case Phases.Main:
                    SlowSpellFlag = true;
                    break;
                case Phases.End:
                    if (currentMonIndex < TurnOrder.Count - 1)
                    {
                        currentMonIndex++;
                    }
                    else
                    {
                        Debug.Log(TurnNumber++);
                        currentMonIndex = 0;
                    }
                    TurnOrder = DetermineTurnOrder(TurnOrder);
                    current_phase = Phases.Start;
                    break;
            }
        }


        public void EndTurn()
        {
            current_phase = Phases.End;
        }

        void Update()
        {
            CurrentMonster = TurnOrder[currentMonIndex];
            if (currentMonIndex + 1 != TurnOrder.Count)
            {
                NextMonster = TurnOrder[currentMonIndex + 1];
            }
            else
            {
                NextMonster = TurnOrder[0];
            }

            if (CurrentMonster.OwnedByPlayer)
            {
                PlayerControls.gameObject.SetActive(true);
            }
            else if (CurrentMonster != null)
            {
                PlayerControls.gameObject.SetActive(false);
                CurrentMonster.GetComponentInChildren<EnemyBattleDecision>().act();
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

        public MonsterObject GetCurrentMonster()
        {
            return CurrentMonster;
        }

        public Action GetAction()
        {
            return a;
        }

        public void SetAction(Action a)
        {
            this.a = a;
        }
    }
}