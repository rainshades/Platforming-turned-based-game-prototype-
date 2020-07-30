using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    [CreateAssetMenu(fileName = "New AlignmentSwap Ability", menuName = "AlignmentSwap Ability")]
    public class AlignmentSwap : CardAbility
    {
        public StatSwaps StatSwap = StatSwaps.NoSwap;
        public override void DeployToMon(List<MonsterObject> Target)
        {
            foreach (MonsterObject target in Target)
            {
                switch (target.element)
                {
                    case TypeElement.Chaos:
                        target.element = TypeElement.Order;
                        break;
                    case TypeElement.Order:
                        target.element = TypeElement.Chaos;
                        break;
                    default:
                        Debug.LogError("Invalid ID Element");
                        break;
                }
            }
            if (has_a_bonus)
            {
                BonusAbility.DeployToMon(Target);
            }
            StatBuffs(HealthBonus, AttackBonus, DefenceBonus, SpeedBonus);
        }

        public override void DeployToSpell(List<SpellObject> Spell)
        {
            foreach (SpellObject target in Spell)
            {
                switch (target.element)
                {
                    case TypeElement.Dark:
                        target.element = TypeElement.Light;
                        break;
                    case TypeElement.Light:
                        target.element = TypeElement.Dark;
                        break;
                    default:
                        Debug.LogError("Invalid ID Element");
                        break;
                }
            }
            StatBuffs(HealthBonus, AttackBonus, DefenceBonus, SpeedBonus);
        }
    }
}