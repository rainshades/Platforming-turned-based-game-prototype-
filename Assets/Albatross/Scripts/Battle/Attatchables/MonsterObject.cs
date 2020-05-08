using UnityEngine;

/// <summary>
/// A container class for the Monster Scriptable Object to be used in the Scenes
/// Used in Deck Creation and Battles
/// </summary>
namespace Albatross
{
    public class MonsterObject : MonoBehaviour
    {
        BattleManager bm;
        public bool OwnedByPlayer;

        [SerializeField]
        string AttackAnimation = null;

        [SerializeField]
        string CastAnimation = null;

        public TypeElement element;

        bool CanAct = false;
        bool AbilityTargets = false;

        public Monster ThisMonster;
        
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
            name = ThisMonster.name;
            health = ThisMonster.health;
            attack = ThisMonster.attack;
            defence_value = ThisMonster.defence;
            mana = ThisMonster.mana;
            speed = ThisMonster.speed;
            type = ThisMonster.element;
            PassiveAbility = ThisMonster.passive;

            bm = FindObjectOfType<BattleManager>();
            rt = GetComponent<RectTransform>();
            sr = GetComponent<SpriteRenderer>();


            PassiveAbility.Effect.SetAttatchedEntity(ThisMonster);

            PassiveAbility.Effect.SetAttatchedCard(this);

            AbilityTargets = PassiveAbility.IsTargetAbility;

            if (sr != null)
            {
                sr.sprite = ThisMonster.artwork;
            }

        }

        public void Hit(GameObject target)
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

        public void Defend()
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
            ThisMonster.Damage(target);
        }

        public void ActivateAbility(MonsterObject target)
        {
            PassiveAbility.Activate(target);
        }
        public void ActivateAbility()
        {
            PassiveAbility.Activate();
        }

        public bool GetCanAct()
        {
            return CanAct;
        }

        public void SetCanAct(bool b)
        {
            CanAct = b;
        }
        public bool CanTarget()
        {
            return AbilityTargets;
        }
    }
}