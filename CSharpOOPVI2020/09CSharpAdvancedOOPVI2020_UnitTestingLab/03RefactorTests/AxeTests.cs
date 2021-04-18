using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttackStartPontsCount = 3;
    private const int AxeDurabilityStartPontsCount = 2;
    private const int AxeDurabilityPontsCountAfterAttack = 1;    
    private const int DummyHealthStartPontsCount = 10;
    private const int DummyExperienceStartPontsCount = 10;
    private const string BrokenAxeExceptionMessage = "Axe is broken.";

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInitialization()
    {
        this.axe = new Axe(AxeAttackStartPontsCount, AxeDurabilityStartPontsCount);
        this.dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);
        this.axe.Attack(dummy);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {      
        Assert.That(axe.DurabilityPoints, Is.EqualTo(AxeDurabilityPontsCountAfterAttack), "Axe durability doesn't change after attack!");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {       
        this.axe.Attack(dummy);
       
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo(BrokenAxeExceptionMessage), "Broken axe can attack!");
    }
}