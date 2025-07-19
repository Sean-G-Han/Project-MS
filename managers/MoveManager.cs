using Godot;

public partial class MoveManager : Node
{
    public PlayerSlot AllySlot { get; private set; }
    public PlayerSlot EnemySlot { get; private set; }

    public override void _Ready()
    {
        GD.Print("CombatManager: Ready");
    }

    public MoveManager(IReadableSpeed allySlot = null, IReadableSpeed enemySlot = null)
    {
        SetAllySlot(allySlot);
        SetEnemySlot(enemySlot);
    }

    public void SetAllySlot(PlayerSlot allySlot)
    {
        if (allySlot == null)
        {
            GD.PrintErr("Cannot set a null AllySlot.");
            return;
        }
        AllySlot = allySlot;
        GD.Print($"CombatManager: AllySlot set to {AllySlot}");
    }

    public void SetEnemySlot(PlayerSlot enemySlot)
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
            EnemySlot.SetEntity(AllySlot.GetEntity().AttackLogic(EnemySlot.GetEntity()));
        }
        else if (entitySlot == EnemySlot)
        {
            EnemySlot.SetEntity(EnemySlot.GetEntity().AttackLogic(AllySlot.GetEntity()));
        }
        else
        {
            AllySlot.SetEntity(AllySlot.GetEntity().SupportLogic(AllySlot.GetEntity()));
        }
    }
}
