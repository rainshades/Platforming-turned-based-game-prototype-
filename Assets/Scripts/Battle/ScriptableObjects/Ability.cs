﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum TargetType { Self, EnemyMonster, AllyMonster, EnemySpell, AllySpell, NoTarget }
public class Ability: ScriptableObject
{
    
    public bool isTargetAbility;
    public Effect effect;
    public TargetType TargetType;

    public string EffectDescription;

    //Effect Triggers
    public virtual void Activate() { effect.Deploy(); }
    public virtual void Activate(MonsterObject target) { effect.Deploy(target); }
    public virtual void Activate(SpellObject target) { effect.Deploy(target); }
    public virtual void RecurringOverDuration(int duration) {  }
    public virtual void InfinateRecurring() { }
    public virtual void onDraw() { effect.Deploy(); }
    public virtual void onDraw(MonsterObject target) { effect.Deploy(target); }
    public virtual void onDraw(SpellObject target) { effect.Deploy(target); }
    public virtual void onAttack() { effect.Deploy(); }
    public virtual void onAttack(MonsterObject target) { effect.Deploy(target); }
    public virtual void onAttack(SpellObject target) { effect.Deploy(target); }
    public virtual void onDefend() { effect.Deploy(); }
    public virtual void onDefend(MonsterObject target) { effect.Deploy(target); }
    public virtual void onDefend(SpellObject target) { effect.Deploy(target); }
    public virtual void onAbility() { effect.Deploy(); }
    public virtual void onAbility(MonsterObject target) { effect.Deploy(target); }
    public virtual void onAbility(SpellObject target) { effect.Deploy(target); }
    public virtual void onDeath() { effect.Deploy(); }
    public virtual void onDeath(MonsterObject target) { effect.Deploy(target); }
    public virtual void onDeath(SpellObject target) { effect.Deploy(target); }
    public virtual void onHealthAmount() { effect.Deploy(); }
    public virtual void onHealthAmount(MonsterObject target) { effect.Deploy(target); }
    public virtual void onHealthAmount(SpellObject target) { effect.Deploy(target); }
    public virtual void onDestory() { effect.Deploy(); }
    public virtual void onDestory(MonsterObject target) { effect.Deploy(target); }
    public virtual void onDestory(SpellObject target) { effect.Deploy(target); }
    public virtual void onEffect() { effect.Deploy(); }
    public virtual void onEffect(MonsterObject target) { effect.Deploy(target); }
    public virtual void onEffect(SpellObject target) { effect.Deploy(target); }
}