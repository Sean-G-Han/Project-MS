using System;
using Godot;

public partial class EntityNode : Node2D, EntityAccessor
{
    public Entity Entity { get; protected set; }
    public EntityNode()
    {
        // Keep Godot Happy
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
