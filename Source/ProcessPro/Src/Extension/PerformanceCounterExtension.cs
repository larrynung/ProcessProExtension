using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class PerformanceCounterExtension
{
	#region Private Static Var
	private static Dictionary<PerformanceCounter, DateTime> _updateTimePool;
	private static Dictionary<PerformanceCounter, float> _valuePool;
	#endregion


	#region Private Static Property
	private static Dictionary<PerformanceCounter, DateTime> m_UpdateTimePool
	{
		get
		{
			return _updateTimePool ?? (_updateTimePool = new Dictionary<PerformanceCounter, DateTime>());
		}
	}

	private static Dictionary<PerformanceCounter, float> m_ValuePool
	{
		get
		{
			return _valuePool ?? (_valuePool = new Dictionary<PerformanceCounter, float>());
		}
	}
	#endregion


	#region Public Static Method
	public static float GetNextValue(this PerformanceCounter counter)
	{
		var lastUpdateTime = default(DateTime);

		m_UpdateTimePool.TryGetValue(counter, out lastUpdateTime);

		var interval = DateTime.Now - lastUpdateTime;

		if (interval.TotalSeconds > 1)
		{
			m_ValuePool[counter] = counter.NextValue();
		}

		return m_ValuePool[counter];
	}
	#endregion
}
