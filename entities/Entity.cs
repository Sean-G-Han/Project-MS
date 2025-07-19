using Godot;
using System;

public enum EntityType
{
    Hero,
    Enemy
}
public class Entity : IReadableSpeed
{
    public string Name { get; protected set; }
    public EntityType Type { get; protected set; }
    public EntityStat Stats { get; protected set; }
    public Func<Entity, Entity> AttackLogic { get; set; }
    public Func<Entity, Entity> SupportLogic { get; set; }

    public Entity(string name, EntityType type, EntityStat stats)
    {
        Name = name;
        Type = type;
        Stats = stats;
        AttackLogic = (target) => { return target; };
        SupportLogic = (target) => { return target; };
    }
    
    public override string ToString()
    {
        return $"Entity {Name}->Stats {Stats}]";
    }
    public int GetSpeed()
    {
        return Stats.Speed;
    }
}