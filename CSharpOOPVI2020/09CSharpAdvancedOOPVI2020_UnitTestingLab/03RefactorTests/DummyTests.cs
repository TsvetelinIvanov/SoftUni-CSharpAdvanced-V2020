using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int DummyHealthStartPontsCount = 20;
    private const int DummyExperienceStartPontsCount = 10;
    private const int DummyLosesAfterAttack = 5;
    private const int DummyHealthPontsAfterAttack = 15;
    private const string DummyDeadExceptionMessage = "Dummy is dead.";
    private const string DummyNotDeadExceptionMessage = "Target is not dead.";

    private Dummy dummy;

    [SetUp]
    public void TestInitialization()
    {
        this.dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);
        this.dummy.TakeAttack(DummyLosesAfterAttack);
    }

    [Test]
    public void DummyLosesHealthAfterAttack()
    {      
        Assert.That(dummy.Health, Is.EqualTo(DummyHealthPontsAfterAttack), "Dummy's health does not change after attack!");
    }

    [Test]
    public void DeadDummyThrowsExceptionAfterAttack()
    {       
        this.dummy.TakeAttack(DummyLosesAfterAttack);
        this.dummy.TakeAttack(DummyLosesAfterAttack);
        this.dummy.TakeAttack(DummyLosesAfterAttack);
        
        Assert.That(() => dummy.TakeAttack(DummyLosesAfterAttack), Throws.InvalidOperationException.With.Message.EqualTo(DummyDeadExceptionMessage), "Dead dummy does not throw ecxepion after attack!");
    }

    [Test]
    public void DeadDummyGiveEperience()
    {        
        this.dummy.TakeAttack(DummyLosesAfterAttack);
        this.dummy.TakeAttack(DummyLosesAfterAttack);
        this.dummy.TakeAttack(DummyLosesAfterAttack);

        int givenExperience = dummy.GiveExperience();
        Assert.That(givenExperience, Is.EqualTo(DummyExperienceStartPontsCount), "Dead dummy does not give experience!");
    }

    [Test]
    public void AliveDummyCanNotGiveExperience()
    {        
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo(DummyNotDeadExceptionMessage), "Alive dummy does not throw ecxepion after trying to get experience!");
    }
}