using System;

namespace _01Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            //default sandwiches
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            //custom sandwiches
            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spanach");

            //cloned sandwiches
            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;//Cloning sandwich with ingredients: Wheat, Bacon, , Lettuce, Tomato.
            Sandwich sandwich2 = sandwichMenu["PB&J"].Clone() as Sandwich;//Cloning sandwich with ingredients: White, , , Peanut Butter, Jelly.
            Sandwich sandwich3 = sandwichMenu["Turkey"].Clone() as Sandwich;//Cloning sandwich with ingredients: Rye, Turkey, Swiss, Lettuce, Onion, Tomato.
            Sandwich sandwich4 = sandwichMenu["LoadedBLT"].Clone() as Sandwich;//Cloning sandwich with ingredients: Wheat, Turkey, Bacon, American, Lettuce, Tomato, Onion, Olives.
            Sandwich sandwich5 = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;//Cloning sandwich with ingredients: Rye, Turkey, Ham, Salami, Provolone, Lettuce, Onion.
            Sandwich sandwich6 = sandwichMenu["Vegetarian"].Clone() as Sandwich;//Cloning sandwich with ingredients: Wheat, , , Lettuce, Onion, Tomato, Olives, Spanach.
        }
    }
}