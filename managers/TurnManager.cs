using Godot;

public partial class EntityTurn : RefCounted
{
    public EntityAccessor E { get; private set; }
    public double TurnProgress { get; set; }
    public int Speed => E?.GetSpeed() ?? 0;

    public EntityTurn(EntityAccessor entity)
    {
        E = entity;
        TurnProgress = 0.0;
    }

    public bool UpdateTurnProgress(double delta)
    {
        TurnProgress += delta * Speed;
        return TurnProgress >= 100.0;
    }

    public void ResetTurnProgress()
    {
        TurnProgress = 0.0;
    }
}

public partial class TurnManager : Node
{
    public Godot.Collections.Array<EntityTurn> Entities { get; private set; }

    public TurnManager(EntityAccessor[] entities)
    {
        Entities = new Godot.Collections.Array<EntityTurn>();
        foreach (var entity in entities)
        {
            Entities.Add(new EntityTurn(entity));
            GD.Print($"TurnManager: Added {entity}");
        }
    }

    public override void _Ready()
    {
        SetProcess(true);
        GD.Print("TurnManager: Ready");
    }

    public override void _Process(double delta)
    {
        if (Entities.Count == 0)
        {
            GD.PrintErr("No Entities in turn manager.");
            return;
        }

        for (int i = 0; i < Entities.Count; i++)
        {
            var charTurn = Entities[i];
            if (charTurn.UpdateTurnProgress(delta))
            {
                GD.Print($"TurnManager: {charTurn.E} is ready to act.");
                GetParent<CombatManager>().EmitSignal("TurnStarted", (PlayerSlot) charTurn.E);
                charTurn.ResetTurnProgress();
            }
        }

        Entities.Shuffle();
    }

}
