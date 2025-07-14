using Godot;

[GlobalClass]
public partial class EntityStat : Resource
{

    [Export]
    public int Health { get; private set; } = 10;

    [Export]
    public int Speed { get; private set; } = 10;

    [Export]
    public int Attack { get; private set; } = 10;

    [Export]
    public int Defense { get; private set; } = 10;
}
