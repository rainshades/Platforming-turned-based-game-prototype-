using UnityEngine;


namespace Albatross
{
    public class Entity : ScriptableObject
    {

        public TypeElement element;
        public virtual void Damage(MonsterObject mon, int Amount) { }
        public virtual void Damage(MonsterObject mon) { }
        public virtual void DamagePercentage(MonsterObject mon, float Percentage) { }
        public virtual void Heal(MonsterObject mon) { }
        public virtual void Heal(MonsterObject mon, int HealAmount) { }
        public virtual void HealPercentage(MonsterObject mon, float Percentage) { }
        public virtual void Destroy(MonsterObject mon) { }
        public virtual void Destroy(SpellObject spell) { Negate(); }
        public virtual void Negate() { }
    }
}