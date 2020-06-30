//
// Program.cs
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
using System.Text;
using System.Windows.Forms;

namespace SCVITool
{
	static class Program
	{
		static class Version
		{
			public const uint Major = 0;
			public const uint Minor = 2;
			public const uint Patch = 0;

			public new static string ToString()
			{
				StringBuilder sb = new StringBuilder();

				sb.Append( Major );
				sb.Append( '.' );
				sb.Append( Minor );
				sb.Append( '.' );
				sb.Append( Patch );

				return sb.ToString();
			}
		}

		static readonly string About = "SCVITool Version " + Version.ToString();
		const string Help = "`SCVITool.exe [arg] [index]`\n" +
		                    "`-b` or `-backup` to perform a backup. The next available slot will be used if an index is not provided.\n" + 
		                    "`-r` or `-restore` to restore the backup. A slot index must be provided or this will fail.\n" +
		                    "`-d` or `-delete` to delete the backup. A slot index must be provided or this will fail.\n";

		[STAThread]
		static int Main( string[] args )
		{
			if( args.Length > 0 )
			{
				Console.WriteLine( About );

				if( args.Length > 2 )
				{
					Console.WriteLine( Help );
					return -1;
				}

				string arg = args[ 0 ].ToLower();

				int index = -1;

				if( args.Length > 1 )
				{
					if( !int.TryParse( args[ 1 ], out index ) )
					{
						Console.Write( "Unable to parse \"" );
						Console.Write( args[ 1 ] );
						Console.WriteLine( "\" as an integer." );
						return -3;
					}
				}

				if( arg == "-b" || arg == "-backup" )
				{
					if( !SaveManager.Backup( index ) )
					{
						Console.Write( "Backup failed: " );
						Console.WriteLine( SaveManager.ErrorMessage );
						return -2;
					}
				}
				else if( arg == "-r" || arg == "-restore" )
				{
					if( !SaveManager.Restore( index ) )
					{
						Console.Write( "Restoration failed: " );
						Console.WriteLine( SaveManager.ErrorMessage );
						return -2;
					}
				}
				else if( arg == "-d" || arg == "-delete" )
				{
					if( !SaveManager.Delete( index ) )
					{
						Console.Write( "Deletion failed: " );
						Console.WriteLine( SaveManager.ErrorMessage );
						return -2;
					}
				}
				else
				{
					Console.WriteLine( Help );
					return -1;
				}
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );
				Application.Run( new MainForm() );
			}

			return 0;
		}
	}
}
