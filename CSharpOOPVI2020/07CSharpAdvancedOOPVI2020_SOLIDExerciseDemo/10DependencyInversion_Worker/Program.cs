namespace _10DependencyInversion_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            Manager manager = new Manager(worker);//Working...
        }
    }
}