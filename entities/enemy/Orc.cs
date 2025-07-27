using Godot;

public class Orc : IEntityCreators
{
    private static readonly PackedScene AnimatorScene = (PackedScene)ResourceLoader.Load("res://entities/animation/TestAnimator.tscn");
    private static readonly PackedScene EntityNodeScene = (PackedScene)ResourceLoader.Load("res://entities/EntityNode.tscn");
    public static int Id = 1;
    public static EntityNode Create()
    {
        var stats = new EntityStat(1000, 20, 50, 50);

        var entity = new Entity("Orc" + Id++, stats)
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
        var entityNode = (EntityNode)EntityNodeScene.Instantiate();
        entityNode.SetEntity(entity);
        var animator = (Animator)AnimatorScene.Instantiate();
        entityNode.SetAnimator(animator);
        return entityNode;
    }
}