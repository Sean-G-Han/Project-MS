public class Goblin : IEntityCreators
{
    public static int Id = 1;
    public static Entity Create()
    {
        var stats = new EntityStat(800, 35, 30, 40);

        return new Entity("Goblin" + Id++, stats)
        {
            AttackLogic = (e) =>
            {
                e.Stats.Health = DamageCalculator.CalculateHealth(e.Stats.Health, stats.Attack, e.Stats.Defense);
                return e;
            },
            SupportLogic = (e) =>
            {
                return e;
            }
        };
    }
}
