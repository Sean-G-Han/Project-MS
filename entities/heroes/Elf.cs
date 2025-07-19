using Godot;

public class Elf : Entity
{
    public Elf() : base("Elf", EntityType.Hero, new EntityStat(100, 50, 15, 5))
    {
        AttackLogic = (target) =>
        {
            int damage = Stats.Attack - target.Stats.Defense;
            if (damage < 0) damage = 0;
            target.Stats.Health -= damage;
        };
        
        SupportLogic = (target) =>
        {
            target.Stats.Health += 10;
        };
    }

    public override string ToString()
    {
        return $"Elf {Name}->Stats {Stats}]";
    }
}