//
// Constants.cs
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
using System.Reflection;

namespace SCVITool
{
	public static class Constants
	{
		public static readonly string AppDataPath = Path.Combine( Environment.GetFolderPath(
			Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.None ), "SoulcaliburVI" );
		public static readonly string SavedPath = Path.Combine( AppDataPath, "Saved" );

		public static readonly string ExecutablePath = GetExecutablePath();
		public static readonly string BackupPath = Path.Combine( ExecutablePath, "\\Backups" );
		
		static string GetExecutablePath()
		{
			string path = Path.GetDirectoryName( Assembly.GetExecutingAssembly().CodeBase );

			try
			{
				string s5  = path.Substring( 0,  5 ).ToLower();
				string s6  = path.Substring( 0,  6 ).ToLower();
				string s8  = path.Substring( 0,  8 ).ToLower();
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
}
