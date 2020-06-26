// MainForm.cs //

using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace SCVITool
{
	public partial class MainForm : Form
	{
		public static string Executable
		{
			get
			{
				string path = Path.GetDirectoryName( Assembly.GetExecutingAssembly().CodeBase );

				try
				{
					string s5  = path.Substring( 0, 5 ).ToLower();
					string s6  = path.Substring( 0, 6 ).ToLower();
					string s8  = path.Substring( 0, 8 ).ToLower();
					string s10 = path.Substring( 0, 10 ).ToLower();

					if( s5 == "dir:/" || s5 == "dir:\\" )
						path = path.Substring( 5 );
					else if( s6 == "file:/" || s6 == "file:\\" || s6 == "path:/" || s6 == "path:\\" )
						path = path.Substring( 6 );
					else if( s8 == "folder:/" || s8 == "folder:\\" )
						path = path.Substring( 8 );
					else if( s10 == "directory:/" || s10 == "directory:\\" )
						path = path.Substring( 10 );
				}
				catch( Exception e )
				{
					Console.WriteLine( e.Message );
				}

				return path;
			}
		}

		public static readonly string SavePath = 
			Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.None ), "SoulcaliburVI" );

		public MainForm()
		{
			InitializeComponent();
		}
		
		private void BackupClicked( object sender, EventArgs e )
		{
			string saved  = Path.Combine( SavePath, "Saved" ),
			       backup = Path.Combine( SavePath, "Saved_Backup" );

			if( !Directory.Exists( saved ) )
			{
				MessageBox.Show( this, "Unable to find save data to backup.", "No data to backup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				return;
			}

			DirectoryInfo savedinfo  = null,
			              backupinfo = null;

			try
			{
				savedinfo = new DirectoryInfo( saved );

				if( Directory.Exists( backup ) )
					Directory.Delete( backup, true );

				backupinfo = Directory.CreateDirectory( backup );
			}
			catch( Exception ex )
			{
				MessageBox.Show( this, "Unable to backup save data: " + ex.Message + ".", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			try
			{
				CopyFilesRecursively( savedinfo, backupinfo );
			}
			catch( Exception ex )
			{
				MessageBox.Show( this, "Unable to backup save data: " + ex.Message + ".", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}
		}
		private void RestoreClicked( object sender, EventArgs e )
		{
			string saved  = Path.Combine( SavePath, "Saved" ),
				   backup = Path.Combine( SavePath, "Saved_Backup" );

			if( !Directory.Exists( backup ) )
			{
				MessageBox.Show( this, "Unable to find save data to restore.", "No data to restore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				return;
			}

			DirectoryInfo savedinfo = null,
						  backupinfo = null;

			try
			{
				backupinfo = new DirectoryInfo( backup );

				if( Directory.Exists( saved ) )
					Directory.Delete( saved, true );

				savedinfo = new DirectoryInfo( saved );

				CopyFilesRecursively( backupinfo, savedinfo );
			}
			catch( Exception ex )
			{
				MessageBox.Show( this, "Unable to restore save data: " + ex.Message + ".", "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		public static void CopyFilesRecursively( DirectoryInfo source, DirectoryInfo target )
		{
			try
			{
				foreach( DirectoryInfo dir in source.GetDirectories() )
					CopyFilesRecursively( dir, target.CreateSubdirectory( dir.Name ) );
				foreach( FileInfo file in source.GetFiles() )
					file.CopyTo( Path.Combine( target.FullName, file.Name ) );
			}
			catch
			{
				throw;
			}
		}
	}
}
