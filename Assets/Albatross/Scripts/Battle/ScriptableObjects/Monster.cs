using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Albatross
{

    [CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
    public class Monster : Entity
    {
        public new string name;

        public CardAbility passive;

        public string description;

        public int attack;
        public int health;
        public int defence;
        public int mana; 
        public int speed;

        public Sprite artwork;
        public bool alive;
    }
}