Scripting Helper for the Overgrowth API as a Notepad++ plugin.
<br><br>

ToDo-List:
---
### README.md
- Introduction
- Requirements
  - NetFX 4
- How to download and install
- How to develop
  - autoComplete & plugins folder needs to be set writable if you don't want to start VS as admin (or use a portable n++ installation and adjust the build/copy paths). this is done to automatically move the angelscript.xml (calltips) and the database.xml into the notepad++ directory. the dll is moved by the targets file in the PluginInfrastructure/DllExport folder. Make sure that you ran AsDocs2XML and generated these files before you try to run the plugin.
  - Solution of AsDocs2XML has the corrected docs for Overgrowth 1.4 passed as command line arguments
  - angelscript.xml and database.xml are automoved into the N++ folders.
  - Docs in Overgrowth 1.4 lists push_back and size as functions, but they are methods from arrays.
  - Docs in Overgrowth 1.4 list vec4 mix as a method of vec4 but it is a function. The docs altogether are badly formatted. Pay close attention when you want to correct them for AsDocs2XML to parse.
  - The pre-build command does not copy the files on Run when the files are already there (calltips + database). You need to rebuild the solution again, they are copied on build, not on run. When you modify your code and run it, it automatically rebuilds.
---
### Scripting Helper Plugin

##### AsDocs2XML
- (later?) Expand parsing to parse .as files rather than .h, this way we could parse the files from the Data\Scripts directory. But only do this when the classes are actually available in other scripts.

##### Angelscript UDL

##### Helper Window
- (later?) Save every step while live filtering for faster reconstruction

##### Settings
- Design
- Live filtering mode
- Show icons for each node
- Custom Font
- Save on Button, Discard on Close

##### Cheat Sheet
- Display root folders for various paths

##### Plugins Menu
- Script Templates
  - missing some functions that were not listed on the documentation (like void Menu for Level)
- Toggle Cheat Sheet
- About (don't forget to credit silk icons)

##### Testing
- Windows 10