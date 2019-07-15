using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Effect: ScriptableObject
{
    public int EffectAmount;//For use in Healing and Damaging
    public enum EffectType { Heal, Damage, Negate, Destroy, Stun}
    MonsterObject AttatchedCard;
    Entity AttatchedEntity;
    [SerializeField]
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