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
			public const uint Minor = 1;
			public const uint Patch = 1;

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
		const string Help = "`SCVITool.exe [arg]`\n`-b` or `-backup` to perform a backup.\n`-r` or `-restore` to reastore the backup.";

		[STAThread]
		static int Main( string[] args )
		{
			if( args.Length > 0 )
			{
				Console.WriteLine( About );

				if( args.Length > 1 )
				{
					Console.WriteLine( Help );
					return -1;
				}

				string arg = args[ 0 ].ToLower();

				if( arg == "-b" || arg == "-backup" )
				{
					if( !SaveManager.Backup() )
					{
						Console.Write( "Backup failed: " );
						Console.WriteLine( SaveManager.ErrorMessage );
						return -2;
					}
				}
				else if( arg == "-r" || arg == "-restore" )
				{
					if( !SaveManager.Restore() )
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
