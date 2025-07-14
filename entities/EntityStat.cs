using Godot;
public partial class EntityStat
{
    public int Health { get; private set; } = 10;

    public int Speed { get; private set; } = 10;

    public int Attack { get; private set; } = 10;

    public int Defense { get; private set; } = 10;

    public EntityStat(int health, int speed, int attack, int defense)
    {
        Health = health;
        Speed = speed;
        Attack = attack;
        Defense = defense;
    }
    public override string ToString()
    {
        return $"[Health: {Health}, Speed: {Speed}, Attack: {Attack}, Defense: {Defense}]";
    }
}
