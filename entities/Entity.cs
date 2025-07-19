using Godot;
using System;

public class Entity : EntityAccessor
{
    public string Name { get; set; }
    public EntityStat Stats { get; set; }
    public Action<Entity> AttackLogic { get; set; }
    public Action<Entity> SupportLogic { get; set; }

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
        return $"Entity {Name}->Stats {Stats}]";
    }

    public int GetSpeed()
    {
        return Stats.Speed;
    }
}