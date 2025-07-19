using Godot;

public partial class CombatManager : Node
{
    public TurnManager TurnManager { get; private set; }
    public MoveManager MoveManager { get; private set; }

    public override void _Ready()
    {
        GD.Print("CombatManager: Ready");
    }

    public void SetCharacters(IReadableSpeed[] entities)
    {
        TurnManager = new TurnManager(entities);
        AddChild(TurnManager);
        MoveManager = new MoveManager();
    }
}
