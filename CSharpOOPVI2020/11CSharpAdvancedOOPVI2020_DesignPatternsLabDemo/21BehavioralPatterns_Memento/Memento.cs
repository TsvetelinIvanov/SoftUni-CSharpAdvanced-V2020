namespace _21BehavioralPatterns_Memento
{
    public class Memento
    {
        public Memento(string state)
        {
            this.State = state;
        }

        public string State { get; }
    }
}