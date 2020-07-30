using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    [CreateAssetMenu(fileName = "New SwapStat Ability", menuName = "SwapStat Ability")]
    public class SwapStatSpells : CardAbility
    {
        public StatSwaps StatSwaps = StatSwaps.NoSwap; 

        public override void DeployToMon(List<MonsterObject> Target)
        {
            foreach(MonsterObject target in Target)
            switch (StatSwaps)
            {
                case StatSwaps.HealthSwap:
                    HealthSwap(caster, target);
                    break;
                case StatSwaps.AttackSwap:
                        AttackSwap(caster, target);
                    break;
                case StatSwaps.DefenseSwap:
                        DefenseSwap(caster, target);
                    break;
                case StatSwaps.SpeedSwap:
                        SpeedSwap(caster, target);
                    break;
                case StatSwaps.ManaSwap:
                        ManaSwap(caster, target);
                    break;
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
        #region Swap
        private static void AttackSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.attack;
            a.attack = b.attack;
            b.attack = holder;
        }

        private static void DefenseSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.defence_value;
            a.defence_value = b.defence_value;
            b.defence_value = holder;
        }

        private static void SpeedSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.speed;
            a.speed = b.speed;
            b.speed = holder;
        }
        private static void HealthSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.health;
            a.health = b.health;
            b.health = holder;

        }

        private static void ManaSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.mana;
            a.mana = b.mana;
            b.mana = holder;
        }
        #endregion

    }
}