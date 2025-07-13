using System;
using Godot;

public class Move
{
    public int Damage { get; private set; }
    public Func<Character, Character> SideEffect { get; private set; }  

    public Move(int damage, Func<Character, Character> sideEffect = null)
    {
        Damage = damage;
        SideEffect = sideEffect;
    }
}