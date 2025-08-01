using Godot;

public partial class World : Node2D
{
    public override void _Ready()
    {
        GD.Print("World is ready.");

        PlayerCarousel playerCarousel = GetNode<PlayerCarousel>("PlayerCarousel");
        PlayerSlot enemySlot = GetNode<PlayerSlot>("EnemySlot");

        EntityNode[] entities = [
            Orc.Create(),
            Goblin.Create(),
            Goblin.Create(),
            Goblin.Create(),
            Goblin.Create(),
        ];

        CombatManager combatManager = new CombatManager(entities, playerCarousel, enemySlot);
        AddChild(combatManager);

        /*
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
        */
    }
}
