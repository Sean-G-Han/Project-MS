using Godot;

public partial class Character : RefCounted
{
    bool _isEnemy = false;

    [Export]
    public string Species { get; private set; } = "Unknown";

    [Export]
    public CharStat Stats { get; private set; } = CharStat.Create(10, 10, 10, 10);

    public Character(string species)
    {
        Species = species;
    }

    public Character(string species, CharStat stats, bool isEnemy = false)
    {
        _isEnemy = isEnemy;
        Species = species;
        Stats = stats;
    }

    public Character Attack(Character target)
    {
        int damage = Stats.Attack - target.Stats.Defense;
        damage = damage <= 0 ? 1 : damage;
        int newHealth = target.Stats.Health - damage;
        newHealth = newHealth < 0 ? 0 : newHealth;
        return new Character(target.Species, CharStat.Create(
            newHealth,
            target.Stats.Attack,
            target.Stats.Speed,
            target.Stats.Defense
        ), target._isEnemy);
    }

    public void ExecuteMove()
    {
        if (!_isEnemy)
        {
            GD.Print($"=> {Species} attacks {Global.Instance.Enemy.Species}!");
            Global.Instance.Enemy = Attack(Global.Instance.Enemy);
            GD.Print($"{Global.Instance.Enemy}");
        }
        else
        {
            GD.Print($"=> {Species} is an enemy and does not move.\n");
        }
    }

    public override string ToString()
    {
        return $"==> {Species} Stats: {Stats}";
    }
}