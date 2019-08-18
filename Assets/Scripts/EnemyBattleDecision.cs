using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleDecision : MonoBehaviour
{
    [SerializeField]
    Action[] TurnOptions;
    [SerializeField]
    string targetsTag;


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

    void setAction()
    {

    }

    public void act()
    {
        setAction();
        GameObject target = findRandomTarget();
        Debug.Log(gameObject.transform.parent.name + " Acts");
        TurnManager tm = FindObjectOfType<TurnManager>();
        tm.EndTurn();
    }
}
