using Godot;
using System;


public partial class PlayerSlot : Node2D, EntityAccessor<PlayerSlot>
{
    // The player slot can hold a reference to an EntityNode
    public EntityNode EntityNode { get; private set; }
    public override void _Ready()
    {
        SetEntityNode(GetNodeOrNull<EntityNode>("EntityNode"));
    }

    public void SetEntityNode(EntityNode EntityNode)
    {
        if (EntityNode == null)
        {
            GD.PrintErr("Cannot attach a null EntityNode.");
            return;
        }
        this.EntityNode = EntityNode;
    }

    public void SetEntity(Entity entity)
    {
        if (EntityNode == null)
        {
            GD.PrintErr("Cannot set Entity on a null EntityNode.");
            return;
        }
        EntityNode.SetEntity(entity);
    }

    public Entity GetEntity()
    {
        if (EntityNode == null)
        {
            GD.PrintErr("No EntityNode is set in this PlayerSlot.");
            return null;
        }
        return EntityNode.GetEntity();
    }

    public void Attack(PlayerSlot entity)
    {
        EntityNode.Attack(entity.EntityNode);
    }

    public void Support(PlayerSlot entity)
    {
        EntityNode.Support(entity.EntityNode);
    }

    public int GetSpeed()
    {
        return EntityNode?.GetSpeed() ?? 0;
    }

    public override string ToString()
    {
        if (EntityNode == null)
        {
            return "PlayerSlot->NULL";
        }
        return EntityNode.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj is PlayerSlot otherSlot)
        {
            return EntityNode.Equals(otherSlot.EntityNode);
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(EntityNode);
    }
}
