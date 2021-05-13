using WarCroft.Entities.Characters;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int DefaltWeight = 5;

        public HealthPotion() : base(DefaltWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;
        }
    }
}