using WarCroft.Entities.Characters;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int DefaltWeight = 5;

        public FirePotion() : base(DefaltWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;
            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}