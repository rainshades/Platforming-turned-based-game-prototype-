using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable Spells
/// </summary>
namespace Albatross
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
    public class SpellCard : Entity
    {
        public new string name;

        public SpellEffect SpellEffect;

        public int cost;

        public string description;

        public Sprite artwork;

        public bool inHand, canPlay;

        public override void Damage(MonsterObject mon, int EffectAmount)
        {
            mon.health -= EffectAmount;
        }
        public override void Heal(MonsterObject mon, int EffectAmount)
        {
            mon.health += EffectAmount;
        }

        public override void DamagePercentage(MonsterObject mon, float Percentage)
        {
            if(mon.health > 1)
            mon.health *= Percentage;
        }
        public override void HealPercentage(MonsterObject mon, float Percentage)
        {
            mon.health *= Percentage;
        }

        public void AlignmentSwap(MonsterObject mon)
        {
            switch (mon.element)
            {
                case TypeElement.Chaos:
                    mon.element = TypeElement.Order;
                    break;
                case TypeElement.Order:
                    mon.element = TypeElement.Chaos;
                    break;
                default:
                    Debug.LogError("Invalid ID Element");
                    break;
            }
        }


        #region Swap
        public void AttackSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.attack;
            a.attack = b.attack;
            b.attack = holder;             
        }

        public void DefenseSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.defence_value;
            a.defence_value = b.defence_value;
            b.defence_value = holder;
        }

        public void SpeedSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.speed;
            a.speed = b.speed;
            b.speed = holder;
        }
        public void HealthSwap(MonsterObject a, MonsterObject b)
        {
            float holder = b.health;
            a.health = b.health;
            b.health = holder;

        }
        #endregion
    }
}