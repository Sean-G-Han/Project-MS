using System;
using Godot;

public partial class EntityNode : Node2D, EntityAccessor<EntityNode>
{
    public Entity Entity { get; protected set; }

    public RichTextLabel StatsDisplay;

    public override void _Ready()
    {
        StatsDisplay = GetNode<RichTextLabel>("StatsDisplay");
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
        UpdateText();
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

    public void Attack(EntityNode enemy)
    {
        enemy.SetEntity(Entity.AttackLogic(enemy.Entity));
    }

    public void Support(EntityNode ally)
    {
        ally.SetEntity(Entity.SupportLogic(ally.Entity));
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
