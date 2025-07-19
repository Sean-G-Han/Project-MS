using Godot;

public partial class World : Node2D
{
    public override void _Ready()
    {
        GD.Print("World is ready.");

        Entity[] entityScripts = [
            new Elf(),
            new Orc(),
        ];

        PlayerSlot[] entities = new PlayerSlot[GetChildCount()];

        for (int i = 0; i < GetChildCount(); i++)
        {
            entities[i] = (PlayerSlot)GetChild(i);
            entities[i].SetEntity(entityScripts[i]);
        }

        CombatManager combatManager = new CombatManager(entities);
        AddChild(combatManager);
    }
}
