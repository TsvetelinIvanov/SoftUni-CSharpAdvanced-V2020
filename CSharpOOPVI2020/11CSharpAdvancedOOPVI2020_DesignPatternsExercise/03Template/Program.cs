namespace _03Template
{
    class Program
    {
        static void Main(string[] args)
        {
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            //Gathering ingredients for 12-grain bread.
            //Baking the 12 - grain bread. (25 minutes)
            //Slicing the TwelveGrain bread!

            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            //Gathering ingredients for Sourdough bread.
            //Baking the Sourdough bread. (20 minutes)
            //Slicing the Sourdough bread!

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
            //Gathering ingredients for Whole wheat bread.
            //Baking the Whole wheat bread. (15 minutes)
            //Slicing the WholeWheat bread!
        }
    }
}