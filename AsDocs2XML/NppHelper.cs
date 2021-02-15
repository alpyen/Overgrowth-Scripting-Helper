using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace AsDocs2XML
{
	static class NppHelper
	{
		public static XmlDocument GenerateXmlCalltipDefinition(List<ASScript> scripts)
		{
			XmlDocument xmlCalltipDefinition = new XmlDocument();
			XmlDeclaration xmlDeclaration = xmlCalltipDefinition.CreateXmlDeclaration("1.0", "Windows-1252", "");

			XmlElement rootNode = xmlCalltipDefinition.CreateElement("NotepadPlus");
			xmlCalltipDefinition.AppendChild(rootNode);

			xmlCalltipDefinition.InsertBefore(xmlDeclaration, rootNode);

			XmlElement xmlAutoComplete = xmlCalltipDefinition.CreateElement("AutoComplete");
			xmlAutoComplete.SetAttribute("language", "Angelscript");
			rootNode.AppendChild(xmlAutoComplete);

			XmlElement xmlEnvironment = xmlCalltipDefinition.CreateElement("Environment");
			xmlEnvironment.SetAttribute("ignoreCase", "no");
			xmlEnvironment.SetAttribute("startFunc", "(");
			xmlEnvironment.SetAttribute("stopFunc", ")");
			xmlEnvironment.SetAttribute("paramSeparator", ",");
			xmlEnvironment.SetAttribute("terminal", ";");
			xmlEnvironment.SetAttribute("additionalWordChar", "");
			xmlAutoComplete.AppendChild(xmlEnvironment);

			// Do not parse methods for calltips since Notepad++ is not able to dynamically
			// distinguish on an object what type it is and display the correct calltips like Visual Studio!

			SortedList<string, ASFunction> allAsFunctions = new SortedList<string, ASFunction>();
			SortedList<string, List<string>> supportedScriptsByOverload = new SortedList<string, List<string>>();

			foreach (ASScript asScript in scripts)
			{
				foreach (ASFunction asFunction in asScript.functions.Values)
				{
					// Iterate through all functions from all scripts and attach all the possible overloads to the function
					// in the list allAsFunctions.

					// Does the function exist already?
					if (!allAsFunctions.ContainsKey(asFunction.name))
					{
						allAsFunctions.Add(asFunction.name, asFunction);
					}
					else
					{
						// Function exists already. Does it have new overloads?
						foreach (ASOverload asOverload in asFunction.overloads)
						{
							string overloadSignature = asOverload.name + string.Join("", asOverload.parameters.Select((parameter) => { return parameter.value; }));

							bool doesOverloadExist = false;

							foreach (ASOverload asOverload2 in allAsFunctions[asFunction.name].overloads)
							{
								string overloadSignature2 = asOverload2.name + string.Join("", asOverload2.parameters.Select((parameter) => { return parameter.value; }));

								if (overloadSignature == overloadSignature2)
								{
									doesOverloadExist = true;
									break;
								}
							}

							if (!doesOverloadExist)
							{
								allAsFunctions[asFunction.name].overloads.Add(asOverload);
							}
						}
					}

					// Iterate through the overloads of the current function and save the script name they appeared in.
					foreach (ASOverload asOverload in asFunction.overloads)
					{
						string overloadSignature = asOverload.name + string.Join("", asOverload.parameters.Select((parameter) => { return parameter.value; }));

						if (!supportedScriptsByOverload.ContainsKey(overloadSignature))
						{
							supportedScriptsByOverload.Add(overloadSignature, new List<string>() { asScript.name });
						}
						else
						{
							supportedScriptsByOverload[overloadSignature].Add(asScript.name);
						}
					}
				}
			}

			// Run through all found functions and create the xml elements.
			// Check on each overload which scripts are supported and attach them.
			foreach (ASFunction asFunction in allAsFunctions.Values)
			{
				XmlElement xmlKeyWord = xmlCalltipDefinition.CreateElement("KeyWord");
				xmlKeyWord.SetAttribute("name", asFunction.name);
				xmlKeyWord.SetAttribute("func", "yes");
				xmlAutoComplete.AppendChild(xmlKeyWord);

				foreach (ASOverload asOverload in asFunction.overloads)
				{
					string overloadSignature = asOverload.name + string.Join("", asOverload.parameters.Select((parameter) => { return parameter.value; }));

					XmlElement xmlOverload = xmlCalltipDefinition.CreateElement("Overload");
					xmlOverload.SetAttribute("retVal", asOverload.returnType);
					xmlOverload.SetAttribute("descr", "" + Environment.NewLine + "Supported Scripts: " + string.Join(", ", supportedScriptsByOverload[overloadSignature]));
					xmlKeyWord.AppendChild(xmlOverload);

					foreach (ASParameter asParameter in asOverload.parameters)
					{
						XmlElement xmlParam = xmlCalltipDefinition.CreateElement("Param");
						xmlParam.SetAttribute("name", asParameter.value);
						xmlOverload.AppendChild(xmlParam);
					}
				}
			}

			return xmlCalltipDefinition;
		}

		private static string GetOverloadSignatureWithoutIdentifiers(ASOverload asOverload)
		{

			return "";
		}
	}
}

/*
<?xml version="1.0" encoding="Windows-1252" ?>
<NotepadPlus>
	<AutoComplete language="Angelscript">
		<Environment ignoreCase="no" startFunc="(" stopFunc=")" paramSeparator="," terminal=";" additionalWordChar=""/>
		<!--
		The following items should be alphabetically ordered.
		func="yes" means the keyword should be treated as a fuction, and thus can be used in the parameter
		calltip system. If this is the case, the retVal attribute specifies the return value/type. Any
		following Param tag specifies a parameter, they must be in order. The name attributes specifies
		the parameter name.
		-->
		<KeyWord name="acosl" />
		<KeyWord name="address" />
		<KeyWord name="adjacent_difference" />
		<KeyWord name="adjacent_find" />
		<KeyWord name="advance" />
		<KeyWord name="allocate" />
		<KeyWord name="atexit" func="yes">
			<Overload retVal="int" descr="asdasd">
				<Param name="void (*func)(void)"/>
			</Overload>
		</KeyWord>
	</AutoComplete>
</NotepadPlus>
*/