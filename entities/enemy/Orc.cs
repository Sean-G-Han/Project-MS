public class Orc : Entity
{
    public Orc() : base("Orc", EntityType.Enemy, new EntityStat(120, 6, 15, 8))
    {
        // Initialize specific logic for Orc if needed
        AttackLogic = (target) =>
        {
            int damage = Stats.Attack - target.Stats.Defense;
            if (damage < 0) damage = 0; // Ensure no negative damage
            int newHealth = target.Stats.Health - damage;
            if (newHealth < 0) newHealth = 0; // Ensure health doesn't go negative
            return new Entity(target.Name, target.Type, new EntityStat(newHealth, target.Stats.Attack, target.Stats.Defense, target.Stats.Speed));
        };

        SupportLogic = (target) =>
        {
            // Example support logic: increase target's health by a fixed amount
            int healAmount = 5;
            int newHealth = target.Stats.Health + healAmount;
            return new Entity(target.Name, target.Type, new EntityStat(newHealth, target.Stats.Attack, target.Stats.Defense, target.Stats.Speed));
        };
    }

    public override string ToString()
    {
        return $"Orc {Name}->Stats {Stats}]";
    }
}