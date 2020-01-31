using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace AsDocs2XML
{
	/*
	 * Just a small helper class to keep the Program.cs organized.
	 * It helps with generating a ready-to-save XmlDocument for the Notepad++ Angelscript calltips file.
	 *  
	 */
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

			foreach (ASScript asScript in scripts)
			{
				foreach (ASFunction asFunction in asScript.functions.Values)
				{
					// Does the function exist already?
					if (!allAsFunctions.ContainsKey(asFunction.name))
					{
						allAsFunctions.Add(asFunction.name, asFunction);
					}
					else
					{
						// Function exists already. Does it have new overloads?
						foreach (ASOverload asOverload2 in asFunction.overloads)
						{
							bool doesOverloadExist = false;

							foreach (ASOverload asOverload1 in allAsFunctions[asFunction.name].overloads)
							{
								string parameters1 = string.Join("", asOverload1.parameters.Select((parameter) => { return parameter.type + parameter.name + parameter.defaultValue; }));
								string parameters2 = string.Join("", asOverload2.parameters.Select((parameter) => { return parameter.type + parameter.name + parameter.defaultValue; }));

								bool returnTypeMatches = asOverload2.returnType == asOverload1.returnType;
								bool nameMatches = asOverload2.name == asOverload1.name;
								bool parametersMatches = parameters1 == parameters2;

								if (returnTypeMatches && nameMatches && parametersMatches)
								{
									doesOverloadExist = true;
									break;
								}
							}

							if (!doesOverloadExist)
							{
								allAsFunctions[asFunction.name].overloads.Add(asOverload2);
							}
						}
					}
				}
			}

			foreach (ASFunction asFunction in allAsFunctions.Values)
			{
				XmlElement xmlKeyWord = xmlCalltipDefinition.CreateElement("KeyWord");
				xmlKeyWord.SetAttribute("name", asFunction.name);
				xmlKeyWord.SetAttribute("func", "yes");
				xmlAutoComplete.AppendChild(xmlKeyWord);

				foreach (ASOverload asOverload in asFunction.overloads)
				{
					XmlElement xmlOverload = xmlCalltipDefinition.CreateElement("Overload");
					xmlOverload.SetAttribute("retVal", asOverload.returnType);
					xmlKeyWord.AppendChild(xmlOverload);
					
					foreach (ASParameter asParameter in asOverload.parameters)
					{
						XmlElement xmlParam = xmlCalltipDefinition.CreateElement("Param");
						xmlParam.SetAttribute("name", asParameter.type + (asParameter.name != "" ? " " + asParameter.name : "") + (asParameter.defaultValue != "" ? " = " + asParameter.defaultValue : ""));
						xmlOverload.AppendChild(xmlParam);
					}
				}
			}

            return xmlCalltipDefinition;
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