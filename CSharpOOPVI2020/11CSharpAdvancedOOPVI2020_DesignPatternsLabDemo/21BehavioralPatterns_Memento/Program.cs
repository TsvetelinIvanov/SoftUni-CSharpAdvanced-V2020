namespace _21BehavioralPatterns_Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();

            originator.State = "On";//State = On

            Caretaker caretaker = new Caretaker();

            caretaker.Memento = originator.CreateMemento();
            originator.State = "Off";//State = Off
            originator.SetMemento(caretaker.Memento);
            //Restoring state...
            //State = On
        }
    }
}