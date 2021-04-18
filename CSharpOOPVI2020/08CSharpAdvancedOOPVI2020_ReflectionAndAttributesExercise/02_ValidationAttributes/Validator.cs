using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {

            bool isValid = true;
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] myValidationAttributes = property.GetCustomAttributes<MyValidationAttribute>().ToArray();
                object value = property.GetValue(obj);
                foreach (MyValidationAttribute attribute in myValidationAttributes)
                {
                    isValid = attribute.IsValid(value);
                    if (isValid == false)
                    {
                        break;
                    }
                }                

                if (isValid == false)
                {
                    break;
                }
            }

            return isValid;
        }
    }
}