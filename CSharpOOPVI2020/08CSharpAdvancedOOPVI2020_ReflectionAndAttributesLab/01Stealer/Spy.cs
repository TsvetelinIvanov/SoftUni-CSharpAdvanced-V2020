using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investgatedClassName, params string[] investigatedFieldNames)
        {
            Type investgatedClassType = Type.GetType(investgatedClassName);
            FieldInfo[] investigatedClassFields = investgatedClassType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Object investigatedClassInstance = Activator.CreateInstance(investgatedClassType, new object[] { });
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("Class under investigation: " + investgatedClassName);
            foreach (FieldInfo field in investigatedClassFields.Where(f => investigatedFieldNames.Contains(f.Name)))
            {
                infoBuilder.AppendLine(field.Name + " = " + field.GetValue(investigatedClassInstance));
            }

            return infoBuilder.ToString().TrimEnd();
        }
    }
}