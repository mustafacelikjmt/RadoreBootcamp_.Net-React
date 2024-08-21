using System.Reflection;

namespace AttributeRadoreOrnek
{
    public static class RequirementCheck
    {
        public static bool Verify(object objectToVerify)
        {
            Type verifyType = objectToVerify.GetType();
            FieldInfo[] fieldsToVerify = verifyType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo fieldToVerify in fieldsToVerify)
            {
                object[] requiredFieldAttributes = fieldToVerify.GetCustomAttributes(typeof(RequiredFieldAttribute), true);
                if (requiredFieldAttributes.Length != 0)
                {
                    string fieldValue = fieldToVerify.GetValue(objectToVerify) as string;
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}