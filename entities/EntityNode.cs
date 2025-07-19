using Godot;

public partial class EntityNode : Node2D, IReadableSpeed, IEntityAccessor
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
        return "EntityNode->" + Entity.ToString();
    }
}
