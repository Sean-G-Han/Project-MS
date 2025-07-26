using Godot;

public partial class CombatManager : Node
{
    [Signal]
    public delegate void TurnStartedEventHandler(PlayerSlot entitySlot);
    [Signal]
    public delegate void TurnEndedEventHandler();
    [Signal]
    public delegate void UpdatePlayerSlotEventHandler(PlayerSlot heroSlot);
    public TurnManager TurnManager { get; private set; }
    public MoveManager MoveManager { get; private set; }
    public ArenaManager ArenaManager { get; private set; }

    public override void _Ready()
    {
        GD.Print("CombatManager: Ready");
    }

    public CombatManager(Entity[] entities, PlayerCarousel playerCarousel, PlayerSlot enemy)
    {
        if (entities.Length != 5)
        {
            GD.PrintErr("CombatManager: Expected 5 entities, but got " + entities.Length);
            return;
        }
        ArenaManager = new ArenaManager(playerCarousel, enemy);
        ArenaManager.SetEntities(entities);
        AddChild(ArenaManager);

        // Combine player slots with enemy slot
        PlayerSlot[] playerSlots = playerCarousel.GetPlayerSlots();
        var allPlayers = new PlayerSlot[5];
        allPlayers[0] = enemy;
        playerSlots.CopyTo(allPlayers, 1);

        // Initialize TurnManager
        TurnManager = new TurnManager(allPlayers);
        AddChild(TurnManager);

        // Initialize MoveManager
        MoveManager = new MoveManager();
        MoveManager.SetEnemySlot(allPlayers[0]);
        MoveManager.SetAllySlot(allPlayers[3]);
        AddChild(MoveManager);
    }
}
