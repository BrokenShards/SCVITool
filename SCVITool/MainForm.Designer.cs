namespace SCVITool
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.restoreBut = new System.Windows.Forms.Button();
			this.backupBut = new System.Windows.Forms.Button();
			this.slocDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.glocDialog = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.restoreBut);
			this.panel1.Controls.Add(this.backupBut);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(208, 31);
			this.panel1.TabIndex = 0;
			// 
			// restoreBut
			// 
			this.restoreBut.Location = new System.Drawing.Point(130, 3);
			this.restoreBut.Name = "restoreBut";
			this.restoreBut.Size = new System.Drawing.Size(75, 23);
			this.restoreBut.TabIndex = 7;
			this.restoreBut.Text = "Restore";
			this.restoreBut.UseVisualStyleBackColor = true;
			this.restoreBut.Click += new System.EventHandler(this.RestoreClicked);
			// 
			// backupBut
			// 
			this.backupBut.Location = new System.Drawing.Point(3, 3);
			this.backupBut.Name = "backupBut";
			this.backupBut.Size = new System.Drawing.Size(75, 23);
			this.backupBut.TabIndex = 6;
			this.backupBut.Text = "Backup";
			this.backupBut.UseVisualStyleBackColor = true;
			this.backupBut.Click += new System.EventHandler(this.BackupClicked);
			// 
			// slocDialog
			// 
			this.slocDialog.RootFolder = System.Environment.SpecialFolder.LocalApplicationData;
			// 
			// glocDialog
			// 
			this.glocDialog.DefaultExt = "exe";
			this.glocDialog.FileName = "SoulcaliburVI.exe";
			this.glocDialog.Filter = "SoulcaliburVI Executable|*.exe";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(233, 55);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "SCVI Tool";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.FolderBrowserDialog slocDialog;
		private System.Windows.Forms.OpenFileDialog glocDialog;
		private System.Windows.Forms.Button restoreBut;
		private System.Windows.Forms.Button backupBut;
	}
}

