# <img width=32 height=32 src="Overgrowth++/Resources/rabbit.ico" /> Overgrowth++
Scripting Helper for the Overgrowth API as a Notepad++ plugin.

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
<br><br>

## Install
If you would like to compile it yourself you need Microsoft's Visual Studio (project was developed with VS2017)
and have the C++ developing enabled (so you can develop projects in C# and C++).

The latter is necessary because the NppPluginNET uses resources from that.<br>
If you don't want to install the C++ part you can download the needed leptonlib.dll and lib.exe and place
them inside ``C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\bin``.

Once you have set it up you can simply use "Rebuild Solution" and your DLL should be located here:<br>
``Overgrowth++\Overgrowth++\bin\x86\Release``

Now simply drop the Database.xml and Overgrowth++.dll into the plugin folder of Notepad++:
``Notepad++\plugins\Overgrowth++``

Now you can start Notepad++ and your plugin should appear in the toolbar and the menu.
<br><br>

## Development
Once you have set up your developing environment you can start modiyfing the code which is kept
nice and clean so you can navigate through it pretty easily.

<p style="color: red;">Please note that using the "execute commands post-build" in the project properties
does not work because the dll is moved to quickly before Visual Studio is completely done with it.<br><br>
You will get error messages so I recommend to copy it a second after the build was finished if you
try to automate it somehow with a helping script or some sort.</p>
<br>

### ToDo-List:
- Correct Icons in TreeView (specialize more)
- Show Overgrowth AngelScript in language menu so we don't need to misuse the C++ settings
- Cleanup Code
- Rework Calltips
- Use the last TreeView State for live filtering so it doesn't reconstruct the whole TreeView when a search expression is entered
- Write README.MD
- find more todos

 