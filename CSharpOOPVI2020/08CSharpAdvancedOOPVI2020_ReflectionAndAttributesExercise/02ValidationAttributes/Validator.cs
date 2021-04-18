using System;
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
                if (property.Name.Contains("FullName"))
                {
                    Attribute attribute = property.GetCustomAttribute(typeof(MyRequiredAttribute));
                    MyRequiredAttribute requiredAttribute = (MyRequiredAttribute)attribute;
                    string fullName = (string)property.GetValue(obj);
                    isValid = requiredAttribute.IsValid(fullName);                    
                }
                else if (property.Name.Contains("Age"))
                {
                    Attribute attribute = property.GetCustomAttribute(typeof(MyRangeAttribute));
                    MyRangeAttribute rangeAttribute = (MyRangeAttribute)attribute;
                    int age = (int)property.GetValue(obj);
                    isValid = rangeAttribute.IsValid(age);                    
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