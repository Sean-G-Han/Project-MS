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
public partial class Entity : Node2D
{
    [Export]
    public string Name { get; protected set; }
    [Export]
    public EntityType Type { get; protected set; }
    [Export]
    public EntityStat Stats { get; protected set; }
    public Func<Entity, Entity> AttackLogic { get; set; }
    public Func<Entity, Entity> SupportLogic { get; set; }

    public State CurrentState { get; protected set; } = State.Neutral;

    public override void _Ready()
    {
        AttackLogic = (target) => target;
        SupportLogic = (target) => target;
    }

    public Entity() {} 

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
        return $"==> {Name} Stats: {Stats}";
    }
}