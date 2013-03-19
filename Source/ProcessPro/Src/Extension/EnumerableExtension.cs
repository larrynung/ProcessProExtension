using System;
using System.Collections.Generic;

public static class EnumerableExtension
{
	public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		HashSet<TKey> seenKeys = new HashSet<TKey>();
		foreach (TSource element in source)
		{
			var elementValue = keySelector(element);
			if (seenKeys.Add(elementValue))
			{
				yield return element;
			}
		}
	}

	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		foreach (var item in source)
			action(item);
	}
}
