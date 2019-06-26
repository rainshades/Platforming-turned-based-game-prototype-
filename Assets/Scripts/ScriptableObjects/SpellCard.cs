using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SpellCard : ScriptableObject
{
    public new string name;
    public string description;

    Abilities SpellPower;

    public Sprite artwork;

    public bool inHand, canPlay;
}
