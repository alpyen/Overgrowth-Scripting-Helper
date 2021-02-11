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
---
### Scripting Helper Plugin

##### AsDocs2XML
- Some parameters are wrongly parsed when there are spaces. `<Parameter Type="const T&amp;" Name="in" Value="" /> ` The in is not the actual name.
- (later?) Expand parsing to parse .as files rather than .h, this way we could parse the files from the Data\Scripts directory. But only do this when the classes are actually available in other scripts.

##### Angelscript UDL

##### Helper Window
- Designing the dock window
- Showing Definitions in Tabs
- Filtering definitions with a search term

##### Settings
- Show helper sidebar window on startup
- Live filtering mode
- Hide parameter names in function signatures
- Show icons for each node
- Custom Font

##### Cheat Sheet
- Display root folders for various paths

##### Plugins Menu
  - Toggle Helper Window
  - Insert empty script templates
    - Camera
    - Character
    - Hotspot
    - Level
    - Scriptable Campaign(?)
    - Scriptable UI(?)
  - Toggle Cheat Sheet
  - Open Settings
  - About