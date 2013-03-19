using System;

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