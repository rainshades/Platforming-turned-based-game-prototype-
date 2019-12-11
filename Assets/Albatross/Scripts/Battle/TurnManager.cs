/* Project Albatross 
 * Prepared by Eddie Fulton
 * Unpublished/Unfinished
 * Purpose: Manages the array of Characters on screen
 * Status: Member: Testing 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
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
                if (A[i].health > 0)
                {
                    tmp.Add(A[i]);
                }
                if (A.Count > 1)
                {
                    for (int j = 0; j <= A.Count; j++)
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

        public void EndTurn()
        {
            if (currentMonIndex < TurnOrder.Count - 1)
            {
                currentMonIndex++;
            }
            else
            {
                currentMonIndex = 0;
            }

            TurnOrder = determineTurnOrder(TurnOrder);
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

            if (CurrentMonster.ownedByPlayer)
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
}