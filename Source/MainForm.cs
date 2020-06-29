// MainForm.cs //

using System;
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
			int index = -1;

			slotBox.Text = slotBox.Text.Trim();

			if( !int.TryParse( slotBox.Text, out index ) || !SaveManager.Backup( index ) )
				MessageBox.Show( this, SaveManager.ErrorMessage, "Backup failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
		}
		private void RestoreClicked( object sender, EventArgs e )
		{
			int index = -1;

			slotBox.Text = slotBox.Text.Trim();

			if( !int.TryParse( slotBox.Text, out index ) || !SaveManager.Restore( index ) )
				MessageBox.Show( this, SaveManager.ErrorMessage, "Restore failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
		}

		private void DeleteClicked( object sender, EventArgs e )
		{
			int index = -1;

			slotBox.Text = slotBox.Text.Trim();

			if( !int.TryParse( slotBox.Text, out index ) || !SaveManager.Delete( index ) )
				MessageBox.Show( this, SaveManager.ErrorMessage, "Deletion failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
		}
	}
}
