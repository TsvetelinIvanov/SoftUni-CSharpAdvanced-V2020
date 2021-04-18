public class FakeTarget : ITarget
{
    private const bool IsDeadState = true;
    private const int ReturnedHealth = 0;
    private const int ReturnedExpirience = 20;

    public int Health => ReturnedHealth;

    public int GiveExperience()
    {
        return ReturnedExpirience;
    }

    public bool IsDead()
    {
        return IsDeadState;
    }

    public void TakeAttack(int attackPoints)
    {
        
    }
}