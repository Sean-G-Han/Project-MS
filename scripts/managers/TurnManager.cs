using Godot;
using System;

public partial class CharTurn : RefCounted
{
    public Character Character { get; private set; }
    public double TurnProgress { get; set; }
    public int Speed => Character.Stats.Speed;

    public CharTurn(Character character)
    {
        Character = character;
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
        return $"{Character} (Turn Progress: {TurnProgress})";
    }
}

public partial class TurnManager : Node
{
    public Godot.Collections.Array<CharTurn> Characters { get; private set; }

    public TurnManager(Character[] characters)
    {
        Characters = new Godot.Collections.Array<CharTurn>();
        foreach (var character in characters)
        {
            Characters.Add(new CharTurn(character));
        }
    }

    public override void _Ready()
    {
        SetProcess(true);
        GD.Print("TurnManager is ready with the following characters:");
    }

    public override void _Process(double delta)
    {
        if (Characters.Count == 0)
        {
            GD.PrintErr("No characters in turn manager.");
            return;
        }

        for (int i = 0; i < Characters.Count; i++)
        {
            var charTurn = Characters[i];
            if (charTurn.UpdateTurnProgress(delta))
            {
                GD.Print($"{charTurn.Character.Species} is ready to act.");
                charTurn.Character.ExecuteMove();
                charTurn.ResetTurnProgress();
            }
        }

        Characters.Shuffle();
    }
}
