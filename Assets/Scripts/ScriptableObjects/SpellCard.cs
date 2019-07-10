using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SpellCard : ScriptableObject, Entity
{
    public new string name;
    public string description;
    public int SpellEffectAmount;

    public Sprite artwork;

    public bool inHand, canPlay;

    public void Damage(MonsterObject mon)
    {
        mon.health -= SpellEffectAmount;
    }

    public void Heal(MonsterObject mon, int amount)
    {

    }
    public void Destroy(MonsterObject mon)
    {

    }
    public void Negate()
    {

    }
    public void Destroy(SpellObject spell)
    {

    }
}

public interface Entity
{
    void Damage(MonsterObject mon);
    void Heal(MonsterObject mon, int amount);
    void Destroy(MonsterObject mon);
    void Destroy(SpellObject spell);
    void Negate();
}
