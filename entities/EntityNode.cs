using System;
using System.Threading.Tasks;
using Godot;

public partial class EntityNode : Node2D, EntityAccessor<EntityNode>
{
    public Entity Entity { get; protected set; }

    public Animator Animator { get; private set; }

    public RichTextLabel StatsDisplay;

    public override void _Ready()
    {
        StatsDisplay = GetNode<RichTextLabel>("StatsDisplay");
        UpdateText();
    }

    public void UpdateText()
    {
        GD.Print("Updating EntityNode text.");
        if (StatsDisplay == null)
        {
            GD.PrintErr("StatsDisplay is not set in EntityNode.");
            return;
        }
        if (Entity == null)
        {
            StatsDisplay.Text = "No Entity set.";
            return;
        }
        StatsDisplay.Text = Entity.ToString();
    }

    public void SetEntity(Entity entity)
    {
        if (entity == null)
        {
            GD.PrintErr("Cannot set a null Entity.");
            return;
        }
        Entity = entity;
    }

    public Entity GetEntity()
    {
        if (Entity == null)
        {
            GD.PrintErr("No Entity is set in this EntityNode.");
            return null;
        }
        return Entity;
    }

    public void SetAnimator(Animator animator)
    {
        if (animator == null)
        {
            GD.PrintErr("Cannot set a null Animator.");
            return;
        }
        AddChild(animator);
        Animator = animator;
    }

    public async Task Attack(EntityNode enemy)
    {
        var animationEndedAwaiter = ToSignal(Animator, "AnimationEnded");
        Animator.PlayAttackAnimation();
        await animationEndedAwaiter;
        enemy.SetEntity(Entity.AttackLogic(enemy.Entity));
        enemy.UpdateText();
    }

    public async Task Support(EntityNode ally)
    {
        var animationEndedAwaiter = ToSignal(Animator, "AnimationEnded");
        Animator.PlaySupportAnimation();
        await animationEndedAwaiter;
        ally.SetEntity(Entity.SupportLogic(ally.Entity));
        ally.UpdateText();
    }

    public int GetSpeed()
    {
        return Entity?.GetSpeed() ?? 0;
    }

    public override string ToString()
    {
        if (Entity == null)
        {
            return "EntityNode->NULL";
        }
        return Entity.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj is EntityNode otherEntity)
        {
            return Entity.Equals(otherEntity.Entity);
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Entity);
    }
}
