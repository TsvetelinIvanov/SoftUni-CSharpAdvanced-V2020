using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttackStartPointsCount = 3;
    private const int AxeDurabilityStartPointsCount = 2;
    private const int AxeDurabilityPointsCountAfterAttack = 1;    
    private const int DummyHealthStartPointsCount = 10;
    private const int DummyExperienceStartPointsCount = 10;
    private const string BrokenAxeExceptionMessage = "Axe is broken.";

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInitialization()
    {
        this.axe = new Axe(AxeAttackStartPointsCount, AxeDurabilityStartPointsCount);
        this.dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);
        this.axe.Attack(dummy);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {      
        Assert.That(axe.DurabilityPoints, Is.EqualTo(AxeDurabilityPointsCountAfterAttack), "Axe durability doesn't change after attack!");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {       
        this.axe.Attack(dummy);
       
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo(BrokenAxeExceptionMessage), "Broken axe can attack!");
    }
}
