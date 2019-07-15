using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : Entity
{
    public new string name;

    public ActiveAbility active;
    public PassiveAbility passive;

    public int effectAmount;

    public string description;

    public int attack;
    public int health;
    public int speed;

    public Sprite artwork;
    public bool alive;

    public override void Damage(MonsterObject mon)
    {
        mon.health -= attack;
    }
    public void selfHeal(int amount)
    {
        health += amount;
    }
    public override void Heal(MonsterObject mon)
    {
        mon.health += effectAmount;
    }
}