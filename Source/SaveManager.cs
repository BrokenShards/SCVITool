//
// SaveManager.cs
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
using System.IO;

namespace SCVITool
{
	public static class SaveManager
	{
		public static string ErrorMessage
		{
			get; private set;
		} = string.Empty;

		public static bool Backup( int index = -1 )
		{
			if( !Directory.Exists( Constants.SavedPath ) )
			{
				ErrorMessage = "Unable to find save data to backup.";
				return false;
			}

			DirectoryInfo savedinfo  = null,
						  backupinfo = null;

			try
			{
				savedinfo = new DirectoryInfo( Constants.SavedPath );

				if( index < 0 )
				{
					string[] files = Directory.GetDirectories( Constants.BackupPath );

					for( int i = 0; i < int.MaxValue && index < 0; i++ )
					{
						string name = "save";

						if( i < 10 )
							name += '0';

						name += i.ToString();

						foreach( string f in files )
							if( f.ToLower() != name )
								index = i;

						if( i == int.MaxValue )
							throw new InvalidOperationException( "The maximum amount of save slots has been reached." );
					}
				}

				string bpath = "save";
				{
					if( index < 10 )
						bpath += '0';

					bpath += index.ToString();
					bpath = Path.Combine( Constants.BackupPath, bpath );
				}

				if( Directory.Exists( bpath ) )
					Directory.Delete( bpath, true );

				backupinfo = Directory.CreateDirectory( bpath );
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
		public static bool Restore( int index )
		{
			if( index < 0 )
			{
				ErrorMessage = "Cannot restore from an invalid save slot index.";
				return false;
			}

			string bpath = "save";
			{
				if( index < 10 )
					bpath += '0';

				bpath += index.ToString();
				bpath = Path.Combine( Constants.BackupPath, bpath );
			}

			if( !Directory.Exists( bpath ) )
			{
				ErrorMessage = "No backup save data to restore.";
				return false;
			}

			DirectoryInfo savedinfo = null,
						  backupinfo = null;

			try
			{
				backupinfo = new DirectoryInfo( bpath );

				if( Directory.Exists( Constants.SavedPath ) )
					Directory.Delete( Constants.SavedPath, true );

				savedinfo = new DirectoryInfo( Constants.SavedPath );

				CopyFilesRecursively( backupinfo, savedinfo );
			}
			catch( Exception ex )
			{
				ErrorMessage = ex.Message + ".";
				return false;
			}

			return true;
		}
		public static bool Delete( int index )
		{
			if( index < 0 )
			{
				ErrorMessage = "Cannot delete an save slot with an invalid index.";
				return false;
			}

			string bpath = "save";
			{
				if( index < 10 )
					bpath += '0';

				bpath += index.ToString();
				bpath = Path.Combine( Constants.BackupPath, bpath );
			}

			if( !Directory.Exists( bpath ) )
			{
				ErrorMessage = "Cannot delete data from a slot that does not exist.";
				return false;
			}
		
			try
			{
				Directory.Delete( bpath, true );
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
