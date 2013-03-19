using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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