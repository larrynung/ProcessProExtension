using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace LevelUp.ProcessPro.Src.Dialog
{
	public partial class DetailDialog : Form
	{
		System.Diagnostics.Process _process;
		public DetailDialog(System.Diagnostics.Process process)
		{
			InitializeComponent();

			this.Icon = Resources._1306142432_running_process;
			this.Text = string.Format("{0}({1})", process.ProcessName, process.Id);


			_process = process;
			UpdateProcessInfo(process);

			UpdateModules(process);
		}

		private void UpdateProcessInfo(System.Diagnostics.Process process)
		{
			listBox1.BeginUpdate();
			listBox1.Items.Clear();

			listBox1.Items.Add("Process Name:\t" + process.ProcessName);
			listBox1.Items.TryDo(o => o.Add("Process Handle:\t" + process.Handle));
			listBox1.Items.Add("Window Title:\t" + process.MainWindowTitle);

			listBox1.Items.TryDo(o => o.Add("Process Version:\t" + process.MainModule.FileVersionInfo.FileVersion));
			listBox1.Items.TryDo(o => o.Add("Company Name:\t" + process.MainModule.FileVersionInfo.CompanyName));
			listBox1.Items.TryDo(o => o.Add("Process File Name:\t" + process.MainModule.FileVersionInfo.FileName));
			listBox1.Items.TryDo(o => o.Add("Process File Size:\t" + process.MainModule.ModuleMemorySize.ToString()));
			listBox1.Items.TryDo(o => o.Add("Description:\t" + process.MainModule.FileVersionInfo.FileDescription));
			listBox1.Items.TryDo(o => o.Add("Product Name:\t" + process.MainModule.FileVersionInfo.ProductName));
			listBox1.Items.TryDo(o => o.Add("Product Version:\t" + process.MainModule.FileVersionInfo.ProductVersion));
			listBox1.Items.TryDo(o => o.Add("CopyRight:\t" + process.MainModule.FileVersionInfo.LegalCopyright));


			listBox1.EndUpdate();
		}

		private void UpdateModules(System.Diagnostics.Process process)
		{
			try
			{
				ListBox2.BeginUpdate();
				ListBox2.Items.Clear();

				foreach (ProcessModule module in process.Modules)
					ListBox2.Items.Add(module.ModuleName);

				if (ListBox2.Items.Count > 0)
					ListBox2.SelectedIndex = 0;
			}
			catch (Exception)
			{
			}
			finally
			{
				ListBox2.EndUpdate();
			}
		}

		private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
		{

			var moduleName = ListBox2.SelectedItem.ToString();
			UpdateModuleInfo(moduleName);
		}

		private void UpdateModuleInfo(string moduleName)
		{
			var module = _process.Modules.OfType<ProcessModule>().Where(m => m.ModuleName == moduleName).FirstOrDefault();

			lbxInfo.BeginUpdate();
			lbxInfo.Items.Clear();

			lbxInfo.Items.Add("Module Name:\t" + module.ModuleName);
			lbxInfo.Items.Add("Module Version:\t" + module.FileVersionInfo.FileVersion);
			lbxInfo.Items.Add("Company Name:\t" + module.FileVersionInfo.CompanyName);
			lbxInfo.Items.Add("Module File Name:\t" + module.FileVersionInfo.FileName);
			lbxInfo.Items.Add("Module File Size:\t" + module.ModuleMemorySize.ToString());
			lbxInfo.Items.Add("Description:\t" + module.FileVersionInfo.FileDescription);
			lbxInfo.Items.Add("Product Name:\t" + module.FileVersionInfo.FileDescription);
			lbxInfo.Items.Add("Product Version:\t" + module.FileVersionInfo.ProductName);
			lbxInfo.Items.Add("CopyRight:\t" + module.FileVersionInfo.LegalCopyright);


			lbxInfo.EndUpdate();
		}
	}
}
