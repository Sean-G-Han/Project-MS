using Godot;

public partial class World : Node2D
{
    public override void _Ready()
    {
        GD.Print("World is ready.");
        Character[] character =
        [
            new Character("Elf", CharStat.Create(15, 15, 15, 5), false),
            new Character("Human", CharStat.Create( 20, 15, 25, 10), false),
            new Character("Dwarf", CharStat.Create(30, 10, 20, 15), false),
            new Character("Orc", CharStat.Create(25, 12, 30, 20), false),
            new Character("Enemy", CharStat.Create(100, 20, 10, 20), true)
        ];
        Global.Instance.SetEnemy(character[4]);
        Global.Instance.SetActiveCharacter(character[0]);
        TurnManager turnOrderManager = new TurnManager(character);
        AddChild(turnOrderManager);
    }
}
