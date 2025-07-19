public class Orc : Entity
{
    public Orc() : base("Orc", new EntityStat(120, 6, 15, 8))
    {
        AttackLogic = (target) =>
        {
            int damage = Stats.Attack - target.Stats.Defense;
            if (damage < 0) damage = 0;
            target.Stats.Health -= damage;
        };

        SupportLogic = (target) =>
        {
            target.Stats.Health += 5;
        };
    }

    public override string ToString()
    {
        return $"Orc {Name}->Stats {Stats}]";
    }
}