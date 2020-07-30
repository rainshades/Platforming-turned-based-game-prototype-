using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    [CreateAssetMenu(fileName = "New Negate Ability", menuName = "Negate Ability")]
    public class Negate : CardAbility
    {
        public override void DeployToMon(List<MonsterObject> Target)
        {
            StatBuffs(HealthBonus, AttackBonus, DefenceBonus, SpeedBonus);
        }

        public override void DeployToSpell(List<SpellObject> Spell)
        {
            throw new System.NotImplementedException();
        }
    }
}