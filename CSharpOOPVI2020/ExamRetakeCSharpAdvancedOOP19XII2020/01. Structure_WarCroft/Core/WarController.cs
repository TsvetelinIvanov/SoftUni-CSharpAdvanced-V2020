using System;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Items;
using WarCroft.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characterParty;
        private readonly List<Item> itemPool;

        public WarController()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;
            switch (characterType)
            {
                case nameof(Warrior):
                    character = new Warrior(name);
                    break;
                case nameof(Priest):
                    character = new Priest(name);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.characterParty.Add(character);

            return string.Format(SuccessMessages.JoinParty, character.Name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;
            switch (itemName)
            {
                case nameof(FirePotion):
                    item = new FirePotion();
                    break;
                case nameof(HealthPotion):
                    item = new HealthPotion();
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            this.itemPool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, item.GetType().Name);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characterParty.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = this.itemPool.Last();
            this.itemPool.RemoveAt(this.itemPool.Count - 1);
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characterParty.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder statsBuilder = new StringBuilder();
            foreach (Character character in characterParty.OrderByDescending(ch => ch.IsAlive).ThenByDescending(ch => ch.Health))
            {
                statsBuilder.AppendFormat(SuccessMessages.CharacterStats + Environment.NewLine, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead");
            }

            return statsBuilder.ToString().TrimEnd();
        }
        
        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characterParty.FirstOrDefault(ch => ch.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            Character receiver = this.characterParty.FirstOrDefault(ch => ch.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }


            if (attacker is IAttacker)
            {
                (attacker as IAttacker).Attack(receiver);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            string attackMessage = string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);
            if (!receiver.IsAlive)
            {
                attackMessage += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name);
            }

            return attackMessage;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = this.characterParty.FirstOrDefault(ch => ch.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            Character receiver = this.characterParty.FirstOrDefault(ch => ch.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (healer is IHealer)
            {
                (healer as IHealer).Heal(receiver);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }
    }
}