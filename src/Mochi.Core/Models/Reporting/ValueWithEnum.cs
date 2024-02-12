namespace Mochi.Core.Models.Reporting;

public class ValueWithEnum<TValue, TEnum> where TEnum : Enum
{
    public ValueWithEnum(TValue value, TEnum enumValue)
    {
        Value = value;
        EnumValue = enumValue;
    }

    public TValue Value { get; set; }
    public TEnum EnumValue { get; set; }
}
