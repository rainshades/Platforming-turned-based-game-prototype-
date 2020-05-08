using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 
/// </summary>
namespace Albatross
{

    [System.Serializable]
    public class Ability : ScriptableObject
    {
        public bool IsTargetAbility;
        public Effect Effect;
        public TargetType TargetType;

        public string EffectDescription;

        //If the User has a choice in activating 
        public virtual void Activate() { Effect.Deploy(); }
        public virtual void Activate(MonsterObject target) { Effect.Deploy(target); }
        public virtual void Activate(SpellObject target) { Effect.Deploy(target); }

        //If the ability lasts longer then a turn
        public virtual void RecurringOverDuration(int duration) { }
        public virtual void InfinateRecurring() { }

        //When the Ability's effect triggers
        public virtual void OnDraw() { Effect.Deploy(); }
        public virtual void OnDraw(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnDraw(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnAttack() { Effect.Deploy(); }
        public virtual void OnAttack(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnAttack(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnDefend() { Effect.Deploy(); }
        public virtual void OnDefend(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnDefend(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnAbility() { Effect.Deploy(); }
        public virtual void OnAbility(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnAbility(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnDeath() { Effect.Deploy(); }
        public virtual void OnDeath(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnDeath(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnHealthAmount() { Effect.Deploy(); }
        public virtual void OnHealthAmount(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnHealthAmount(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnDestory() { Effect.Deploy(); }
        public virtual void OnDestory(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnDestory(SpellObject target) { Effect.Deploy(target); }
        public virtual void OnEffect() { Effect.Deploy(); }
        public virtual void OnEffect(MonsterObject target) { Effect.Deploy(target); }
        public virtual void OnEffect(SpellObject target) { Effect.Deploy(target); }
    }
}