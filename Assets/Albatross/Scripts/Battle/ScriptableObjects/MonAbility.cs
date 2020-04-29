using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{

    public enum trigger { Draw, Attack, Defend, Ability, Death, HealthAmount, Destroy, Effect, NoTrigger }

    [CreateAssetMenu(fileName ="New Monster Ability",menuName = "Monster Ability")]
    public class MonAbility : Ability
    {

        [SerializeField]
        trigger PassiveTrigger;
                          
    }
}