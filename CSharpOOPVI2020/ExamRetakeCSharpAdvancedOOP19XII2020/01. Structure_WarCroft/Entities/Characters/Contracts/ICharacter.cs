using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public interface ICharacter
    {
        string Name { get; set; }

        bool IsAlive { get; set; }

        double BaseHealth { get; }

        double Health { get; set; }

        double BaseArmor { get; }

        double Armor { get; set; }

        double AbilityPoints { get; }

        Bag Bag { get; }

        void TakeDamage(double hitPionts);

        void UseItem(Item item);
    }
}