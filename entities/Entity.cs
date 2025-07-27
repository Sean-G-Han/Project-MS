using System;
using Godot;

public class Entity
{
    public delegate void EntityUpdatedEventHandler();
    public string Name { get; set; }
    public EntityStat Stats { get; set; }
    public Func<Entity, Entity> AttackLogic { get; set; } = entity => { return entity; };
    public Func<Entity, Entity> SupportLogic { get; set; } = entity => { return entity; };

    public Entity(string name, EntityStat stats)
    {
        Name = name;
        Stats = stats;
    }

    public override string ToString()
    {
        return $"{Name} {Stats}";
    }

    public int GetSpeed()
    {
        return Stats.Speed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Entity otherEntity)
        {
            return Name == otherEntity.Name && Stats.Equals(otherEntity.Stats);
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Stats);
    }
}