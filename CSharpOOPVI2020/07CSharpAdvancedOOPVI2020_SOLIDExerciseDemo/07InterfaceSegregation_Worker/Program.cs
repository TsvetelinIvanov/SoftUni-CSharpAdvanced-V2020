namespace _07InterfaceSegregation_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();
            Robot robot = new Robot();

            human.Work();//Working...
            human.Eat();//Eating...
            human.Sleep();//Sleeping...
            robot.Work();//Working...
        }
    }
}