namespace _16BehavioralPatterns_Iterator
{
    public interface IIterator
    {
        void First();

        string Next();

        bool IsDone();

        string CurrentItem();
    }
}