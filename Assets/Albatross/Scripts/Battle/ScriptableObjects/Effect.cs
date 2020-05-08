using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
 
    [System.Serializable]
    public class Effect
    {
        public int EffectAmountInt;//For use in Healing and Damaging
        public float EffectAmountFloat;
        MonsterObject AttatchedCard;
        Entity AttatchedEntity;
        [SerializeField]
        EffectType effect;

        #if true
            
        #endif

        public void SetEffect(EffectType effect)
        {
            this.effect = effect;
        }

        public EffectType GetEffectType()
        {
            return effect;
        }

        public void SetAttatchedEntity(Entity e) 
        { 
            AttatchedEntity = e; 
        }

        public void SetAttatchedCard(MonsterObject mon) 
        {
            AttatchedCard = mon;
        }

        public void Deploy()
        {
            if (AttatchedEntity is Monster)
            {
                switch (effect)
                {
                    case EffectType.Heal:
                        AttatchedEntity.Heal(AttatchedCard, EffectAmountInt);
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
                    AttatchedEntity.Heal(targetMon, EffectAmountInt);
                    break;
                case EffectType.HealPercentage:
                    AttatchedEntity.HealPercentage(targetMon, EffectAmountFloat);
                    break;
                case EffectType.Damage:
                    AttatchedEntity.Damage(targetMon);
                    break;
                case EffectType.DamagePercentage:
                    AttatchedEntity.DamagePercentage(targetMon, EffectAmountFloat);
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
}
