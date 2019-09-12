using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class EnemyBattleDecision : MonoBehaviour
    {
        [SerializeField]
        Action[] TurnOptions = null;
        [SerializeField]
        string targetsTag = "";

        GameObject findRandomTarget()
        {
            GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(targetsTag);

            if (possibleTargets.Length > 0)
            {
                int targetIndex = Random.Range(0, possibleTargets.Length);
                GameObject target = possibleTargets[targetIndex];

                return target;
            }

            return null;
        }

        Action setAction()
        {
            int optionIndex = Random.Range(0, TurnOptions.Length);
            return TurnOptions[optionIndex];
        }

        public void act()
        {
            MonsterObject actor = gameObject.transform.parent.GetComponent<MonsterObject>();
            Action action = setAction();
            GameObject target = findRandomTarget();
            TurnManager tm = FindObjectOfType<TurnManager>();

            switch (action)
            {
                case Action.Attack:
                    actor.AttackTarget(target.GetComponent<MonsterObject>());
                    Debug.Log(actor.name + " " + action.ToString() + "ed against " + target.name);
                    break;
                case Action.Cast:
                    Debug.Log(actor.name + " " + action.ToString() + "ed against " + target.name);
                    break;
                case Action.ActiveAbility:
                    if (actor.canTarget())
                    {
                        actor.ActivateAbility(target.GetComponent<MonsterObject>());
                    }
                    else
                    {
                        actor.ActivateAbility(target.GetComponent<MonsterObject>());
                    }
                    Debug.Log(actor.name + " " + action.ToString() + "ed against " + target.name);
                    break;
                case Action.Defend:
                    actor.defend();
                    Debug.Log(actor.name + " " + action.ToString() + "ed against " + target.name);
                    break;
            }
            tm.EndTurn();
        }
    }
}