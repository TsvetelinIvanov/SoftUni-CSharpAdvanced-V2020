using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttackStartPointsCount = 10;
    private const int AxeDurabilityStartPointsCount = 10;
    private const int AxeDurabilityPointsCountAfterAttack = 9;
    private const int BrokenAxeAttackStartPointsCount = 1;
    private const int BrokenAxeDurabilityStartPointsCount = 1;
    private const int DummyHealthStartPointsCount = 10;
    private const int DummyExperienceStartPointsCount = 10;

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        //Arrange
        Axe axe = new Axe(AxeAttackStartPointsCount, AxeDurabilityStartPointsCount);
        Dummy dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(AxeDurabilityPointsCountAfterAttack));
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        //Arrange
        Axe axe = new Axe(BrokenAxeAttackStartPointsCount, BrokenAxeDurabilityStartPointsCount);
        Dummy dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}
