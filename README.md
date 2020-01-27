# <img width=32 height=32 src="Overgrowth++/Resources/rabbit.ico" /> Overgrowth++
Scripting Helper for the Overgrowth API as a Notepad++ plugin. (netFX4 required)

Overgrowth++ provides helpful tools to assist in developing AngelScript code for Overgrowth.<br>
Because of the game's nature, there exist hundreds of classes, functions, enumerations and variables
which are all accessable via the game API but remembering all of them is impossible.

So, I embarked on a journey to build a tool which takes the load off your shoulders by providing
realtime calltip function parameters and a sidebar helper window which displays all the available
assets by the API sorted by script type (Character, Level, ...) with an additional filter and appearance options.
<br><br>

## Download & Usage
If you don't know how to handle a Visual Studio project I'd recommend you to download an
already pre-compiled and ready-to-go version on my website: https://ag.systems/projects/overgrowth++

There's also a tutorial on how to install it properly, it's very easy - don't worry.
All you need is 5 minutes.
<br><br>

## Install Project Solution
Clone the repo and open the solution with Visual Studio.<br>
After you've done that, you can simply hit 'Rebuild Solution' and your DLL should be located here:<br>
``Overgrowth++\bin\x64\Release``

Now simply drop the Database.xml and Overgrowth++.dll into the plugin folder of Notepad++:
``Notepad++\plugins\Overgrowth++``

Now you can start Notepad++ and your plugin should appear in the toolbar and the menu.
<br><br>

## Development
Once you have set up your developing environment you can start modiyfing the code which is kept
nice and clean so you can navigate through it pretty easily.

For better debugging the plugin a post-build command is issued in the ``Overgrowth++\PluginInfrastructure\DllExport\NppPlugin.DllExport.targets`` file to move the plugin automatically into the plugin folder of Notepad++ and run it with the external program option in the solution settings.

**Adjust the path for the plugin destination according to your install!**

I recommend to use a portable version of N++ because the standard installation required elevated privileges for Visual Studio to move files into the ProgramFiles directory.
Once you did that, you can simply hit 'Start Debugging' in Visual Studio and the plugin will be automatically moved into the N++ plugin folder and gets executed!

Writing Npp-Plugin Code in .NET is tedious because you have no way to debug your plugins in any way.
You are bound to using MessageBoxes if it seems to crash at random.
<br>

This project is in its early steps, don't expect these bugs to be fixed individually since a solid base will be established first.
When that is finished, many of these bugs will be no issue anymore.
Now that the migration to Windows 10 is done I'm trying to rework everything from scratch with error handlers to begin with, so I don't need to add them afterwards.

 ### Known Bugs/ToDo-List:

- **Overgrowth++ (Notepad++ Plugin)**
  - Live Search reconstructs full TreeView on each input change (should use last treeview though (while typing, not removing), much faster)
  - Live Search ignores last character
  - Live Search reacts on every keyhit, but should only on changed input
  - parameters are being split wrong if they have defaults like uv_a = vec2(0, 0) (needs fix in Calltips too)
  - search filters too everything, even the parameters of a matched function (although it should show all) (???)
  - Cleanup Code
  - Rework the appearance? Remove standard title bar and make it more appealing?

- **AsDocs2XML (Calltip-Parser)**
  - type of variables are not shown (Docs2XML needs to parse the type)
  - Rework Calltips (correct parsing, Docs2XML?)
  - Many unparsable lines in Docs2XML
  - Add Description to Calltips
  - Finalize resulting database.xml structure