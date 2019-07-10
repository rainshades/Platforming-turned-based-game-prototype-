using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject, Entity
{
    public new string name;

    public int monNumber;
    
    public string description;

    public int attack;
    public int health;
    public int speed;

    public Sprite artwork;
    public bool alive;

    public void Damage(MonsterObject mon)
    {
        mon.health -= attack;
    }
    public void Heal(MonsterObject mon, int amount)
    {
        mon.health += amount;
    }
    public void selfHeal(int amount)
    {
        health += amount;
    }
    public void Destroy(MonsterObject mon)
    {
        Destroy(mon);
    }
    public void Destroy(SpellObject spell)
    {
        Negate();
        Destroy(spell);
    }
    public void Negate()
    {

    }

}