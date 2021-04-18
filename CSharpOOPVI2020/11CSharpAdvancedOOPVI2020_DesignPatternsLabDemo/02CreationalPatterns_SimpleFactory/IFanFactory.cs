namespace _02CreationalPatterns_SimpleFactory
{
    public interface IFanFactory
    {
        IFan CreateFan(FanType type);
    }
}