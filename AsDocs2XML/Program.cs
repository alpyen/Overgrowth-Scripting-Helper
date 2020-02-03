using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AsDocs2XML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("AsDocs2XML - please load your corrected asdocs header files!");
            Console.WriteLine();

            /*
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Overgrowth Angelscript Header Documentaion Files|*.txt;*.h";
            fd.Title = "Select your corrected asdocs header files";
            fd.Multiselect = true;
            
            if (fd.ShowDialog() != DialogResult.OK) return;
            */

            string[] files = new string[]
            {
                "..\\..\\Corrected Docs\\Camera.txt",
                "..\\..\\Corrected Docs\\Character.txt",
                "..\\..\\Corrected Docs\\Hotspot.txt",
                "..\\..\\Corrected Docs\\Level.txt",
                "..\\..\\Corrected Docs\\Scriptable Campaign.txt",
                "..\\..\\Corrected Docs\\Scriptable UI.txt",
            };

            SortedList<string, ASScript> database = new SortedList<string, ASScript>();

            foreach (string file in files)
            {
                Console.WriteLine("Loading script: " + file);

                string scriptName = Path.GetFileNameWithoutExtension(file);
                string[] scriptLines = File.ReadAllLines(file);

                Console.WriteLine("Parsing script: " + scriptName);

                ASScript currentScript = ASHelper.ParseScript(scriptName, scriptLines);
                database.Add(currentScript.name, currentScript);

                Console.WriteLine();
            }

            XmlDocument xmlDatabase = new XmlDocument();
            XmlElement rootNode = xmlDatabase.CreateElement("Scripts");
            xmlDatabase.AppendChild(rootNode);

            foreach (ASScript currentScript in database.Values)
                ASHelper.AppendScriptAsXmlElement(rootNode, currentScript);

            xmlDatabase.Save("Database.xml");

            Console.WriteLine("All scripts have been parsed and the Database.xml has been written.");
            Console.WriteLine("Now writing calltips definition for the Angelscript UDL in Notepad++");

            XmlDocument xmlCalltips = NppHelper.GenerateXmlCalltipDefinition(database.Values.ToList());

            xmlCalltips.Save("angelscript.xml");

            Console.WriteLine();
            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}
