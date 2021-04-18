using System.Collections.Generic;

namespace _12StructuralPatterns_Adapter
{
    public class EmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployees()
        {
            return this.GetEmployeeList();
        }
    }
}