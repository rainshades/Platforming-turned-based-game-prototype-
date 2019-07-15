using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterObject : MonoBehaviour
{
    BattleManager gm;
    public bool ownedByPlayer;
    
    bool canAct = false;
    bool AbilityTargets = false;

    public Monster thisMonster;
    Ability ActiveAbility;
    Ability PassiveAbility;

    public int health, attack, speed;

    SpriteRenderer sr;

    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        name = thisMonster.name;
        health = thisMonster.health;
        attack = thisMonster.attack;
        speed = thisMonster.speed;
        ActiveAbility = thisMonster.active;
        PassiveAbility = thisMonster.passive;

        if(ActiveAbility.Target != null)
        {
            AbilityTargets = true;
        }

        gm = FindObjectOfType<BattleManager>();
        rt = GetComponent<RectTransform>();

        sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = thisMonster.artwork;
        }
    }

    void Update()
    {
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }

    public void AttackTarget(MonsterObject target)
    {
        thisMonster.Damage(target);
    }

    public void ActivateAbility(MonsterObject target)
    {
        ActiveAbility.Activate(target);
    }
    public void ActivateAbility()
    {
        ActiveAbility.Activate();
    }

    public bool getCanAct()
    {
        return canAct;
    }

    public void setCanAct(bool b)
    {
        canAct = b;
    }
    public bool canTarget()
    {
        return AbilityTargets;
    }
}
