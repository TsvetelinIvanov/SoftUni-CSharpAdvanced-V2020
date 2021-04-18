using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttackStartPontsCount = 10;
    private const int AxeDurabilityStartPontsCount = 10;
    private const int AxeDurabilityPontsCountAfterAttack = 9;
    private const int BrokenAxeAttackStartPontsCount = 1;
    private const int BrokenAxeDurabilityStartPontsCount = 1;
    private const int DummyHealthStartPontsCount = 10;
    private const int DummyExperienceStartPontsCount = 10;

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        //Arrange
        Axe axe = new Axe(AxeAttackStartPontsCount, AxeDurabilityStartPontsCount);
        Dummy dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(AxeDurabilityPontsCountAfterAttack));
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        //Arrange
        Axe axe = new Axe(BrokenAxeAttackStartPontsCount, BrokenAxeDurabilityStartPontsCount);
        Dummy dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}