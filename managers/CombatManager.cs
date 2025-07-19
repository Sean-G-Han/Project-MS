using Godot;

public partial class CombatManager : Node
{
    [Signal]
    public delegate void TurnStartedEventHandler(PlayerSlot entitySlot);
    public TurnManager TurnManager { get; private set; }
    public MoveManager MoveManager { get; private set; }

    public override void _Ready()
    {
        GD.Print("CombatManager: Ready");
    }

    public CombatManager(EntityAccessor[] entities)
    {
        TurnManager = new TurnManager(entities);
        AddChild(TurnManager);
        MoveManager = new MoveManager(entities[0], entities[1]);
        AddChild(MoveManager);
    }
}
