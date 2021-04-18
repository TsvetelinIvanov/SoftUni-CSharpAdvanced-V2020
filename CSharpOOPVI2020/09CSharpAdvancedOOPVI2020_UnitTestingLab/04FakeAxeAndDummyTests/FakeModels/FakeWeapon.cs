public class FakeWeapon : IWeapon
{
    private const int ReturnedAttackPointsCount = 10;
    private const int ReturnedDurabiliryPointsCount = 10;

    public int AttackPoints => ReturnedAttackPointsCount;

    public int DurabilityPoints => ReturnedDurabiliryPointsCount;

    public void Attack(ITarget target)
    {
        target.TakeAttack(this.AttackPoints);
    }
}