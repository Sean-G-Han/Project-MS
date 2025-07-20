using Godot;

public partial class ArenaManager : Node
{
    public PlayerCarousel PlayerCarousel { get; private set; }
    public PlayerSlot Enemy { get; private set; }
    public TouchController TouchController { get; private set; }

    public ArenaManager(PlayerCarousel playerCarousel, PlayerSlot enemy)
    {
        PlayerCarousel = playerCarousel;
        Enemy = enemy;
        TouchController = new TouchController();
    }

    public void SetEntities(Entity[] entities)
    {
        if (entities.Length != 5)
        {
            GD.PrintErr("ArenaManager: Expected 5 entities, but got " + entities.Length);
            return;
        }
        Enemy.SetEntity(entities[0]);
        PlayerCarousel.SetEntities(entities[1..5]);
    }

    public override void _Ready()
    {
        GD.Print("ArenaManager: Ready");
        GD.Print("ArenaManager: PlayerCarousel is:\n" + PlayerCarousel);
        AddChild(TouchController);
        TouchController.SwipeRight += (strength) => TurnClockwise();
        TouchController.SwipeLeft += (strength) => TurnCounterClockwise();
    }

    public void TurnClockwise()
    {
        PlayerCarousel.TurnClockwise();
    }

    public void TurnCounterClockwise()
    {
        PlayerCarousel.TurnCounterClockwise();
    }
}