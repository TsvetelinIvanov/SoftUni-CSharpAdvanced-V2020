namespace _04Recharge
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
            this.workingHours = 0;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }

        public int ReportWorkHours()
        {
            return this.workingHours;
        }
    }
}