using Godot;
using System;

public partial class EntityTurn : RefCounted
{
    public Entity Entity { get; private set; }
    public double TurnProgress { get; set; }
    public int Speed => Entity.Stats.Speed;

    public EntityTurn(Entity entity)
    {
        Entity = entity;
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

    public override string ToString()
    {
        return $"{Entity} (Turn Progress: {TurnProgress})";
    }
}

public partial class TurnManager : Node
{
    public Godot.Collections.Array<EntityTurn> Entities { get; private set; }

    public TurnManager(Entity[] entities)
    {
        Entities = new Godot.Collections.Array<EntityTurn>();
        foreach (var entity in entities)
        {
            Entities.Add(new EntityTurn(entity));
        }
    }

    public override void _Ready()
    {
        SetProcess(true);
        GD.Print("TurnManager: Ready with the following Entities:");
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
                GD.Print($"TurnManager: {charTurn.Entity} is ready to act.");
                charTurn.Entity.ExecuteMove();
                charTurn.ResetTurnProgress();
            }
        }

        Entities.Shuffle();
    }
}
