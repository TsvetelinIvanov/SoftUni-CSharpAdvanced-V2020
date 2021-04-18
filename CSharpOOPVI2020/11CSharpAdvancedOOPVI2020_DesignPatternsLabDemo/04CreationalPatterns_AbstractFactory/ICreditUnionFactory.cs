namespace _04CreationalPatterns_AbstractFactory
{
    public abstract class ICreditUnionFactory
    {
        public abstract ISavingsAccount CreateSavingsAccount();

        public abstract ILoanAccount CreateLoanAccount();
    }
}