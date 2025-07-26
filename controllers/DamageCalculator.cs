public class DamageCalculator
{
    public static int CalculateHealth(int opponentHealth, int attack, int defense)
    {
        int baseDamage = attack - defense;
        baseDamage = baseDamage < 1 ? 1 : baseDamage; // Ensure base damage is at least 1
        int newHealth = opponentHealth - baseDamage;
        return newHealth < 0 ? 0 : newHealth; // Ensure health doesn't go below 0
    }
}
