using System.Linq;
using System.Numerics;
using Godot;

public partial class PlayerCarousel : Node2D
{
    /**
     * PlayerCarousel is a Node2D that manages the positions of PlayerSlots in a carousel-like manner.
     * It allows for clockwise and counter-clockwise rotations of the player slots.
     * Turns are buffered to ensure smooth transitions.
     */

    Godot.Vector2 Left = new Godot.Vector2(-192, 0);
    Godot.Vector2 Up = new Godot.Vector2(0, -128);
    Godot.Vector2 Right = new Godot.Vector2(192, 0);
    Godot.Vector2 Down = new Godot.Vector2(0, 128);
    int NumberOfCWTurns = 0;
    public Godot.Collections.Dictionary<Godot.Vector2, PlayerSlot> Directions;

    public override void _Ready()
    {
        Directions = new Godot.Collections.Dictionary<Godot.Vector2, PlayerSlot>
        {
            { Left, GetChild<PlayerSlot>(0) },
            { Up, GetChild<PlayerSlot>(1) },
            { Right, GetChild<PlayerSlot>(2) },
            { Down, GetChild<PlayerSlot>(3) }
        };
    }

    private void Turn()
    {
        if (NumberOfCWTurns > 0)
        {
            var temp = Directions[Left];
            Directions[Left] = Directions[Up];
            Directions[Up] = Directions[Right];
            Directions[Right] = Directions[Down];
            Directions[Down] = temp;
            UpdatePlayerSlots();
        }
        else if (NumberOfCWTurns < 0)
        {
            var temp = Directions[Left];
            Directions[Left] = Directions[Down];
            Directions[Down] = Directions[Right];
            Directions[Right] = Directions[Up];
            Directions[Up] = temp;
            UpdatePlayerSlots();
        }
    }

    public void TurnClockwise()
    {
        if (NumberOfCWTurns == 0)
        {
            NumberOfCWTurns++;
            Turn();
            return;
        }
        NumberOfCWTurns++;
    }

    public void TurnCounterClockwise()
    {
        if (NumberOfCWTurns == 0)
        {
            NumberOfCWTurns--;
            Turn();
            return;
        }
        NumberOfCWTurns--;
    }

    public void UpdatePlayerSlots()
    {
        int signalCount = 0;
        GD.Print("PlayerCarousel: " + NumberOfCWTurns);
        for (int i = 0; i < Directions.Count; i++)
        {
            Tween tween = CreateTween();
            var key = Directions.Keys.ElementAt(i);
            tween.TweenProperty(Directions[key], "position", key, 0.2f);
            tween.Finished += () =>
            {
                signalCount++;
                if (signalCount < 4) // wait for all 4 tweens to finish
                    return;
                if (NumberOfCWTurns > 0)
                    NumberOfCWTurns--;
                else if (NumberOfCWTurns < 0)
                    NumberOfCWTurns++;
                Turn();
            };
        }
    }
}