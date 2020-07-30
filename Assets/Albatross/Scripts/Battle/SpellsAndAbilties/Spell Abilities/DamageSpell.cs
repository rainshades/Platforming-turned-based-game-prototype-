using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    [CreateAssetMenu(fileName = "New Damage Ability", menuName = "Damage Ability")]
    public class DamageSpell : CardAbility
    {
        public int EffectIntAmount;

        public override void DeployToMon(List<MonsterObject> Target)
        {
            foreach (MonsterObject target in Target)
            {
                target.health -= EffectIntAmount;
            }

            if (has_a_bonus)
            {
                BonusAbility.DeployToMon(Target);
            }
            StatBuffs(HealthBonus, AttackBonus, DefenceBonus, SpeedBonus);
        }

        public override void DeployToSpell(List<SpellObject> Spell)
        {
            throw new System.NotImplementedException();
        }
    }
}