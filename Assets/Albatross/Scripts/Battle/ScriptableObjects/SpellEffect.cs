using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Albatross {


    public class SpellEffect : Ability
    {

    }

}
namespace Albatross {
    [CreateAssetMenu(fileName = "New Slow Effect", menuName = "Slow Spell Effect")]
    public class SlowSpell : SpellEffect
    {
        public CastType thisCastType = CastType.Slow;

        [SerializeField]
        List<Trigger> CastCondition; 

        public List<Trigger> GetCastCondition()
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
        List<Trigger> Trigger;

        public List<Trigger> GetTrigger()
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
        Trigger ActiveTrigger = Trigger.NoTrigger;
        [SerializeField]
        Trigger PassiveTrigger = Trigger.NoTrigger; 


        
        /// <returns>
        /// Equipment can have either Passive Triggers or Be activated depending on the effect of the card. 
        /// Get Trigger returns Both into a List
        /// If the list has a count of two the the Passive Trigger will always come second
        /// </returns>
        public List<Trigger> GetTrigger()
        {
            List<Trigger> triggers = new List<Trigger>();

            if(ActiveTrigger != Trigger.NoTrigger)
            {
                triggers.Add(ActiveTrigger);
            }
            if(PassiveTrigger != Trigger.NoTrigger)
            {
                triggers.Add(PassiveTrigger);
            }

            return triggers;
        }
    }
}