using Godot;

public partial class MoveManager : Node
{
    public EntityAccessor AllySlot { get; private set; }
    public EntityAccessor EnemySlot { get; private set; }

    public override void _Ready()
    {
        var parent = GetParent();
        if (parent is CombatManager combatManager)
        {
            combatManager.TurnStarted += StartTurn;
        }
        GD.Print("MoveManager: Ready");
    }

    public MoveManager(EntityAccessor allySlot, EntityAccessor enemySlot)
    {
        SetAllySlot(allySlot);
        SetEnemySlot(enemySlot);
    }

    public void SetAllySlot(EntityAccessor allySlot)
    {
        if (allySlot == null)
        {
            GD.PrintErr("Cannot set a null AllySlot.");
            return;
        }
        AllySlot = allySlot;
        GD.Print($"CombatManager: AllySlot set to {AllySlot}");
    }

    public void SetEnemySlot(EntityAccessor enemySlot)
    {
        if (enemySlot == null)
        {
            GD.PrintErr("Cannot set a null EnemySlot.");
            return;
        }
        EnemySlot = enemySlot;
        GD.Print($"CombatManager: EnemySlot set to {EnemySlot}");
    }

    public void StartTurn(PlayerSlot entitySlot)
    {
        if (entitySlot == null)
        {
            GD.PrintErr("Cannot start turn for a null PlayerSlot.");
            return;
        }
        // An entity can only be the Allly-Attacker, the Enemy-Attacker or the Ally-Supporter.
        if (entitySlot == AllySlot)
        {
            entitySlot.GetEntity().AttackLogic(EnemySlot.GetEntity());
            GD.Print($"ACombatManager: {AllySlot} attacked {EnemySlot}");
        }
        else if (entitySlot == EnemySlot)
        {
            entitySlot.GetEntity().AttackLogic(AllySlot.GetEntity());
            GD.Print($"BCombatManager: {EnemySlot} attacked {AllySlot}");
        }
        else
        {
            entitySlot.GetEntity().SupportLogic(AllySlot.GetEntity());
            GD.Print($"CCombatManager: {entitySlot} supported {AllySlot}");
        }
    }
}
