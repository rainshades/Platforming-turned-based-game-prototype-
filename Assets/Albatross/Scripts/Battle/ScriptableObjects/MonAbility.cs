using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    [CreateAssetMenu(fileName ="New Monster Ability",menuName = "Monster Ability")]
    public class MonAbility : Ability
    {

        [SerializeField]
        Trigger PassiveTrigger;
                          
    }
}