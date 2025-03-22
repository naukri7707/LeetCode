using System.Collections;
using System.Text;

namespace DevEnv;

public static class FormatHelper
{
    public static string ToString<T>(T value)
    {
        if (value == null)
            return "null";

        Type type = value.GetType();

        if (IsTuple(type))
        {
            return FormatTuple(value);
        }

        if (typeof(IList).IsAssignableFrom(type))
        {
            return FormatList((IList)value);
        }

        // 其他類型直接調用 ToString
        return value.ToString() ?? "";
    }

    private static bool IsTuple(Type type)
    {
        if (type == null)
            return false;

        // 檢查是否為 System.Tuple
        if (type.IsGenericType && type.GetGenericTypeDefinition().Name.StartsWith("Tuple`"))
            return true;

        // 檢查是否為 System.ValueTuple
        if (type.IsValueType && type.FullName?.StartsWith("System.ValueTuple") == true)
            return true;

        return false;
    }

    private static string FormatTuple(object tuple)
    {
        var type = tuple.GetType();
        var fields = type.GetFields();
        var properties = type.GetProperties();

        var sb = new StringBuilder();
        sb.Append('(');

        // 遍歷元組的每個字段或屬性
        foreach (var field in fields)
        {
            var fieldValue = field.GetValue(tuple);
            sb.Append(ToString(fieldValue)).Append(", ");
        }

        foreach (var prop in properties)
        {
            var propValue = prop.GetValue(tuple);
            sb.Append(ToString(propValue)).Append(", ");
        }

        // 移除最後多餘的 ", "
        if (sb.Length > 1)
            sb.Length -= 2;

        sb.Append(')');
        return sb.ToString();
    }

    private static string FormatList(IList list)
    {
        var sb = new StringBuilder();
        sb.Append('[');

        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(ToString(list[i]));
            if (i < list.Count - 1)
                sb.Append(", ");
        }

        sb.Append(']');
        return sb.ToString();
    }
}
