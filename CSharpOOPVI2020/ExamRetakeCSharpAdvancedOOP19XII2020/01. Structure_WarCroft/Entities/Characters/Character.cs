using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

//if structure tests doesn't past - change the namespases:
//namespace WarCroft.Entities.Characters.Contracts
namespace WarCroft.Entities.Characters
{
    public abstract class Character : ICharacter
    {
	private string name;
	private double health;
	private double armor;

	protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
	     this.Name = name;
	     this.BaseHealth = health;
	     this.Health = health;
	     this.BaseArmor = armor;
	     this.Armor = armor;
	     this.AbilityPoints = abilityPoints;
	     this.Bag = bag;
        }

	public string Name
        {
	    get { return this.name; }
            set
            {
		if (string.IsNullOrWhiteSpace(value))
                {
		     throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
		}

		this.name = value;
            }
        }

	public double BaseHealth { get; }		

	public double Health
        {
	    get { return this.health; }
            set
            {
		if (value < 0)
                {
		     value = 0;
                }

		if (value > this.BaseHealth)
                {
		     value = this.BaseHealth;
                }

		this.health = value;
            }
        }

	public double BaseArmor { get; }

	public double Armor
	{
	     get { return this.armor; }
	     set
	     {
		  if (value < 0)
		  {
		      value = 0;
		  }

		   this.armor = value;
	      }
	}

	public double AbilityPoints { get; }

	public Bag Bag { get; }

	public bool IsAlive { get; set; } = true;		

	public void TakeDamage(double hitPoints)
        {
	    this.EnsureAlive();

	    if (this.Armor >= hitPoints)
            {
		this.Armor -= hitPoints;
		hitPoints = 0;
            }
            else
            {
		hitPoints -= this.Armor;
		this.Armor = 0;
            }

	    if (this.Health >= hitPoints)
            {
		this.Health -= hitPoints;
            }
            else
            {
		this.Health = 0;				
            }

	    if (this.Health == 0)
            {
		this.IsAlive = false;
	    }
        }

	public void UseItem(Item item)
        {
	     this.EnsureAlive();

	     item.AffectCharacter(this);
        }

	protected void EnsureAlive()
	{
	      if (!this.IsAlive)
	      {
		  throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
	      }
        }		
    }
}
