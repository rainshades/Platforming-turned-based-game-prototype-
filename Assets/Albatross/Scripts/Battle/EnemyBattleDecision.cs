using UnityEngine;


namespace Albatross
{

    /// <summary>
    /// Placeholder for Enemy AI
    /// At the moment the enemy simply choosing a random available action
    /// if Spells aren't available it will simply choose to attack or defend
    /// </summary>
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

            if (target != null)
            {
                switch (action)
                {
                    case Action.Attack:
                        actor.AttackTarget(target.GetComponent<MonsterObject>());
                        Debug.Log(actor.name + " " + action.ToString() + "ed against " + target.name);
                        Debug.Log("target has " + target.GetComponent<MonsterObject>().health + "hp left");
                        break;
                    case Action.Cast:
                        Debug.Log(actor.name + " " + action.ToString() + "ed against " + target.name);
                        break;
                    case Action.ActiveAbility:
                        if (actor.CanTarget())
                        {
                            actor.ActivateAbility(target.GetComponent<MonsterObject>());
                        }
                        else
                        {
                            actor.ActivateAbility(target.GetComponent<MonsterObject>());
                        }
                        Debug.Log(actor.name + " " + action.ToString() + " against " + target.name);
                        Debug.Log("target has " + target.GetComponent<MonsterObject>().health + "hp left");
                        break;
                    case Action.Defend:
                        actor.Defend();
                        Debug.Log(actor.name + " gained hp back");
                        break;
                }
                tm.EndTurn();
            }
            else
            {
                act();
            }
        }
    }
}