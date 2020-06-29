// MainForm.cs //

using System;
using System.IO;
using System.Windows.Forms;

namespace SCVITool
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void BackupClicked( object sender, EventArgs e )
		{
			if( !SaveManager.Backup() )
				MessageBox.Show( this, SaveManager.ErrorMessage, "Backup failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
		}
		private void RestoreClicked( object sender, EventArgs e )
		{
			if( !SaveManager.Restore() )
				MessageBox.Show( this, SaveManager.ErrorMessage, "Restore failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
		}
	}
}
