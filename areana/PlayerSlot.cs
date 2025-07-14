using Godot;
using System;

public partial class PlayerSlot : Node2D
{
    private Entity _entity;
    public override void _Ready()
    {
        _entity = GetNode<Entity>("Entity");
        if (_entity == null)
        {
            GD.PrintErr("PlayerSlot: Entity node not found.");
        }
        else
        {
            GD.Print($"PlayerSlot: Ready with entity {_entity.Name}");
        }
    }
}
