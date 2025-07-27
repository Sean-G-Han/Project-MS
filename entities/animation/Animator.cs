using Godot;
using System;

public partial class Animator : Node2D
{
    public AnimationPlayer animPlayer;
    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        if (!animPlayer.HasAnimation("Attack"))
        {
            GD.PrintErr("Animator: AnimationPlayer does not have 'Attack' animation.");
            return;
        }
        if (!animPlayer.HasAnimation("Idle"))
        {
            GD.PrintErr("Animator: AnimationPlayer does not have 'Idle' animation.");
            return;
        }
        if (!animPlayer.HasAnimation("Support"))
        {
            GD.PrintErr("Animator: AnimationPlayer does not have 'Support' animation.");
            return;
        }
    }

    public void PlayAttackAnimation()
    {
        if (animPlayer == null)
        {
            GD.PrintErr("Animator: AnimationPlayer node not found.");
            return;
        }
        animPlayer.Play("Attack");
    }

    public void PlayIdleAnimation()
    {
        if (animPlayer == null)
        {
            GD.PrintErr("Animator: AnimationPlayer node not found.");
            return;
        }
        animPlayer.Play("Idle");
    }
}
