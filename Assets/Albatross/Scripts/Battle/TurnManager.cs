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

        bool quickSpellPause = false;

        public List<MonsterObject> IDTurnOrder = new List<MonsterObject>();

        BattleManager BattleManager;

        public int TurnNumber;

        public Phases current_phase = Phases.Start;
        public bool SlowSpellFlag = false; 

        void Start()
        {
            BattleManager = FindObjectOfType<BattleManager>();

            IDTurnOrder = DetermineTurnOrder(IDTurnOrder);

            CurrentMonster = IDTurnOrder[currentMonIndex];
            NextMonster = IDTurnOrder[currentMonIndex + 1];
        }

        public List<MonsterObject> DetermineTurnOrder(List<MonsterObject> A)
        {
            List<MonsterObject> tmp = new List<MonsterObject>();

            for (int i = 0; i < A.Count; i++)
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

        private void Update()
        {
            Turn();
        }

        public void Turn()
        {
            SpellManager SpellManager = FindObjectOfType<SpellManager>();

            switch (current_phase)
            {
                case Phases.Start:
                    SpellManager.SetTrigger(Trigger.StartPhase);
                    
                    if (CurrentMonster.OwnedByPlayer)
                    {
                        PlayerControls.gameObject.SetActive(true);
                        SpellManager.currentMonster = CurrentMonster;
                        SlowSpellFlag = false; //Slow/Eq spells are not allowed during Start and End Phase
                        SpellManager.DrawCard();
                        BattleManager.FightRotation();//Check if the game is over

                        current_phase = Phases.Main; //If the game isn't over go to next phase
                    } //Player's Turn

                    else if (CurrentMonster != null)
                    {
                        PlayerControls.gameObject.SetActive(false);
                        CurrentMonster.GetComponentInChildren<EnemyBattleDecision>().act();
                    } //NPC Turn

                    break;
                case Phases.Main:
                    SpellManager.SetTrigger(Trigger.MainPhase);

                    SlowSpellFlag = true; //Slow spells may be used
                    BattleManager.FightRotation();
                    break;
                case Phases.End:
                    SpellManager.SetTrigger(Trigger.EndPhase);

                    BattleManager.FightRotation(); /*Just in case a quick spell or spell effect takes place when the main phase is ending */
                    currentMonIndex++;
                    CurrentMonster = NextMonster;
                    
                    if(currentMonIndex >= IDTurnOrder.Count)
                    {
                        Debug.Log(TurnNumber++);
                        currentMonIndex = 0;
                    } //Checks to make sure index is within bounds

                    NextMonster = IDTurnOrder[currentMonIndex]; 

                    if(currentMonIndex + 1 >= IDTurnOrder.Count)
                    {
                        NextMonster = IDTurnOrder[0];
                    }
                    //Next Monster is mostly just for testing currentMonIndex, not for gameplay mechanics. Not super effecient, but easy
                    current_phase = Phases.Start;

                    break;
            }
        }


        public void EndTurn()
        {
            current_phase = Phases.End;
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