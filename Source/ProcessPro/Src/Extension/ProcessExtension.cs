using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;

public static class ProcessExtension
{
	#region Const
	private const string PROCESS_CATEGORY_NAME = "Process";
	private const string ID_PROCESS_COUNTER_NAME = "ID Process";
	#endregion

	#region Private Static Var
	private static PerformanceCounterCategory _category;
	private static Dictionary<int, PerformanceCounter> _counterPool;
	#endregion


	#region Private Static Property
	private static PerformanceCounterCategory m_Category
	{
		get
		{
			return _category ?? (_category = new PerformanceCounterCategory(PROCESS_CATEGORY_NAME));
		}
	}

	private static Dictionary<int, PerformanceCounter> m_CounterPool
	{
		get
		{
			return _counterPool ?? (_counterPool = new Dictionary<int, PerformanceCounter>());
		}
	}
	#endregion


	#region Private Static Method
	private static string GetProcessInstanceName(int pid)
	{
		var instances = m_Category.GetInstanceNames();
		foreach (var instance in instances)
		{
			using (var counter = new PerformanceCounter(m_Category.CategoryName,
				 ID_PROCESS_COUNTER_NAME, instance, true))
			{
				if ((int)counter.RawValue != pid)
					continue;
				return instance;
			}
		}
		return null;
	}

	private static int GetCpuUsage(int pid)
	{
		try
		{
			if (!m_CounterPool.ContainsKey(pid))
			{
				var instanceName = GetProcessInstanceName(pid);
				if (instanceName == null)
					return 0;
				m_CounterPool.Add(pid, new PerformanceCounter(PROCESS_CATEGORY_NAME, "% Processor Time", instanceName));
			}

			return (int)(m_CounterPool[pid].GetNextValue() / Environment.ProcessorCount);
		}
		catch (Exception)
		{
			return 0;
		}
	}
	#endregion


	#region Public Static Method
	public static string GetInstanceName(this Process process)
	{
		return GetProcessInstanceName(process.Id);
	}

	public static int GetCpuUsage(this Process process)
	{
		return GetCpuUsage(process.Id);
	}

	public static void WaitForFormLoad(this Process process)
	{
		process.WaitForInputIdle();
		while (!process.HasExited && process.MainWindowHandle == IntPtr.Zero)
		{
			Application.DoEvents();
			Thread.Sleep(100);
		}
	}

	public static string GetProcessOwner(this Process process)
	{
		var query = "Select * From Win32_Process Where ProcessID = " + process.Id;
		var searcher = new ManagementObjectSearcher(query);
		var processObj = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

		if (processObj != null)
		{
			var argList = new string[2];
			int returnVal = Convert.ToInt32(processObj.InvokeMethod("GetOwner", argList));
			if (returnVal == 0)
			{
				return string.Join(@"\", argList.Reverse().ToArray());
			}
		}

		return null;
	}

	public static void SafeClose(this Process process, int wait = 100)
	{
		process.CloseMainWindow();
		process.WaitForExit(wait);

		if (process != null && !process.HasExited)
			process.Kill();
	}
	#endregion
}
