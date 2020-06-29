# SCVITool
SCVITool is a very simple tool for backing up and restoring Soulcalibur VI save data.<br>
I made SCVITool for myself to backup my save data as Soulcalibur VI can corrupt saves seemingly randomly.<br>
You are free to use this software as you wish, but I do not take any responsibility for lost data, corrupt files or any
form of damage that may occur.

## Usage
The SCVI save folder is located in `%localappdata%\SoulcaliburVI\`.<br>
Backing up will will check if the `Saved` folder exists, and if so create a copy of it alongside the SCVITools binary.
Any existing backups on the same slot will be overwritten without warning.<br>
Restoring will check if a backup exists in the given slot, and if so, it will delete the SCVI `Saved` folder and replace
it with the backup in the slot.<br>

### WARNING
SCVITool does not check or verify the save slots, it only checks if the folder exists. If you try to restore a save slot
that is just an empty folder, your save will be deleted and replaced with an empty folder! You have been warned!<br>

### GUI
The GUI application provides an option to set a backup slot and has buttons to backup and restore. That's it.

### Console Arguments
`-b [index]` or `-backup [index]` to perform a backup. If the index is ommitted, the next available index will be used.<br>
`-r [index]` or `-restore [index]` to restore the backup. This will fail if a valid index is not provided.<br>

## TODO
- Maybe look into how custom characters are stored and implement some way of backing them up individually if possible.

## Changelog
### Version 0.2.1
- Now backups can be deleted with SCVITool.

### Version 0.2.0
- Now backups are stored alongside SCVITool.
- Multiple backup slots are now supported and can be managed in both the GUI and console.

### Version 0.1.1
- Implemented console functionality and refactored the project.

### Version 0.1.0
- Initial release.

