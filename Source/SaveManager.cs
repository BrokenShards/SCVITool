// SaveManager.cs //

using System;
using System.IO;

namespace SCVITool
{
	public static class SaveManager
	{
		static readonly string SavePath = Path.Combine( Environment.GetFolderPath( 
			Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.None ), "SoulcaliburVI" );
		static readonly string SavedPath  = Path.Combine( SavePath, "Saved" );
		static readonly string BackupPath = Path.Combine( SavePath, "Saved_Backup" );

		public static string ErrorMessage
		{
			get; private set;
		} = string.Empty;

		public static bool Backup()
		{
			if( !Directory.Exists( SavedPath ) )
			{
				ErrorMessage = "Unable to find save data to backup.";
				return false;
			}

			DirectoryInfo savedinfo  = null,
						  backupinfo = null;

			try
			{
				savedinfo = new DirectoryInfo( SavedPath );

				if( Directory.Exists( BackupPath ) )
					Directory.Delete( BackupPath, true );

				backupinfo = Directory.CreateDirectory( BackupPath );
			}
			catch( Exception ex )
			{
				ErrorMessage = ex.Message + ".";
				return false;
			}

			try
			{
				CopyFilesRecursively( savedinfo, backupinfo );
			}
			catch( Exception ex )
			{
				ErrorMessage = ex.Message + ".";
				return false;
			}

			return true;
		}
		public static bool Restore()
		{
			if( !Directory.Exists( BackupPath ) )
			{
				ErrorMessage = "No backup save data to restore.";
				return false;
			}

			DirectoryInfo savedinfo = null,
						  backupinfo = null;

			try
			{
				backupinfo = new DirectoryInfo( BackupPath );

				if( Directory.Exists( SavedPath ) )
					Directory.Delete( SavedPath, true );

				savedinfo = new DirectoryInfo( SavedPath );

				CopyFilesRecursively( backupinfo, savedinfo );
			}
			catch( Exception ex )
			{
				ErrorMessage = ex.Message + ".";
				return false;
			}

			return true;
		}

		static void CopyFilesRecursively( DirectoryInfo source, DirectoryInfo target )
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
