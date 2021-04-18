using NUnit.Framework;
using Moq;

[TestFixture]
public class HeroTests
{
    private const string HeroName = "Pesho";    
    private const int ReturnedMockHealth = 0;
    private const int ReturnedMockExperience = 20;
    private const bool ReturnedIsDeadState = true;
    private const int ExpectedHeroExperience = 20;

    [Test]
    public void HeroGainsExperienceWhenTargetDies()
    {
        Mock<ITarget> mockTarget = new Mock<ITarget>();
        mockTarget.Setup(mt => mt.Health).Returns(ReturnedMockHealth);
        mockTarget.Setup(mt => mt.GiveExperience()).Returns(ReturnedMockExperience);
        mockTarget.Setup(mt => mt.IsDead()).Returns(ReturnedIsDeadState);
        Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
        Hero hero = new Hero(HeroName, mockWeapon.Object);

        hero.Attack(mockTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(ExpectedHeroExperience));
    }
}