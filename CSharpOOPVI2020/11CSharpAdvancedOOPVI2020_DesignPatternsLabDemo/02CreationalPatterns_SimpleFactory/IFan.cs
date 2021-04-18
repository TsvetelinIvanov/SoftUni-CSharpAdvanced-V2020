namespace _02CreationalPatterns_SimpleFactory
{
    public interface IFan
    {
        void SwitchOn();

        void SwitchOff();

        string GetState();
    }
}