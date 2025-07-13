using Godot;

public class Character
{

    [Export]
    public string Species { get; private set; } = "Unknown";

    [Export]
    public CharStat Stats { get; private set; } = CharStat.Create(10, 10, 10, 10);

    public Character(string species)
    {
        Species = species;
    }

    public Character(string species, CharStat stats)
    {
        Species = species;
        Stats = stats;
    }

    public void ExecuteAttack(Character target, Move move)
    {

    }

    public Move ExecutePassiveOff(Move allyMove)
    {
        return allyMove;
    }

    public Move ExecutePassiveDef(Move enemyMove)
    {
        return enemyMove;
    }

    public Character ExecutePassiveBuff(Character ally)
    {
        return ally;
    }

    public override string ToString()
    {
        return $"Entity {Species}";
    }
}