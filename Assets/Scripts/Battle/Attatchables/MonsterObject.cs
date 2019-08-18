using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterObject : MonoBehaviour
{
    BattleManager gm;
    public bool ownedByPlayer;

    [SerializeField]
    string AttackAnimation;

    [SerializeField]
    string CastAnimation;

    bool canAct = false;
    bool AbilityTargets = false;

    public Monster thisMonster;
    Ability ActiveAbility;
    Ability PassiveAbility;

    public float health, attack, speed;

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

        ActiveAbility.effect.SetAttatchedEntity(thisMonster);
        PassiveAbility.effect.SetAttatchedEntity(thisMonster);

        ActiveAbility.effect.SetAttatchedCard(this);
        PassiveAbility.effect.SetAttatchedCard(this);

        if (ActiveAbility != null)
        {
            AbilityTargets = ActiveAbility.isTargetAbility;
        }

        gm = FindObjectOfType<BattleManager>();
        rt = GetComponent<RectTransform>();

        sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = thisMonster.artwork;
        }
    }

    public void hit(GameObject target)
    {
        MonsterObject ownerStats = this.GetComponent<MonsterObject>();
        MonsterObject targetStats = target.GetComponent<MonsterObject>();

        float damage = ownerStats.attack;

        this.GetComponent<Animator>().Play(AttackAnimation);
        targetStats.RecieveDamage(damage);
    }

    public void cast(GameObject target)
    {
        this.GetComponent<Animator>().Play(CastAnimation);
    }

    public void defend()
    {
        
    }

    public void RecieveDamage(float damage)
    {
        health -= damage;
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
