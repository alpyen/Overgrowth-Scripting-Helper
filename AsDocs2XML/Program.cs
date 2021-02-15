using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;

namespace AsDocs2XML
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("AsDocs2XML - Convert Overgrowth Angelscript Docs to XML Database and Calltips.\n");
			Console.WriteLine("If you pass a file with the name \"stl.txt\" it will be added to all scripts.\n");

			if (args.Length == 0)
			{
				Console.WriteLine("No files have been passed -- pass them through the command line or drag them onto the exe directly.\n");

				Console.WriteLine("Press enter to exit.");
				Console.ReadLine();

				return;
			}

			SortedList<string, ASScript> database = new SortedList<string, ASScript>();

			string[] stlContents = new string[] { };
			for (int i = 0; i < args.Length; i++)
			{
				if (Path.GetFileName(args[i]) == "stl.txt")
				{
					Console.WriteLine("STL found: " + (Path.GetDirectoryName(args[i]) != "" ? "..." : "") + Path.GetFileName(args[i]));

					stlContents = File.ReadAllLines(args[i]);
					List<string> tmp_args = new List<string>(args);
					tmp_args.RemoveAt(i);

					args = tmp_args.ToArray();

					break;
				}
			}


			foreach (string file in args)
			{
				string scriptName = Path.GetFileNameWithoutExtension(file);

				Console.WriteLine("Parsing script [" + scriptName + "]: " + (Path.GetDirectoryName(file) != "" ? "..." : "") + Path.GetFileName(file));

				ASScript currentScript = ASHelper.ParseScript(scriptName, stlContents.Concat(File.ReadAllLines(file)).ToArray());
				database.Add(currentScript.name, currentScript);
			}


			XmlDocument xmlDatabase = new XmlDocument();
			XmlElement rootNode = xmlDatabase.CreateElement("Scripts");
			xmlDatabase.AppendChild(rootNode);

			foreach (ASScript currentScript in database.Values)
				ASHelper.AppendScriptAsXmlElement(rootNode, currentScript);

			XmlDocument xmlCalltips = NppHelper.GenerateXmlCalltipDefinition(database.Values.ToList());


			Console.WriteLine();

			Console.WriteLine("Writing database.xml (database for helper).");
			xmlDatabase.Save("database.xml");

			Console.WriteLine("Writing angelscript.xml (calltips definition).");
			xmlCalltips.Save("angelscript.xml");

			Console.WriteLine();
			Console.WriteLine("Finished. Press enter to exit.");

			Console.ReadLine();
		}
	}
}
