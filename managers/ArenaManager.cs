using Godot;

public partial class ArenaManager : Node
{
    public PlayerCarousel PlayerCarousel { get; private set; }
    public PlayerSlot Enemy { get; private set; }
    public TouchController TouchController { get; private set; }

    public bool canSwipe = true;

    public ArenaManager(PlayerCarousel playerCarousel, PlayerSlot enemy)
    {
        PlayerCarousel = playerCarousel;
        Enemy = enemy;
        TouchController = new TouchController();
    }

    public void SetCarousel(EntityNode[] entities)
    {
        if (entities.Length != 5)
        {
            GD.PrintErr("ArenaManager: Expected 5 entities, but got " + entities.Length);
            return;
        }
        Enemy.SetEntityNode(entities[0]);
        PlayerCarousel.SetEntityNodes(entities[1..5]);
    }

    public override void _Ready()
    {
        GD.Print("ArenaManager: Ready");
        GD.Print("ArenaManager: PlayerCarousel is:\n" + PlayerCarousel);
        AddChild(TouchController);
        var parent = GetParent<CombatManager>();
        if (parent != null)
        {
            parent.TurnStarted += (e) => DisableSwipeControls();
            parent.TurnEnded += () => EnableSwipeControls();
        }
        TouchController.SwipeRight += (strength) =>
        {
            if (canSwipe) { TurnClockwise(); }
        };
        TouchController.SwipeLeft += (strength) =>
        {
            if (canSwipe) { TurnCounterClockwise(); }
        };
    }

    public void TurnClockwise()
    {
        GetParent<CombatManager>().EmitSignal("UpdatePlayerSlot", PlayerCarousel.Directions[PlayerCarousel.Down]);
        PlayerCarousel.TurnClockwise();
        GD.Print("ArenaManager: PlayerCarousel has turned RIGHT");
    }

    public void TurnCounterClockwise()
    {
        GetParent<CombatManager>().EmitSignal("UpdatePlayerSlot", PlayerCarousel.Directions[PlayerCarousel.Up]);
        PlayerCarousel.TurnCounterClockwise();
        GD.Print("ArenaManager: PlayerCarousel has turned LEFT");
    }

    public void DisableSwipeControls()
    {
        canSwipe = false;
        GD.Print("ArenaManager: Swipe controls disabled.");
    }

    public void EnableSwipeControls()
    {
        canSwipe = true;
        GD.Print("ArenaManager: Swipe controls enabled.");
    }
}