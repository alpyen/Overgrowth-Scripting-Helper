﻿using System;
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

                string scriptName = Path.GetFileNameWithoutExtension(file).Replace(" ", "");
                string[] scriptLines = File.ReadAllLines(file);

                Console.WriteLine("Parsing script: " + scriptName);

                ASScript currentScript = ASHelper.ParseScript(scriptName, scriptLines);
                database.Add(currentScript.name, currentScript);

                Console.WriteLine();
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
        }
    }
}
