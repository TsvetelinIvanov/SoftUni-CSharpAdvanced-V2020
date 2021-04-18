namespace _03CreationalPatterns_FactoryMethod
{
    public interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }
}