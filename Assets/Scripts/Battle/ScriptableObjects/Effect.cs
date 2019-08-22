using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType { Heal, Damage, Negate, Destroy, Stun }

[System.Serializable]
public class Effect
{
    public int EffectAmount;//For use in Healing and Damaging
    MonsterObject AttatchedCard;
    Entity AttatchedEntity;
    [SerializeField]
    EffectType effect;

    public void setEffect(EffectType effect)
    {
        this.effect = effect;
    }
    public EffectType getEffectType()
    {
        return effect;
    }
    public void SetAttatchedEntity(Entity e) { AttatchedEntity = e; }
    public void SetAttatchedCard(MonsterObject mon) { AttatchedCard = mon; }

    public void Deploy()
    {
        if (AttatchedEntity is Monster)
        {
            switch (effect)
            {
                case EffectType.Heal:
                    AttatchedEntity.Heal(AttatchedCard, EffectAmount);
                    break;
                case EffectType.Damage:
                    AttatchedEntity.Damage(AttatchedCard);
                    break;
                case EffectType.Negate:
                    AttatchedEntity.Negate();
                    break;
                case EffectType.Destroy:
                    AttatchedEntity.Destroy(AttatchedCard);
                    break;
            }
        }
        Debug.Log("Effect Triggered");
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
        Debug.Log("Effect Triggered");
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
        Debug.Log("Effect Triggered");
    }//The attatched body effects a spell
}