using Godot;

public partial class World : Node2D
{
    public override void _Ready()
    {
        GD.Print("World is ready.");

        Entity[] entities = [
            // Example entities, replace with actual Entity creation logic
            new Entity("Player1", EntityType.Hero, new EntityStat(100, 20, 15, 10)),
            new Entity("Player2", EntityType.Hero, new EntityStat(80, 25, 10, 15))
        ];

        TurnManager turnManager = new TurnManager(entities);
        AddChild(turnManager);
    }
}
