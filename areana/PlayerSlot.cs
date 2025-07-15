using Godot;
using System;

public partial class PlayerSlot : Node2D
{
    // The player slot can hold a reference to an EntityNode
    public EntityNode EntityNode { get; private set; }
    public void SetEntityNode(EntityNode EntityNode)
    {
        if (EntityNode == null)
        {
            GD.PrintErr("Cannot attach a null EntityNode.");
            return;
        }
        this.EntityNode = EntityNode;

        AddChild(EntityNode);
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
}
