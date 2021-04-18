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

        public string AnalyseAccessModifiers(string investgatedClassName)
        {
            Type investgatedClassType = Type.GetType(investgatedClassName);
            FieldInfo[] publicFields = investgatedClassType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] publicMethods = investgatedClassType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = investgatedClassType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder modifierMistakeInfoBuilder = new StringBuilder();
            foreach (FieldInfo field in publicFields)
            {
                modifierMistakeInfoBuilder.AppendLine(field.Name + " must be private!");
            }

            foreach (MethodInfo nonPubilcGetter in nonPublicMethods.Where(npm => npm.Name.StartsWith("get")))
            {
                modifierMistakeInfoBuilder.AppendLine(nonPubilcGetter.Name + " have to be public!");
            }

            foreach (MethodInfo publicSetter in publicMethods.Where(pm => pm.Name.StartsWith("set")))
            {
                modifierMistakeInfoBuilder.AppendLine(publicSetter.Name + " have to be private!");
            }

            return modifierMistakeInfoBuilder.ToString().TrimEnd();
        }

        public string RevealNonPublicMethods(string investgatedClassName)
        {
            Type investigatedClassType = Type.GetType(investgatedClassName);
            MethodInfo[] nonPublicMethods = investigatedClassType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder nonPublicMethodsBuilder = new StringBuilder();
            nonPublicMethodsBuilder.AppendLine("All Private Methods of Class: " + investgatedClassName);
            nonPublicMethodsBuilder.AppendLine("Base class: " + investigatedClassType.BaseType.Name);
            foreach (MethodInfo privateMethod in nonPublicMethods)
            {
                nonPublicMethodsBuilder.AppendLine(privateMethod.Name);
            }

            return nonPublicMethodsBuilder.ToString().TrimEnd();
        }
    }
}