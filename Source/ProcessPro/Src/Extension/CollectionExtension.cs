using System.Collections.Generic;
using System.Collections.ObjectModel;

public static class CollectionExtension
{
	public static void AddRange<T>(this Collection<T> collections, IEnumerable<T> items)
	{
		foreach (var item in items)
			collections.Add(item);
	}

	public static void RemoveRange<T>(this Collection<T> collections, IEnumerable<T> items)
	{
		foreach (var item in items)
			collections.Remove(item);
	}
}