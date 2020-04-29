using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Albatross {


    public class SpellEffect : Ability
    {
        public enum CastType { Slow, Quick, Equipment }

    }

}
namespace Albatross {
    [CreateAssetMenu(fileName = "New Slow Effect", menuName = "Slow Spell Effect")]
    public class SlowSpell : SpellEffect
    {
        public CastType thisCastType = CastType.Slow;

        [SerializeField]
        trigger CastCondition = trigger.NoTrigger; 

        public trigger GetCastCondition()
        {
            return CastCondition;
        }
    }
}

namespace Albatross
{
    [CreateAssetMenu(fileName = "New Quick Effect", menuName = "Quick Spell Effect")]
    public class QuickSpell : SpellEffect
    {
        public CastType thisCastType = CastType.Quick;
        [SerializeField]
        trigger Trigger = trigger.NoTrigger;

        public trigger GetTrigger()
        {
            return Trigger;
        }
    }
}

namespace Albatross
{
    [CreateAssetMenu(fileName = "New Equipment Effect", menuName = "Equipment Spell Effect")]
    public class EquipmentSpell : SpellEffect
    {
        public CastType thisCastType = CastType.Equipment;

        [SerializeField]
        trigger ActiveTrigger = trigger.NoTrigger;
        [SerializeField]
        trigger PassiveTrigger = trigger.NoTrigger; 


        
        /// <returns>
        /// Equipment can have either Passive Triggers or Be activated depending on the effect of the card. 
        /// Get Trigger returns Both into a List
        /// If the list has a count of two the the Passive Trigger will always come second
        /// </returns>
        public List<trigger> GetTrigger()
        {
            List<trigger> triggers = new List<trigger>();

            if(ActiveTrigger != trigger.NoTrigger)
            {
                triggers.Add(ActiveTrigger);
            }
            if(PassiveTrigger != trigger.NoTrigger)
            {
                triggers.Add(PassiveTrigger);
            }

            return triggers;
        }
    }
}