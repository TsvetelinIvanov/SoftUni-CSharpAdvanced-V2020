namespace _15BehavioralPatterns_ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver ronny = new Director();
            Approver bobby = new VicePresident();
            Approver ricky = new President();

            ronny.SetSuccessor(bobby);
            bobby.SetSuccessor(ricky);

            Purchase purchase = new Purchase(8884, 350.00, "Assets");
            ronny.ProcessRequest(purchase);//Director approved request# 8884

            purchase = new Purchase(5675, 33390.10, "Project Poison");
            ronny.ProcessRequest(purchase);//President approved request# 5675

            purchase = new Purchase(5676, 144400.00, "Project BBD");
            ronny.ProcessRequest(purchase);//Request# 5676 requires an executive meeting!
        }
    }
}