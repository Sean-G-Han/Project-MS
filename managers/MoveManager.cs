using Godot;

public partial class MoveManager : Node
{
    public EntityAccessor AllySlot { get; private set; }
    public EntityAccessor EnemySlot { get; private set; }

    public override void _Ready()
    {
        var parent = GetParent<CombatManager>();
        if (parent != null)
        {
            parent.TurnStarted += StartTurn;
        }
        GD.Print("MoveManager: Ready");
        GetParent<CombatManager>().UpdatePlayerSlot += SetAllySlot;
    }

    public void SetAllySlot(EntityAccessor allySlot)
    {
        if (allySlot == null)
        {
            GD.PrintErr("Cannot set a null AllySlot.");
            return;
        }
        AllySlot = allySlot;
        GD.Print($"MoveManager: AllySlot set to {AllySlot}");
    }

    public void SetEnemySlot(EntityAccessor enemySlot)
    {
        if (enemySlot == null)
        {
            GD.PrintErr("Cannot set a null EnemySlot.");
            return;
        }
        EnemySlot = enemySlot;
        GD.Print($"MoveManager: EnemySlot set to {EnemySlot}");
    }

    public async void StartTurn(PlayerSlot entitySlot)
    {
        if (entitySlot == null)
        {
            GD.PrintErr("Cannot start turn for a null PlayerSlot.");
            return;
        }
        // An entity can only be the Ally-Attacker, the Enemy-Attacker or the Ally-Supporter.
        if (entitySlot.Equals(AllySlot))
        {
            await entitySlot.Attack((PlayerSlot)EnemySlot);
            GD.Print($"MoveManager: {AllySlot} attacked {EnemySlot}");
        }
        else if (entitySlot.Equals(EnemySlot))
        {
            await entitySlot.Attack((PlayerSlot) AllySlot);
            GD.Print($"MoveManager: {EnemySlot} attacked {AllySlot}");
        }
        else
        {
            await entitySlot.Support((PlayerSlot) AllySlot);
            GD.Print($"MoveManager: {entitySlot} supported {AllySlot}");
        }
        GetParent<CombatManager>().EmitSignal("TurnEnded");
    }
}
