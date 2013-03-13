using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUp.ProcessPro
{
	public class ProcessData : IDisposable, INotifyPropertyChanged
	{
		#region Var
		private String _owner; 
		private Boolean _attached;
		private PerformanceCounter _counter;
		private int _cpu;
		private System.Diagnostics.Process _process;
		private int _id;
		private String _name;
		private String _title;
		#endregion


		#region Private Property
		public Boolean m_IsDisposing { get; set; }

		private System.Diagnostics.Process m_Process 
		{
			get 
			{
				return _process;
			}
			set
			{
				if (_process == value)
					return;

				//try
				//{
				//	if (_process != null && !_process.HasExited)
				//	{
				//		_process.Dispose();
				//	}
				//}
				//catch (Exception)
				//{
				//}

				_process = value;
			}
		}

		private DateTime m_CPULastUpdate { get; set; }
		
		private PerformanceCounter m_Counter
		{
			get 
			{
				return _counter ?? (_counter = new PerformanceCounter("Process", "% Processor Time", GetProcessInstanceName(this.ID)));
			}
		}
		#endregion

		#region Public Property
		public int ID 
		{
			get 
			{
				if (m_Process != null)
					_id = m_Process.Id;
				return _id;
			}
		}

		public String Name
		{
			get
			{
				if (m_Process != null)
					_name = m_Process.ProcessName;
				return _name;
			}
		}

		public String Title
		{
			get
			{
				if (m_Process != null)
					_title = m_Process.MainWindowTitle;
				return _title;
			}
		}

		public String Owner 
		{
			get
			{
				if (_owner == null)
				{
					if (m_Process != null)
						_owner = m_Process.GetProcessOwner();

					if (_owner == null)
						_owner = string.Empty;
				}
				return _owner;
			}
		}

		public int CPU
		{
			get
			{
				UpdateCpuUsage();
				return _cpu;
			}
			private set
			{
				if (_cpu == value)
					return;

				_cpu = value;
				NotifyPropertyChanged("CPU");
			}
		}

		public int ThreadCount 
		{
			get
			{
				return m_Process.Threads.Count;
			}
		}

		public Boolean Attached 
		{
			get
			{
				UpdateAttachStatus();
				return _attached;
			}
			private set
			{
				if (_attached == value)
					return;
				
				_attached = value;
				OnAttachedChanged(EventArgs.Empty);
			}
		}
		#endregion

		#region Event
		public event EventHandler AttachedChanged;
		public event EventHandler Exited;
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Constructor
		public ProcessData(int processID)
			:this(System.Diagnostics.Process.GetProcessById(processID))
		{
		}

		public ProcessData(System.Diagnostics.Process process)
		{
			m_Process = process;
			m_Process.Exited += m_Process_Exited;
		}

		~ProcessData()
		{
			Dispose(false);
			GC.SuppressFinalize(this);
		}
		#endregion


		#region Private Method
		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		private string GetProcessInstanceName(int pid)
		{
			PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");

			string[] instances = cat.GetInstanceNames();
			foreach (string instance in instances)
			{

				using (PerformanceCounter cnt = new PerformanceCounter("Process",
					 "ID Process", instance, true))
				{
					int val = (int)cnt.RawValue;
					if (val == pid)
					{
						return instance;
					}
				}
			}
			return Name;
		}

		private void UpdateCpuUsage()
		{
			lock (this)
			{
				try
				{
					var interval = DateTime.Now - m_CPULastUpdate;
					if (interval.TotalSeconds > 1)
					{
						var counterValue = m_Counter.NextValue();
						var cpuUsage = (int)(counterValue / Environment.ProcessorCount);
						_cpu = cpuUsage;
						m_CPULastUpdate = DateTime.Now;
					}
				}
				catch (Exception)
				{
				}
			}
		}

		private void UpdateAttachStatus()
		{
			var dte = (DTE)Package.GetGlobalService(typeof(DTE));

			Attached = dte.Debugger.DebuggedProcesses != null && dte.Debugger.DebuggedProcesses.OfType<EnvDTE.Process>().Any(p => p.ProcessID == ID);
		} 
		#endregion


		#region Protected Method
		protected void OnAttachedChanged(EventArgs e)
		{
			if (AttachedChanged == null)
				return;
			AttachedChanged(this, e);
		}

		protected void OnExited(EventArgs e)
		{
			if (Exited == null)
				return;
			Exited(this, e);
		}

		protected void Dispose(Boolean isDispose)
		{
			if (m_IsDisposing)
				return;

			m_Process = null;

			OnExited(EventArgs.Empty);
		}
		#endregion


		#region Public Method
		public void Update()
		{
			UpdateCpuUsage();
			UpdateAttachStatus();
		}

		public override string ToString()
		{
			return this.Name;
		}

		public override int GetHashCode()
		{
			return this.ID.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (object.ReferenceEquals(this, obj))
				return true;

			var data = obj as ProcessData;
			if (data == null)
				return false;
			
			return this.ID.Equals(data.ID);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		public void Close()
		{
			m_Process.SafeClose(100);
		}
		#endregion


		#region Event Process
		void m_Process_Exited(object sender, EventArgs e)
		{
			Dispose();
		}
		#endregion
	}
}
