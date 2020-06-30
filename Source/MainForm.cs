//
// MainForm.cs
//
// SCVITool - A simple SCVI save backup manager.
// Copyright (C) 2020 Michael Furlong
//
// This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public
// License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any 
// later version.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program.If not, 
// see<https://www.gnu.org/licenses/>.
//

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
