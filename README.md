Scripting Helper for the Overgrowth API as a Notepad++ plugin.
<br><br>

ToDo-List:
---
### README.md
- Introduction
- Requirements
  - NetFX 4
- How to download and install
  - head over to releases
  - download the latest zip (32/64bit matters to notepad++)
  - copy the "plugins" folder into the notepad++ root folder (C:\Program Files\Notepad++\ on 64bit) (C:\Program Files (x86)\Notepad++\ on 32bit)
    - there is/mightbe already a plugins folder, just merge the contents (out of convenience)
  - run notepad++ the plugin should be visible in the plugins menu (Overgrowth Scripting Helper) and there should be a rabbit button in the menu bar
  - install the UDL (angelscript language definition) by going navigating through the menu: Lanugages > User Defined Languages > Open folder with user defined language
  - paste the Angelscript UDL.xml in the folder and restart notepad++
  - Notepad++ should now autodetect .as files correctly and use the added UDL. If it doesn't select Angelscript manually in the Languages menu.
  - If the languages resets to Actionscript (because they share the same extension, you can disable the other language by Settings > Options > Languages and then shifting it from the left to the right.
- How to develop
  - autoComplete & plugins folder needs to be set writable if you don't want to start VS as admin (or use a portable n++ installation and adjust the build/copy paths). this is done to automatically move the angelscript.xml (calltips) and the database.xml into the notepad++ directory. the dll is moved by the targets file in the PluginInfrastructure/DllExport folder. Make sure that you ran AsDocs2XML and generated these files before you try to run the plugin.
  - Solution of AsDocs2XML has the corrected docs for Overgrowth 1.4 passed as command line arguments
  - angelscript.xml and database.xml are automoved into the N++ folders, but Angelscript UDL.xml isn't.
  - Docs in Overgrowth 1.4 lists push_back and size as functions, but they are methods from arrays.
  - Docs in Overgrowth 1.4 list vec4 mix as a method of vec4 but it is a function. The docs altogether are badly formatted. Pay close attention when you want to correct them for AsDocs2XML to parse.
  - The pre-build command does not copy the files on Run when the files are already there (calltips + database). You need to rebuild the solution again, they are copied on build, not on run. When you modify your code and run it, it automatically rebuilds.
  - The name attribute in the UDL references the actual filename (not the language attribute referenced in it) of the autocompletion (angelscript.xml) otherwise I would've named it Overgrowth Angelscript 1.4 (adding the version number) without running the risk of having multiple UDLs or autocompletions.

### Scripting Helper Plugin

##### AsDocs2XML
- (later?) Expand parsing to parse .as files rather than .h, this way we could parse the files from the Data\Scripts directory. But only do this when the classes are actually available in other scripts.

##### Angelscript UDL

##### Helper Window
- (later?) Save every step while live filtering for faster reconstruction
- (later?) Nightmode for the treeview?
  - Change the transparency of the treeview icons to the treeview's BackColor so it doesn't look glitched.
- Maybe do not attach fulltext for searching and just the necessary keywords?
- Search only on the visible text and not on the full text?
  - This implies that overloads will not expand if the function name is not visible.

##### Settings
- (later?) Set windows ontoppable

##### Cheat Sheet
- (later?) StartLocation.CenterParent from Main.cs (need to get the location and size of the notepad++ window)

##### Plugins Menu
- Script Templates
  - (later?) Scriptable Campaign, Scriptable UI?

##### Testing
- Windows 10