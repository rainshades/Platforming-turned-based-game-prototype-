using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect 
{
    public int EffectAmount;//For use in Healing and Damaging
    public enum EffectType { Heal, Damage, Negate, Destroy }
    Entity AttatchedEntity;
    EffectType effect;

    public void setEffect(EffectType effect)
    {
        this.effect = effect;
    }

    public void setAttatchedEntity(Entity e) { AttatchedEntity = e; }

    public void Deploy()
    {
        if (AttatchedEntity is Monster)
        {
            switch (effect)
            {
                case EffectType.Heal:
                    AttatchedEntity.Heal(AttatchedEntity as MonsterObject, EffectAmount);
                    break;
                case EffectType.Damage:
                    AttatchedEntity.Damage(AttatchedEntity as MonsterObject);
                    break;
                case EffectType.Negate:
                    AttatchedEntity.Negate();
                    break;
                case EffectType.Destroy:
                    AttatchedEntity.Destroy(AttatchedEntity as MonsterObject);
                    break;
            }
        }
    }//The attatched body effects itself.

    public void Deploy(MonsterObject targetMon)
    {
        switch (effect)
        {
            case EffectType.Heal:
                AttatchedEntity.Heal(targetMon, EffectAmount);
                break;
            case EffectType.Damage:
                AttatchedEntity.Damage(targetMon);
                break;
            case EffectType.Negate:
                AttatchedEntity.Negate();
                break;
            case EffectType.Destroy:
                AttatchedEntity.Destroy(targetMon);
                break;
        }
    }//The attatched body effects another monster
    public void Deploy(SpellObject targetSpell)
    {
        switch (effect)
        {
            case EffectType.Negate:
                AttatchedEntity.Negate();
                break;
            case EffectType.Destroy:
                AttatchedEntity.Destroy(targetSpell);
                break;
        }
    }//The attatched body effects a spell
}

public class Ability
{
    public string name;
    public Effect effect;
    public Entity Target;

    //Effect Triggers
    public virtual void Activate() { }
    public virtual void Passive() { }
    public virtual void RecurringOverDuration(int duration) { }
    public virtual void InfinateRecurring() { }
    public virtual void onDraw() { }
    public virtual void onAttack() { }
    public virtual void onDefend() { }
    public virtual void onAbility() { }
    public virtual void onDeath() { }
    public virtual void onHealthAmount() { }
    public virtual void onDestory() { }
    public virtual void onEffect() { }
}
