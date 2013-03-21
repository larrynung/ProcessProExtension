using EnvDTE;
using LevelUp.ProcessPro.Src.Dialog;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LevelUp.ProcessPro
{
	/// <summary>
	/// Interaction logic for MyControl.xaml
	/// </summary>
	public partial class MyControl : UserControl
	{
		#region DllImport
		[DllImport("user32.dll")]
		static extern IntPtr WindowFromPoint(System.Drawing.Point point);
		#endregion

		public ObservableCollection<ProcessData> Processes
		{
			get
			{
				return ProcessController.Instance.Processes;
			}
		}

		Cursor _arrawCursor;
		public Cursor m_ArrawCursor
		{
			get
			{
				return _arrawCursor ?? (_arrawCursor = WinFXCursorFromBitmap.CreateCursor(LevelUp.ProcessPro.Resources.arrow));
			}
		}

		private DispatcherTimer _autoUpdateTimer;
		public DispatcherTimer m_AutoUpdateTimer
		{
			get
			{
				return _autoUpdateTimer ?? (_autoUpdateTimer = new DispatcherTimer());
			}
		}

		public MyControl()
		{
			InitializeComponent();
		}

		private void MyToolWindow_Loaded(object sender, RoutedEventArgs e)
		{
			lvProcesses.Items.Filter = delegate(object item)
			{
				if (tbxFilter.Text.Length == 0)
					return true;

				var processData = item as ProcessData;

				var regex = new Regex(string.Format("({0})", tbxFilter.Text.Replace(',', '|')));
				return regex.IsMatch(processData.Name)
					|| regex.IsMatch(processData.Title);
			};

			m_AutoUpdateTimer.Interval = TimeSpan.FromMilliseconds(1500);
			m_AutoUpdateTimer.Tick += m_AutoUpdateTimer_Tick;
			m_AutoUpdateTimer.Start();

			ProcessController.Instance.AutoUpdateInterval = 5000;
			ProcessController.Instance.EnableAutoUpdate = true;
		}

		void m_AutoUpdateTimer_Tick(object sender, EventArgs e)
		{
			Update();
		}

		private void lvProcesses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ToogleAttachStatusWithSelectedProcess();
		}

		private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			imgArrow.Source = null;
			Cursor = m_ArrawCursor;
		}

		private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			imgArrow.Source = this.Resources["Arrow"] as BitmapImage;
			Cursor = Cursors.Arrow;

			AttachPointProcess();
		}

		private void AttachPointProcess()
		{
			ProcessController.Instance.AttachProcess(GetPointProcessID());
		}


		private int GetPointProcessID()
		{
			var point = System.Windows.Forms.Control.MousePosition;
			var handle = WindowFromPoint(point);
			var processID = (from item in System.Diagnostics.Process.GetProcesses()
							 where item.MainWindowHandle == handle
							 select item.Id).FirstOrDefault();
			return processID;
		}


		public void ToogleAttachStatusWithSelectedProcess()
		{
			if (lvProcesses.SelectedItems == null || lvProcesses.SelectedItems.Count == 0)
				return;

			var selectedProcesses = lvProcesses.SelectedItems.OfType<ProcessData>();

			foreach (var selectedProcess in selectedProcesses)
			{
				if (selectedProcess.Attached)
					ProcessController.Instance.DetachProcess(selectedProcess.ID);
				else
					ProcessController.Instance.AttachProcess(selectedProcess.ID);
			}
		}

		public void AttachSelectedProcess()
		{
			if (lvProcesses.SelectedItems == null || lvProcesses.SelectedItems.Count == 0)
				return;

			var selectedProcesses = lvProcesses.SelectedItems.OfType<ProcessData>();

			selectedProcesses.ForEach(p => ProcessController.Instance.AttachProcess(p.ID));
		}

		public void DetachSelectedProcess()
		{
			if (lvProcesses.SelectedItems == null || lvProcesses.SelectedItems.Count == 0)
				return;

			var selectedProcesses = lvProcesses.SelectedItems.OfType<ProcessData>();

			selectedProcesses.ForEach(p => ProcessController.Instance.DetachProcess(p.ID));
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Update();
		}

		private void Update(Boolean updateProcessList = false)
		{
			CollectionViewSource.GetDefaultView(Processes).Refresh();

			if (updateProcessList)
				ProcessController.Instance.UpdateProcesses();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			if (lvProcesses.SelectedItems == null || lvProcesses.SelectedItems.Count == 0)
				return;

			if (MessageBox.Show("Want to kill these processes!?", LevelUp.ProcessPro.Resources.ToolWindowTitle, MessageBoxButton.YesNo) == MessageBoxResult.No)
				return;

			var selectedProcesses = lvProcesses.SelectedItems.OfType<ProcessData>().ToArray();

			selectedProcesses.ForEach(p => p.Close());
			Update();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			if (lvProcesses.SelectedItem == null)
				return;

			var selectedProcess = lvProcesses.SelectedItem as ProcessData;
			if (selectedProcess.Attached)
				DetachSelectedProcess();
			else
				AttachSelectedProcess();
		}

		private void MenuItem_Loaded(object sender, RoutedEventArgs e)
		{
			if (lvProcesses.SelectedItem == null)
			{
				cmiAttachOrDetach.Visibility = System.Windows.Visibility.Collapsed;
				cmiKill.Visibility = System.Windows.Visibility.Collapsed;
				return;
			}

			var selectedProcess = lvProcesses.SelectedItem as ProcessData;
			cmiAttachOrDetach.Header = selectedProcess.Attached ? "Detach" : "Attach";
			cmiAttachOrDetach.Visibility = System.Windows.Visibility.Visible;

			cmiKill.Visibility = System.Windows.Visibility.Visible;
		}

		private void autoCompleteBox1_Populating(object sender, PopulatingEventArgs e)
		{
			tbxFilter.ItemsSource = Processes.Distinct(p => p.Name);
			tbxFilter.PopulateComplete();
			Update();
		}

		private void tbxFilter_TextChanged(object sender, RoutedEventArgs e)
		{
			Update();
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			if (lvProcesses.SelectedItem == null)
				return;

			var selectedProcess = lvProcesses.SelectedItem as ProcessData;
			var dialog = new DetailDialog(System.Diagnostics.Process.GetProcessById(selectedProcess.ID));
			dialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			dialog.ShowDialog();
		}
	}
}