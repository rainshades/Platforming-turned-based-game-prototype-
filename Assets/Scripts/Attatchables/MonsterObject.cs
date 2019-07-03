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
    bool canbeTargeted = false;

    public Monster thisMonster;

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

        gm = FindObjectOfType<BattleManager>();
        rt = GetComponent<RectTransform>();

        sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = thisMonster.artwork;
        }
    }
    public MonsterObject Select()
    {
        return this;
    }

    public void Attack(MonsterObject target)
    {
        target.health -= attack;
    }
    public void Ability(MonsterObject target)
    {
        
    }
    public void CastSpell(MonsterObject target, SpellCard card)
    {

    }

    public bool getCanAct()
    {
        return canAct;
    }

    public void setCanAct(bool b)
    {
        canAct = b;
    }
    public void canBeTargeted(bool b)
    {
        canbeTargeted = b;
    }
    public bool getCanBeTargeted()
    {
        return canbeTargeted;
    }
}
