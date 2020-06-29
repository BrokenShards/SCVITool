// Program.cs //

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
		                    "`-r` or `-restore` to restore the backup. A slot index must be provided or this will fail.";

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
