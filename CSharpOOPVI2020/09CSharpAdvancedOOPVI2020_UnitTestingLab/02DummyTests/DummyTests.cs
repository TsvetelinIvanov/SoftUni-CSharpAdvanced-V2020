using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int DummyHealthStartPointsCount = 20;
    private const int DummyExperienceStartPointsCount = 10;
    private const int DummyLosesAfterAttack = 5;
    private const int DummyHealthPointsAfterAttack = 15;    
    private const string DummyDeadExceptionMessage = "Dummy is dead.";
    private const string DummyNotDeadExceptionMessage = "Target is not dead.";

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);

        //Assert
        Assert.That(dummy.Health, Is.EqualTo(DummyHealthPointsAfterAttack));
    }

    [Test]
    public void DeadDummyThrowsExceptionAfterAttack()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);

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
        Dummy dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);
        dummy.TakeAttack(DummyLosesAfterAttack);

        //Assert
        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(DummyExperienceStartPointsCount));
    }

    [Test]
    public void AliveDummyCannotGiveExperience()
    {
        //Arrange
        Dummy dummy = new Dummy(DummyHealthStartPointsCount, DummyExperienceStartPointsCount);

        //Act
        dummy.TakeAttack(DummyLosesAfterAttack);        

        //Assert
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo(DummyNotDeadExceptionMessage));
    }
}
