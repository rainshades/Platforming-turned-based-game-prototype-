namespace Albatross
{
    public enum TargetType { Self, EnemyMonster, AllyMonster, EnemySpell, AllySpell, NoTarget }
    public enum CastType { Slow, Quick, Equipment }
    public enum EffectType { Heal, HealPercentage, Damage, DamagePercentage, Negate, Destroy, Stun, BuffStat, NerfStat, StatSwap, ModifyStat, SwapAlignment }
    public enum StatSwaps { AttackSwap, DefenseSwap, SpeedSwap, ManaSwap, HealthSwap, 
                            AttackForDefense, AttackForSpeed,AttackForMana,AttackForHealth,
                            DefenseForAttack, DefenseForSpeed, DefenseForMana, DefenseForHealth,
                            SpeedForAttack, SpeedForDefense, SpeedForMana, SpeedForHealth,
                            ManaForAttack, ManaForDefense, ManaForSpeed, ManaForHealth,
                            HealthForAttack, HealthForDefense,HealthForSpeed, HealthForMana}
    public enum Trigger { Quick, AllyDraw, AllyAttack, AllyDefend, AllyAbility, AllyDeath, AllyHealthAmount, AllyDestroy, AllyElement, AllyEffect, EnemyDraw, 
        EnemyAttack, EnemyDefend, EnemyAbility, EnemyDeath, EnemyHealthAmount, EnemyDestroy, EnemyElement, EnemyEffect,
        Draw, Attack, Defend, Ability, Death, HealthAmount, Destroy, Element, Effect, NoTrigger }

    public enum TypeElement
    {
        Order,
        Light,
        Chaos,
        Dark
    }

    public enum Action
    {
        Attack,
        ActiveAbility,
        PassiveAbility,
        Cast,
        Defend
    }

    public enum Direction { North, South, East, West }

    public enum NPCTYPE { Neutral, Hostile, Friendly }

    public enum Phases { Start, Main, End}
}