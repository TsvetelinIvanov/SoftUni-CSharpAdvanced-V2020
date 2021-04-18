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

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);

        //Assert
        Assert.That(dummy.Health, Is.EqualTo(DummyHealthPontsAfterAttack));
    }

    [Test]
    public void DeadDummyThrowsExceptionAfterAttack()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);

        //Assert
        Assert.That(() => dummy.TakeAttack(DummyLosesAfterAttack), Throws.InvalidOperationException.With.Message.EqualTo(DummyDeadExceptionMessage));
    }

    [Test]
    public void DeadDummyGiveEperience()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);

        //Assert
        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(DummyExperienceStartPontsCount));
    }

    [Test]
    public void AliveDummyCanNotGiveExperience()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPontsCount, DummyExperienceStartPontsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);        

        //Assert
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo(DummyNotDeadExceptionMessage));
    }
}