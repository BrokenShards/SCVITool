# SCVITool
SCVITool is a very simple tool for backing up and restoring Soulcalibur VI save data.<br>
I made SCVITool for myself to backup my save data as Soulcalibur VI can corrupt saves seemingly randomly.<br>
You are free to use this software as you wish, but I do not take any responsibility for lost data, corrupt files or any
form of damage that may occur.

## Usage
The SCVI save folder is located in `%localappdata%\SoulcaliburVI\`.<br>
Backing up will will check if the `Saved` folder exists, and if so create a copy of it in `Saved_Backup`. An existing backup will be overwritten without warning.<br>
Restoring will check if the `Saved_Backup` folder exists, and if so, it will delete the `Saved` folder and replace it with the contents of `Saved_Backup`.<br>

### GUI
The GUI application provides buttons to backup and restore. That's it.

### Console Arguments
`-b` or `-backup` to perform a backup.<br>
`-r` or `-restore` to restore the backup.<br>

## TODO
- Implement multiple backup "slots" that can be managed in both GUI and console.
