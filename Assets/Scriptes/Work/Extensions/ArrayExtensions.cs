using System;
using System.Collections.Generic;
using System.Text;

public static class ArrayExtensions
{
    public static void Action<T>(this T[] array, Action<T> action)
    {
        Array.ForEach(array, element => action(element));
    }
    public static void Action<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TValue> action)
    {
        foreach (var item in dictionary)
        {
            action(item.Value);
        }
    }
    public static void Action<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable)
        {
            action(item);
        }
    }
    public static string FuncToString<TInput>(this IEnumerable<TInput> enumerable, Func<TInput,string> func)
    {
        StringBuilder stringBuilder = new ();
        foreach (var item in enumerable)
        {
            stringBuilder.AppendLine(func(item));
        }
        return stringBuilder.ToString();
    }
}
