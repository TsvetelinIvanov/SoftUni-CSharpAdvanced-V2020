namespace _10DependencyInversion_Worker
{
    public class Manager
    {
        public Manager(IWorker worker)
        {            
            worker.Work();
        }
    }
}