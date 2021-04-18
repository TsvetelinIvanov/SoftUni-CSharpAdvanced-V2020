using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string HeroName = "Pesho";
    private const int ExpectedHeroExperience = 20;

    [Test]
    public void HeroGainsExperienceWhenTargetDies()
    {
        ITarget fakeTarget = new FakeTarget();
        IWeapon fakeWeapon = new FakeWeapon();
        Hero hero = new Hero(HeroName, fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.That(hero.Experience, Is.EqualTo(ExpectedHeroExperience));
    }
}