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

    public void StartTurn(PlayerSlot entitySlot)
    {
        if (entitySlot == null)
        {
            GD.PrintErr("Cannot start turn for a null PlayerSlot.");
            return;
        }
        // An entity can only be the Ally-Attacker, the Enemy-Attacker or the Ally-Supporter.
        if (entitySlot.Equals(AllySlot))
        {
            var entity = entitySlot.GetEntity();
            if (entity == null)
            {
                GD.PrintErr("AllySlot has no entity set.");
                return;
            }
            EnemySlot.SetEntity(entity.AttackLogic(EnemySlot.GetEntity()));
            GD.Print($"MoveManager: {AllySlot} attacked {EnemySlot}");
        }
        else if (entitySlot.Equals(EnemySlot))
        {
            var entity = entitySlot.GetEntity();
            if (entity == null)
            {
                GD.PrintErr("EnemySlot has no entity set.");
                return;
            }
            AllySlot.SetEntity(entity.AttackLogic(AllySlot.GetEntity()));
            GD.Print($"MoveManager: {EnemySlot} attacked {AllySlot}");
        }
        else
        {
            var entity = entitySlot.GetEntity();
            if (entity == null)
            {
                GD.PrintErr("EntitySlot has no entity set.");
                return;
            }
            AllySlot.SetEntity(entity.SupportLogic(AllySlot.GetEntity()));
            GD.Print($"MoveManager: {entitySlot} supported {AllySlot}");
        }
        GetParent<CombatManager>().EmitSignal("TurnEnded");
    }
}
