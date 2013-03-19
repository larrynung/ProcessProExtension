using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ObjectExtension
{
	public static void TryDo<T>(this T obj, Action<T> action)
	{
		try
		{
			action(obj);
		}
		catch (Exception)
		{
		}
	}
}