using Godot;

public class Orc : IEntityCreators
{
    private static readonly PackedScene AnimatorScene = (PackedScene)ResourceLoader.Load("res://entities/animation/Animator.tscn");
    public static int Id = 1;
    public static Entity Create()
    {
        var stats = new EntityStat(1000, 20, 50, 50);

        return new Entity("Orc" + Id++, stats)
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
    public static Animator GetAnimator()
    {
        var instance = (Animator)AnimatorScene.Instantiate();
        return instance;
    }
}