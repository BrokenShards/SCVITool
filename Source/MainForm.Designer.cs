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
			this.mainPanel = new System.Windows.Forms.Panel();
			this.restoreBut = new System.Windows.Forms.Button();
			this.backupBut = new System.Windows.Forms.Button();
			this.slocDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.glocDialog = new System.Windows.Forms.OpenFileDialog();
			this.slotBox = new System.Windows.Forms.MaskedTextBox();
			this.slotLab = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.slotBox);
			this.mainPanel.Controls.Add(this.slotLab);
			this.mainPanel.Controls.Add(this.restoreBut);
			this.mainPanel.Controls.Add(this.backupBut);
			this.mainPanel.Location = new System.Drawing.Point(13, 13);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(258, 30);
			this.mainPanel.TabIndex = 0;
			// 
			// restoreBut
			// 
			this.restoreBut.Location = new System.Drawing.Point(180, 3);
			this.restoreBut.Name = "restoreBut";
			this.restoreBut.Size = new System.Drawing.Size(75, 23);
			this.restoreBut.TabIndex = 7;
			this.restoreBut.Text = "Restore";
			this.restoreBut.UseVisualStyleBackColor = true;
			this.restoreBut.Click += new System.EventHandler(this.RestoreClicked);
			// 
			// backupBut
			// 
			this.backupBut.Location = new System.Drawing.Point(92, 3);
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
			// slotBox
			// 
			this.slotBox.Location = new System.Drawing.Point(46, 5);
			this.slotBox.Mask = "00";
			this.slotBox.Name = "slotBox";
			this.slotBox.PromptChar = ' ';
			this.slotBox.Size = new System.Drawing.Size(31, 20);
			this.slotBox.TabIndex = 1;
			this.slotBox.Text = "00";
			this.slotBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// slotLab
			// 
			this.slotLab.Location = new System.Drawing.Point(5, 3);
			this.slotLab.Name = "slotLab";
			this.slotLab.Size = new System.Drawing.Size(37, 23);
			this.slotLab.TabIndex = 8;
			this.slotLab.Text = "Slot #";
			this.slotLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(281, 56);
			this.Controls.Add(this.mainPanel);
			this.Name = "MainForm";
			this.Text = "SCVI Tool";
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.FolderBrowserDialog slocDialog;
		private System.Windows.Forms.OpenFileDialog glocDialog;
		private System.Windows.Forms.Button restoreBut;
		private System.Windows.Forms.Button backupBut;
		private System.Windows.Forms.MaskedTextBox slotBox;
		private System.Windows.Forms.Label slotLab;
	}
}

