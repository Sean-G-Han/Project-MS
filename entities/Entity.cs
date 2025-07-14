using Godot;
using System;

public enum EntityType
{
    Hero,
    Enemy
}

public enum State 
{
    Attacking,
    Supporting,
    Neutral,
    Dead
}
public class Entity
{
    public string Name { get; protected set; }
    public EntityType Type { get; protected set; }
    public EntityStat Stats { get; protected set; }
    public Func<Entity, Entity> AttackLogic { get; set; }
    public Func<Entity, Entity> SupportLogic { get; set; }

    public State CurrentState { get; protected set; } = State.Neutral;

    public Entity(string name, EntityType type, EntityStat stats)
    {
        Name = name;
        Type = type;
        Stats = stats;
        AttackLogic = (target) => { return target; };
        SupportLogic = (target) => { return target; };
    }

    public virtual void ExecuteMove()
    {
        GD.PrintErr($"{Name} has no specific move logic defined.");
    }

    public void SetState(State newState)
    {
        CurrentState = newState;
    }
    public override string ToString()
    {
        return $"[{Name} Stats: {Stats}]";
    }
}