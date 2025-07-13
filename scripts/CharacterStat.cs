using Godot;
using System;

public partial class CharStat : Resource
{

    [Export]
    public int Health { get; private set; } = 10;

    [Export]
    public int Speed { get; private set; } = 10;

    [Export]
    public int Attack { get; private set; } = 10;

    [Export]
    public int Defense { get; private set; } = 10;

    public static CharStat Create(int health, int speed, int attack, int defense)
    {
        var stat = new CharStat();
        stat.Health = health;
        stat.Speed = speed;
        stat.Attack = attack;
        stat.Defense = defense;
        return stat;
    }

    public override string ToString()
    {
        return $"[Stats]\nHealth: {Health}\nSpeed: {Speed}\nAttack: {Attack}\nDefense: {Defense}\n";
    }
}
