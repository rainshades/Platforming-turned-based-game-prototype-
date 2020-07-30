using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


namespace Albatross
{
    public abstract class CardAbility: ScriptableObject
    {
        public Trigger Trigger = Trigger.NoTrigger;
        public TargetType TargetType = TargetType.NoTarget;
        public CastType CastType = CastType.NoCast;
        public EffectType EffectType = EffectType.NoEffect;
        public TypeElement TypeElement = TypeElement.NoElement;

        public float HealthBonus, AttackBonus, DefenceBonus, SpeedBonus;

        public int NumberOfTargets;

        public MonsterObject caster;

        public bool has_a_bonus;
        public CardAbility BonusAbility;


        public abstract void DeployToMon(List<MonsterObject> Target);
        public abstract void DeployToSpell(List<SpellObject> Spell);

        public void StatBuffs(float health, float attack, float defence, float speed)
        {
            caster.health += health; caster.attack += attack; caster.defence_value += defence;
            caster.speed += speed; 
        }

    }
}