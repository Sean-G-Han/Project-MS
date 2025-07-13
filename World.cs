using Godot;

public partial class World : Node2D
{
    public override void _Ready()
    {
        GD.Print("World is ready.");
        Character[] character =
        [
            new Character("Elf", CharStat.Create(15, 15, 15, 5)),
            new Character("Human", CharStat.Create( 20, 15, 25, 10)),
            new Character("Dwarf", CharStat.Create(30, 10, 20, 15)),
            new Character("Orc", CharStat.Create(25, 12, 30, 20))
        ];
        TurnManager turnOrderManager = new TurnManager(character);
        AddChild(turnOrderManager);
    }
}
