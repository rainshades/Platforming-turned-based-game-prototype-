using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject
{
    public new string name;

    public Abilities ActiveAbility;
    //public Abilities PassiveAbility;
    
    public string description;

    public int attack;
    public int health;
    public int speed;

    public Sprite artwork;
    public bool alive;

    public void Attack(Monster target)
    {
        target.health -= attack;
    }

    public void OnAfterDeserialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }
}
