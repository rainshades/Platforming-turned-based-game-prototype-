namespace Albatross
{
    public enum ObsticalType { Animal, Human, Object, Bullet}
    public enum TargetType { Self, EnemyMonster, AllyMonster, EnemySpell, AllySpell, MultiEnemy, MultiAlly, MultiEnemySpells, MultiAllySpells, NoTarget }
    public enum CastType { Slow, Quick, Equipment, NoCast }
    public enum EffectType { Heal, HealPercentage, Damage, DamagePercentage, Negate, Destroy, Stun, BuffStat, NerfStat, StatSwap, ModifyStat, SwapAlignment, NoEffect }
    public enum StatSwaps { AttackSwap, DefenseSwap, SpeedSwap, ManaSwap, HealthSwap, NoSwap}
    public enum Trigger { SpellCast, AllyDraw, AllyAttack, AllyDefend, AllyAbility, AllyDeath, AllyHealthAmount, AllyDestroy, AllyElement, AllyCast, EnemyDraw, 
        EnemyAttack, EnemyDefend, EnemyAbility, EnemyDeath, EnemyHealthAmount, EnemyDestroy, EnemyElement, EnemyCast,
        Draw, Attack, Defend, Ability, Death, HealthAmount, Destroy, Element, Effect, StartPhase, MainPhase, EndPhase, NoTrigger }

    public enum TypeElement
    {
        Order,
        Light,
        Chaos,
        Dark,
        NoElement
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