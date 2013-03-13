using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelUp.ProcessPro
{
	public class ProcessController
	{
		#region Static Var
        private static ProcessController _instance;
        #endregion

		#region Var
		private ObservableCollection<ProcessData> _processes;
		private Timer _autoUpdateTimer;
		#endregion

		#region Private Property
		/// <summary>
		/// Gets the m_ auto update timer.
		/// </summary>
		/// <value>
		/// The m_ auto update timer.
		/// </value>
		public Timer m_AutoUpdateTimer 
		{
			get
			{
				return _autoUpdateTimer ?? (_autoUpdateTimer = new Timer());
			}
		}

		private DateTime m_LastUpdate { get; set; }
		#endregion


		#region Public Static Property
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ProcessController Instance
        { 
            get
            {
                return _instance ?? (_instance = new ProcessController());
            }
        }
        #endregion


		#region Public Property
		/// <summary>
		/// Gets or sets the auto update interval.
		/// </summary>
		/// <value>
		/// The auto update interval.
		/// </value>
		public int AutoUpdateInterval
		{ 
			get 
			{
				return m_AutoUpdateTimer.Interval;
			} 
			set
			{
				m_AutoUpdateTimer.Interval = value;
			} 
		}

		/// <summary>
		/// Gets or sets the enable auto update.
		/// </summary>
		/// <value>
		/// The enable auto update.
		/// </value>
		public Boolean EnableAutoUpdate 
		{
			get
			{
				return m_AutoUpdateTimer.Enabled;
			}
			set
			{
				m_AutoUpdateTimer.Enabled = value;
			}
		}

		/// <summary>
		/// Gets the processes.
		/// </summary>
		/// <value>
		/// The processes.
		/// </value>
		public ObservableCollection<ProcessData> Processes
		{
			get
			{
				if (_processes == null)
				{
					_processes = new ObservableCollection<ProcessData>();
					UpdateProcesses();
				}
				return _processes;
			}
		}
		#endregion


		#region Constructor
		/// <summary>
		/// Prevents a default instance of the <see cref="ProcessController" /> class from being created.
		/// </summary>
		private ProcessController()
        {
			m_AutoUpdateTimer.Tick += m_AutoUpdateTimer_Tick;
        }
        #endregion


		#region Public Method
		/// <summary>
		/// Starts the auto update.
		/// </summary>
		/// <param name="interval">The interval.</param>
		public void StartAutoUpdate(int interval)
		{
			this.AutoUpdateInterval = interval;
			StartAutoUpdate();
		}

		/// <summary>
		/// Starts the auto update.
		/// </summary>
		public void StartAutoUpdate()
		{
			m_AutoUpdateTimer.Start();
		}

		/// <summary>
		/// Stops the auto update.
		/// </summary>
		public void StopAutoUpdate()
		{
			m_AutoUpdateTimer.Stop();
		}

		/// <summary>
		/// Updates the processes.
		/// </summary>
		public void UpdateProcesses()
		{
			lock (Processes)
			{
				if ((DateTime.Now - m_LastUpdate).TotalSeconds < 1)
					return;
				
				var currentProcesses = System.Diagnostics.Process.GetProcesses();
				var currentProcessDatas = currentProcesses.Select(p => new ProcessData(p));

				if (!Processes.Any())
				{
					Processes.AddRange(currentProcessDatas);
					return;
				}

				var addProcessDatas = currentProcessDatas.Except(Processes).ToArray();
				var removeProcessDatas = Processes.Except(currentProcessDatas).ToArray();

				Processes.AddRange(addProcessDatas);
				Processes.RemoveRange(removeProcessDatas);

				addProcessDatas.ForEach(p =>
					{
						p.Exited -= p_Exited;
						p.Exited += p_Exited;
					});

				removeProcessDatas.ForEach(p =>
				{
					p.Exited -= p_Exited;
				});

				Processes.ForEach(p => p.Update());

				m_LastUpdate = DateTime.Now;
			}
		}


		public void AttachProcess(int processID)
		{
			if (processID == 0)
				return;

			if (processID == System.Diagnostics.Process.GetCurrentProcess().Id)
				return;

			var dte = (DTE)Package.GetGlobalService(typeof(DTE));
			foreach (EnvDTE.Process process in dte.Debugger.LocalProcesses)
			{
				if (process.ProcessID == processID)
				{
					process.Attach();

					Processes.Single(p => p.ID == processID).Update();
					return;
				}
			}
		}

		public void DetachProcess(int processID)
		{
			if (processID == 0)
				return;

			if (processID == System.Diagnostics.Process.GetCurrentProcess().Id)
				return;

			var dte = (DTE)Package.GetGlobalService(typeof(DTE));
			foreach (EnvDTE.Process process in dte.Debugger.DebuggedProcesses)
			{
				if (process.ProcessID == processID)
				{
					process.Detach(false);

					Processes.Single(p => p.ID == processID).Update();
					return;
				}
			}
		}

		public static void DetachAllProcess()
		{
			var dte = (DTE)Package.GetGlobalService(typeof(DTE));
			dte.Debugger.DetachAll();
		}
		#endregion


		#region Event Process
		/// <summary>
		/// Handles the Tick event of the m_AutoUpdateTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		void m_AutoUpdateTimer_Tick(object sender, EventArgs e)
		{
			UpdateProcesses();
		}

		void p_Exited(object sender, EventArgs e)
		{
			try
			{
				Processes.Remove(sender as ProcessData);
			}
			catch (Exception)
			{
			}
		}
		#endregion
	}
}
