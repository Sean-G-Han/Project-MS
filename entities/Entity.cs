using System;

public class Entity : EntityAccessor
{
    public string Name { get; set; }
    public EntityStat Stats { get; set; }
    public Action<Entity> AttackLogic { get; set; } = entity => { };
    public Action<Entity> SupportLogic { get; set; } = entity => { };

    public Entity(string name, EntityStat stats)
    {
        Name = name;
        Stats = stats;
    }

    public Entity GetEntity()
    {
        return this;
    }

    public void SetEntity(Entity entity)
    {
        Name = entity.Name;
        Stats = entity.Stats;
        AttackLogic = entity.AttackLogic;
        SupportLogic = entity.SupportLogic;
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