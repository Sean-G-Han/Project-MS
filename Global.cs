using Godot;
using System;

public partial class Global : Node
{
    public static Global Instance { get; private set; }

    public Character ActiveCharacter { get; set; }
    public Character Enemy { get; set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public void SetActiveCharacter(Character character)
    {
        ActiveCharacter = character;
    }
    public void SetEnemy(Character enemy)
    {
        Enemy = enemy;
    }
}
