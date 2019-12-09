﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
    public class SpellCard : Entity
    {
        public new string name;

        public Ability Ability;

        public int cost;

        public string description;
        public int SpellEffectAmount;

        public Sprite artwork;

        public bool inHand, canPlay;

        public override void Damage(MonsterObject mon)
        {
            mon.health -= SpellEffectAmount;
        }
        public override void Heal(MonsterObject mon)
        {
            mon.health += SpellEffectAmount;
        }
    }
}

namespace Albatross { 
    public class Entity : ScriptableObject
    {

        public TypeElement element;
        public virtual void Damage(MonsterObject mon) { }
        public virtual void Heal(MonsterObject mon) { }
        public virtual void Heal(MonsterObject mon, int HealAmount) { }
        public virtual void Destroy(MonsterObject mon) { }
        public virtual void Destroy(SpellObject spell) { Negate(); }
        public virtual void Negate() { }
    }
}