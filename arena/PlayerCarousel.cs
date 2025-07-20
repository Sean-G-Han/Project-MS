using System.Linq;
using Godot;

public partial class PlayerCarousel : Node2D
{
    /**
     * PlayerCarousel is a Node2D that manages the positions of PlayerSlots in a carousel-like manner.
     * It allows for clockwise and counter-clockwise rotations of the player slots.
     * Turns are buffered to ensure smooth transitions.
     */

    Vector2 Left = new Vector2(-192, 0);
    Vector2 Up = new Vector2(0, -128);
    Vector2 Right = new Vector2(192, 0);
    Vector2 Down = new Vector2(0, 128);
    int NumberOfCWTurns = 0;
    public Godot.Collections.Dictionary<Vector2, PlayerSlot> Directions;

    public override void _Ready()
    {
        Directions = new Godot.Collections.Dictionary<Vector2, PlayerSlot>
        {
            { Left, GetChild<PlayerSlot>(0) },
            { Up, GetChild<PlayerSlot>(1) },
            { Right, GetChild<PlayerSlot>(2) },
            { Down, GetChild<PlayerSlot>(3) }
        };
        for (int i = 0; i < Directions.Count; i++)
        {
            var key = Directions.Keys.ElementAt(i);
            Directions[key].Position = key;
        }
    }

    public void SetEntities(Entity[] entities)
    {
        if (entities.Length != 4)
        {
            GD.PrintErr("PlayerCarousel: Expected 4 entities, but got " + entities.Length);
            return;
        }

        for (int i = 0; i < Directions.Count; i++)
        {
            var key = Directions.Keys.ElementAt(i);
            Directions[key].SetEntity(entities[i].GetEntity());
        }
    }

    public PlayerSlot[] GetPlayerSlots()
    {
        return Directions.Values.ToArray();
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
        for (int i = 0; i < Directions.Count; i++)
        {
            Tween tween = CreateTween();
            var key = Directions.Keys.ElementAt(i);
            tween.TweenProperty(Directions[key], "position", key, 0.15f);
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

    public override string ToString()
    {
        return "=> " + string.Join(",\n=> ", Directions.Select(kv => $"{kv.Key}: {kv.Value}"));
    }
}