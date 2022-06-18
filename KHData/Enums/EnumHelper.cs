using System.ComponentModel;
using System.Reflection;
using KHData.Flags;

namespace KHData.Enums;

public static class EnumHelper
{
    public static string GetDescription<T>(this T enumerationValue)
        where T : struct
    {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
        }

        //Tries to find a DescriptionAttribute for a potential friendly name
        //for the enum
        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                //Pull out the description value
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        //If we have no description attribute, just return the ToString of the enum
        return enumerationValue.ToString();
    }
    
    public static int GetAddress<T>(this T enumerationValue) where T : struct
    {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
        }

        //Tries to find an Address for the enum value
        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(AddressAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                //Has Parent
                return ((AddressAttribute)attrs[0]).Address;
            }
        }
        // No address set, return 0
        return 0;
    }
    
    public static FlagType GetFlagType<T>(this T enumerationValue) where T : struct
    {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
        }

        //Tries to find an Address for the enum value
        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString() ?? string.Empty);
        if (memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(FlagTypeAttribute), false);

            if (attrs is { Length: > 0 })
            {
                return ((FlagTypeAttribute)attrs[0]).Type;
            }
        }
        // No address set, return 0
        return FlagType.Int;
    }
    
    public static int GetLength<T>(this T enumerationValue) where T : struct
    {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
        }

        //Tries to find Length for the enum value
        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(LengthAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                return ((LengthAttribute)attrs[0]).Length;
            }
        }
        return 0;
    }
}