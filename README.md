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
  - plugins folder needs to be set writable if you don't want to start VS as admin (or use a portable n++ installation and adjust the build/copy paths)
  - debug of AsDocs2XML has the corrected docs for Overgrowth 1.4 passed as arguments
  - Docs in Overgrowth 1.4 lists push_back and size as functions, but they are methods from arrays.
  - Docs in Overgrowth 1.4 list vec4 mix as a method of vec4 but it is a function. The docs altogether are badly formatted. Pay close attention when you want to correct them for AsDocs2XML to parse.
---
### Scripting Helper Plugin

##### AsDocs2XML
- Switch the return types of the class constructors (void f) to their respective class type (vec3 f)?

##### Angelscript UDL
- Check if C_ACCEL is a bug, what is it used for?

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