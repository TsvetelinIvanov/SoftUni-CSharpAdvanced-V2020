using _04FightingArena;//For Judge must be commented: using _04FightingArena; and <ProjectReference Include="..\04FightingArena\04FightingArena.csproj" /> in 04FightingArena.Tests.csproj file
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private const string EnrolledWarriorExceptionMessage = "Warrior is already enrolled for the fights!";
        private const string NotEnrolledFighterExceptionMessage = "There is no fighter with name {0} enrolled for the fights!";
        private const string FirstFighterName = "First Fighter";
        private const string MissingFighterName = "Missing Fighter";

        private readonly Warrior firstFigher = new Warrior("First Fighter", 31, 31);
        private readonly Warrior secondFigher = new Warrior("Second Fighter", 21, 31);
        private readonly Warrior thirdFigher = new Warrior("Third Fighter", 41, 31);

        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void InitializeArenaWith0Worriors()
        {
            Assert.AreEqual(0, this.arena.Count);            
        }

        [Test]
        public void EnrollEnrollsGivenWarriors()
        {
            this.arena.Enroll(this.firstFigher);
            this.arena.Enroll(this.secondFigher);
            this.arena.Enroll(this.thirdFigher);

            Assert.AreEqual(3, this.arena.Count);
        }

        [Test]
        public void EnrollEnrolledWarriorThrowsException()
        {
            this.arena.Enroll(this.firstFigher);
            this.arena.Enroll(this.secondFigher);

            Assert.That(() => this.arena.Enroll(this.firstFigher), Throws.InvalidOperationException.With.Message.EqualTo(EnrolledWarriorExceptionMessage));
        }

        [Test]
        public void FightDecreaseFighterHp()
        {
            this.arena.Enroll(this.firstFigher);
            this.arena.Enroll(this.secondFigher);

            int expectedFirstFighterHp = this.firstFigher.HP - this.secondFigher.Damage;
            int expectedSecondFighterHp = this.secondFigher.HP - this.firstFigher.Damage;

            this.arena.Fight(this.firstFigher.Name, this.secondFigher.Name);

            Assert.AreEqual(expectedFirstFighterHp, this.firstFigher.HP);
            Assert.AreEqual(expectedSecondFighterHp, this.secondFigher.HP);
        }

        [TestCase(MissingFighterName, FirstFighterName)]
        [TestCase(FirstFighterName, MissingFighterName)]        
        public void FightMissingAttackerThrowsException(string attacker, string defender)
        {
            this.arena.Enroll(this.firstFigher);
            this.arena.Enroll(this.secondFigher);

            Assert.That(() => this.arena.Fight(attacker, defender), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NotEnrolledFighterExceptionMessage, MissingFighterName)));
        }
    }
}