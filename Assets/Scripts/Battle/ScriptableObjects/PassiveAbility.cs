using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PassiveAbility : Ability
{
    public enum trigger { Draw, Attack, Defend, Ability, Death, HealthAmount, Destroy, Effect }
    [SerializeField]
    trigger PassiveTrigger;
}

