using System;

public partial class EntityStat
{
    public int Health { get; set; } = 10;

    public int Speed { get; set; } = 10;

    public int Attack { get; set; } = 10;

    public int Defense { get; set; } = 10;

    public EntityStat(int health, int speed, int attack, int defense)
    {
        Health = health;
        Speed = speed;
        Attack = attack;
        Defense = defense;
    }
    public override string ToString()
    {
        return $"[H:{Health}, S:{Speed}, A:{Attack}, D:{Defense}]";
    }

        public override bool Equals(object obj)
    {
        if (obj is EntityStat otherStat)
        {
            return Health == otherStat.Health &&
                   Speed == otherStat.Speed &&
                   Attack == otherStat.Attack &&
                   Defense == otherStat.Defense;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Health, Speed, Attack, Defense);
    }

}
