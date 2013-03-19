namespace LevelUp.ProcessPro.Src.Dialog
{
	partial class DetailDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
			this.ListBox2 = new System.Windows.Forms.ListBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.lbxInfo = new System.Windows.Forms.ListBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
			this.SplitContainer2.Panel1.SuspendLayout();
			this.SplitContainer2.Panel2.SuspendLayout();
			this.SplitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(418, 366);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.listBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(410, 340);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Process Info";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.IntegralHeight = false;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(3, 20);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(404, 317);
			this.listBox1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.NavajoWhite;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(404, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Information";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.SplitContainer2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(410, 340);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Module Info";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// SplitContainer2
			// 
			this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer2.Location = new System.Drawing.Point(3, 3);
			this.SplitContainer2.Name = "SplitContainer2";
			this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContainer2.Panel1
			// 
			this.SplitContainer2.Panel1.Controls.Add(this.ListBox2);
			this.SplitContainer2.Panel1.Controls.Add(this.Label2);
			// 
			// SplitContainer2.Panel2
			// 
			this.SplitContainer2.Panel2.Controls.Add(this.lbxInfo);
			this.SplitContainer2.Panel2.Controls.Add(this.Label3);
			this.SplitContainer2.Size = new System.Drawing.Size(404, 334);
			this.SplitContainer2.SplitterDistance = 181;
			this.SplitContainer2.TabIndex = 1;
			// 
			// ListBox2
			// 
			this.ListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBox2.FormattingEnabled = true;
			this.ListBox2.IntegralHeight = false;
			this.ListBox2.ItemHeight = 12;
			this.ListBox2.Location = new System.Drawing.Point(0, 17);
			this.ListBox2.Name = "ListBox2";
			this.ListBox2.Size = new System.Drawing.Size(404, 164);
			this.ListBox2.Sorted = true;
			this.ListBox2.TabIndex = 3;
			this.ListBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.Color.NavajoWhite;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label2.Location = new System.Drawing.Point(0, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(404, 17);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Modules";
			// 
			// lbxInfo
			// 
			this.lbxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbxInfo.FormattingEnabled = true;
			this.lbxInfo.IntegralHeight = false;
			this.lbxInfo.ItemHeight = 12;
			this.lbxInfo.Location = new System.Drawing.Point(0, 17);
			this.lbxInfo.Name = "lbxInfo";
			this.lbxInfo.Size = new System.Drawing.Size(404, 132);
			this.lbxInfo.TabIndex = 4;
			// 
			// Label3
			// 
			this.Label3.BackColor = System.Drawing.Color.NavajoWhite;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label3.Location = new System.Drawing.Point(0, 0);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(404, 17);
			this.Label3.TabIndex = 1;
			this.Label3.Text = "Information";
			// 
			// DetailDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 366);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DetailDialog";
			this.ShowIcon = false;
			this.Text = "Detail";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.SplitContainer2.Panel1.ResumeLayout(false);
			this.SplitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
			this.SplitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		internal System.Windows.Forms.ListBox listBox1;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		internal System.Windows.Forms.SplitContainer SplitContainer2;
		internal System.Windows.Forms.ListBox ListBox2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ListBox lbxInfo;
		internal System.Windows.Forms.Label Label3;

	}
}