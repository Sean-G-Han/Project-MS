using Godot;
using System;

public partial class Animator : Node2D
{
    [Signal]
    public delegate void AnimationEndedEventHandler(string animName);

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
        PlayIdleAnimation();
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

    public void PlaySupportAnimation()
    {
        if (animPlayer == null)
        {
            GD.PrintErr("Animator: AnimationPlayer node not found.");
            return;
        }
        animPlayer.Play("Support");
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

    public void _on_animation_player_animation_finished(string animName)
    {
        EmitSignal(nameof(AnimationEnded), animName);
    }
}
