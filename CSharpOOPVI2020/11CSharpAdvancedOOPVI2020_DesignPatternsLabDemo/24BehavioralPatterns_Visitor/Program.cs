namespace _24BehavioralPatterns_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Employees employees = new Employees();
            employees.Attach(new Clerk());
            employees.Attach(new Director());
            employees.Attach(new President());

            employees.Accept(new IncomeVisitor());
            //Clerk Harry's new income: 27 500,00 лв.
            //Director Edward's new income: 38 500,00 лв.
            //President Damond's new income: 49 500,00 лв.
            employees.Accept(new VacationVisitor());
            //Clerk Harry's new vacation days: 17
            //Director Edward's new vacation days: 19
            //President Damond's new vacation days: 24
        }
    }
}