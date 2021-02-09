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
  - debug of AsDocs2XML has the corrected docs for Overgrowth 1.4 passed as arguments and will write them into the Calltips Definitions\Overgrowth 1.4 folder
---
### Scripting Helper Plugin

##### AsDocs2XML
- Adding the core Angelscript functions/classes/enums that are enabled in Overgrowth into the database and calltips.

##### Angelscript UDL
- Adding the core Angelscript functions/classes/enums that are enabled in Overgrowth into the UDL.

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
- Plugins Menu
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