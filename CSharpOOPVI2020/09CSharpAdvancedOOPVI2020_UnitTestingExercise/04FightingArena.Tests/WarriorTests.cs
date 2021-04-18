using _04FightingArena;//For Judge must be commented: using _04FightingArena; and <ProjectReference Include="..\04FightingArena\04FightingArena.csproj" /> in 04FightingArena.Tests.csproj file
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private const int MinAttackHp = 30;
        private const string WarriorName = "Warrior";
        private const int WarriorDamage = 31;
        private const int WarriorLowerDamage = 21;
        private const int WarriorBiggerDamage = 41;
        private const int WarriorHp = 31;
        private const string DefenderName = "Defender";
        private const int DefenderDamage = 31;        
        private const int DefenderLowerDamage = 21;
        private const int DefenderBiggerDamage = 41;
        private const int DefenderHp = 31;
        private const int AttackedHpAfterAttackWithLowerDamage = 10;
        private const string InvalidNameExcepionMessage = "Name should not be empty or whitespace!";
        private const string InvalidDamageExcepionMessage = "Damage value should be positive!";
        private const string InvalidHpExcepionMessage = "HP should not be negative!";
        private const string LowHpAttackerExceptionMessage = "Your HP is too low in order to attack other warriors!";
        private const string LowHpDefenderExceptionMessage = "Enemy HP must be greater than {0} in order to attack him!";
        private const string StrongerEnemyExceptionMessage = "You are trying to attack too strong enemy";

        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(WarriorName, WarriorDamage, WarriorHp);
        }

        [Test]
        public void InitializeWithWarriorName()
        {
            Assert.AreEqual(WarriorName, this.warrior.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void InitializeWithInvalidNameThrowsException(string invalidName)
        {
            Assert.That(() => this.warrior = new Warrior(invalidName, WarriorDamage, WarriorHp), Throws.ArgumentException.With.Message.EqualTo(InvalidNameExcepionMessage));
        }

        [Test]
        public void InitializeWithWarriorDamage()
        {
            Assert.AreEqual(WarriorDamage, this.warrior.Damage);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void InitializeWithInvalidDamageThrowsException(int invalidDamage)
        {
            Assert.That(() => this.warrior = new Warrior(WarriorName, invalidDamage, WarriorHp), Throws.ArgumentException.With.Message.EqualTo(InvalidDamageExcepionMessage));
        }

        [Test]
        public void InitializeWithWarriorHp()
        {
            Assert.AreEqual(WarriorHp, this.warrior.HP);
        }

        [Test]
        public void InitializeWithInvalidDamageThrowsException()
        {
            Assert.That(() => this.warrior = new Warrior(WarriorName, WarriorDamage, -1), Throws.ArgumentException.With.Message.EqualTo(InvalidHpExcepionMessage));
        }

        [Test]
        public void AttackWithHpEqualToMinAttackHpThrowsException()
        {
            this.warrior = new Warrior(WarriorName, WarriorDamage, MinAttackHp);
            Warrior defender = new Warrior(DefenderName, DefenderDamage, DefenderHp);

            Assert.That(() => this.warrior.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo(LowHpAttackerExceptionMessage));
        }

        [Test]
        public void AttackDefenderWithHpEqualToMinAttackHpThrowsException()
        {            
            Warrior defender = new Warrior(DefenderName, DefenderDamage, MinAttackHp);

            Assert.That(() => this.warrior.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(LowHpDefenderExceptionMessage, MinAttackHp)));
        }

        [Test]
        public void AttackStrongerDefenderThrowsException()
        {
            Warrior defender = new Warrior(DefenderName, DefenderBiggerDamage, DefenderHp);

            Assert.That(() => this.warrior.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo(StrongerEnemyExceptionMessage));
        }

        [Test]
        public void AttackDefenderWithEqualDamageToHpMakeHp0()
        {
            Warrior defender = new Warrior(DefenderName, DefenderDamage, DefenderHp);

            this.warrior.Attack(defender);

            Assert.AreEqual(0, this.warrior.HP);
        }

        [Test]
        public void AttackDefenderWithLowerDamageToHpDecreaseHp()
        {
            Warrior defender = new Warrior(DefenderName, DefenderLowerDamage, DefenderHp);

            this.warrior.Attack(defender);

            Assert.AreEqual(AttackedHpAfterAttackWithLowerDamage, this.warrior.HP);
        }

        [Test]
        public void AttackDefenderWithEqualDamageThanHisHpMakeHisHp0()
        {
            Warrior defender = new Warrior(DefenderName, DefenderDamage, DefenderHp);

            this.warrior.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }

        [Test]
        public void AttackDefenderWithBiggerDamageThanHisHpMakeHisHp0()
        {
            this.warrior = new Warrior(WarriorName, WarriorBiggerDamage, WarriorHp);
            Warrior defender = new Warrior(DefenderName, DefenderDamage, DefenderHp);

            this.warrior.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }

        [Test]
        public void AttackDefenderWithLowerDamageThanHisHpDecreaseHisHp()
        {
            this.warrior = new Warrior(WarriorName, WarriorLowerDamage, WarriorHp);
            Warrior defender = new Warrior(DefenderName, DefenderDamage, DefenderHp);

            this.warrior.Attack(defender);

            Assert.AreEqual(AttackedHpAfterAttackWithLowerDamage, defender.HP);
        }
    }
}