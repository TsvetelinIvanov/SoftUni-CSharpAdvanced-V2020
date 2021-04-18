namespace _24BehavioralPatterns_Visitor
{
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}