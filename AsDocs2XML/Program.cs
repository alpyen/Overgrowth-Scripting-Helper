using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace AsDocs2XML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("AsDocs2XML - please load your corrected asdocs header files!");

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
                string scriptName = Path.GetFileNameWithoutExtension(file).Replace(" ", "");
                string[] scriptLines = File.ReadAllLines(file);

                ASScript currentScript = new ASScript(scriptName, scriptLines);

                database.Add(currentScript.name, currentScript);
            }

            foreach (ASScript currentScript in database.Values)
            {
                Console.WriteLine(currentScript.name);
            }

            Console.ReadLine();



            /*
            static Regex regExFunction = new Regex(@"^\s*((const)?\s*([^,\s]+?)\s*([^,\s]+?)\s*\(([^\)]*?)\)\s*(const)?).*?$");
            static Regex regExVariable = new Regex(@"^\s*(const)?\s*([^,\s}]+?)\s*([^,\s*\(}]+?)\s*$");
            static Regex regExClass = new Regex(@"^\s*class\s*(.+?)\s*{\s*.*?$");
            static Regex regExEnum = new Regex(@"^\s*enum\s*(.+?)\s*{\s*.*?$");

            static Regex regExParams = new Regex(@"\s*((?:[^,\s]+\s*)+)\s*,?");
            static Regex regExEnumValue = new Regex(@"^\s*([^,\s=]+)\s*=\s*-?(\d+)\s*,?\s*$");
            */

            #region Verfahren
            /* 
             * Datei zeilenweise durchgehen?
             * Klasse gefunden?
             * Existiert currentRootNode.<Classes>? Wenn nicht erstellen
             *    currentRootNode.<Classes>.<vec3> hinzufügen
             *    appendScriptcontent(currentRootNode.<Classes>.<vec3>, script, begin = currentLine + 1)
             *      ^-> macht sein Ding und passt currentLine an. Die Parent Funktion wird dann bei der nächsten Iteration
             *          nicht mehr in der Klasse sein, weil currentLine angepasst wurde :)
             * 
             *    Variable gefunden?
             *        Existiert currentRootNode.<Variables>? Wenn nicht erstellen
             *        geparste Variable einfügen
             * 
             *    Funktion gefunden?
             *        Existiert currentRootNode.<Functions>? Wenn nicht erstellen
             *        geparste Funktion als Overload einfügen
             * 
             *    Enum gefunden?
             *       Existiert currentRootNode.<Enumerations>? Wenn nicht erstellen
             *        geparstes Enum einfügen
            */
            #endregion
        }
    }
}
