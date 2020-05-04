using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



namespace Albatross
{
    public class MonsterObject : MonoBehaviour
    {
        BattleManager bm;
        public bool ownedByPlayer;

        [SerializeField]
        string AttackAnimation = null;

        [SerializeField]
        string CastAnimation = null;

        bool canAct = false;
        bool AbilityTargets = false;

        public Monster thisMonster;
        
        [SerializeField]
        Ability PassiveAbility;

        TypeElement type;

        public float health, attack, mana, defence_value, speed;

        public bool shock_status, rush_status;
        //Shock for nerf speed, rush for buff speed

        SpriteRenderer sr;

        RectTransform rt;

        // Start is called before the first frame update
        void Awake()
        {
            name = thisMonster.name;
            health = thisMonster.health;
            attack = thisMonster.attack;
            defence_value = thisMonster.defence;
            mana = thisMonster.mana;
            speed = thisMonster.speed;
            type = thisMonster.element;
            PassiveAbility = thisMonster.passive;

            bm = FindObjectOfType<BattleManager>();
            rt = GetComponent<RectTransform>();
            sr = GetComponent<SpriteRenderer>();


            PassiveAbility.effect.SetAttatchedEntity(thisMonster);

            PassiveAbility.effect.SetAttatchedCard(this);

            AbilityTargets = PassiveAbility.isTargetAbility;

            if (sr != null)
            {
                sr.sprite = thisMonster.artwork;
            }

        }

        public void hit(GameObject target)
        {
            MonsterObject ownerStats = this.GetComponent<MonsterObject>();
            MonsterObject targetStats = target.GetComponent<MonsterObject>();

            float damage = ownerStats.attack;

            this.GetComponent<Animator>().Play(AttackAnimation);
            targetStats.RecieveDamage(damage);
        }

        public void CastSpellAnimation()
        {
            this.GetComponent<Animator>().Play(CastAnimation);
        }

        public void defend()
        {
            health += defence_value;
            mana -= defence_value * 2;
        }

        public void RecieveDamage(float damage)
        {
            health -= damage;
        }

        void Update()
        {

            if (health < 1)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }

        public void AttackTarget(MonsterObject target)
        {
            thisMonster.Damage(target);
        }

        public void ActivateAbility(MonsterObject target)
        {
            PassiveAbility.Activate(target);
        }
        public void ActivateAbility()
        {
            PassiveAbility.Activate();
        }

        public bool getCanAct()
        {
            return canAct;
        }

        public void setCanAct(bool b)
        {
            canAct = b;
        }
        public bool canTarget()
        {
            return AbilityTargets;
        }
    }
}