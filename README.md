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
---
### Scripting Helper Plugin

##### AsDocs2XML
- Core functions + features added, need to add some primitives as pseudo-classes (string, array, ...) so that the operators don't show in the global functions.
- Add unknown type (?) used for multiple types in a datastructure rather than a generic
- Game (1.4) uses AS 2_32_0. Enabled features: 
  - RegisterStdString (Fully enabled and usable)
  - RegisterScriptArray (Fully enabled and usable)
  - adds some methods to arrays (push_back) (these should be in the .h)
  - RegisterScriptDictionary (Fully enabled and usable)
  - RegisterStdStringUtils (Fully enabled and usable)
  - string.findLastNotOf bugged (fixed in 2.33.0)

##### Angelscript UDL
- Adding the core Angelscript functions/classes/enums (also unknown types/generic types) that are enabled in Overgrowth into the UDL.

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