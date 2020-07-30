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

        public CardAbility SpellEffect;

        public int cost;

        public string description;

        public Sprite artwork;

        public bool inHand, canPlay;



    }
}