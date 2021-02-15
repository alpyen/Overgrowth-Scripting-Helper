using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Text.RegularExpressions;

namespace AsDocs2XML
{
	static class ASHelper
	{
		private enum LineType { Unknown, Ignorable, ClassBegin, Function, EnumerationBegin, Variable, ScopeEnding }

		private static Regex rxIgnorable = new Regex(@"^\s*(?:\/\/.*)?$");
		private static Regex rxFunction = new Regex(@"^\s*((?:const)?\s*[^,\s]+?)\s*([^,\s]+?)\s*\(([^\/]*)\)\s*(const)?.*?$");
		private static Regex rxVariable = new Regex(@"^\s*(const)?\s*([^,\s}]+?)\s*([^,\s*\(};]+?)\s*;\s*$");
		private static Regex rxClassBegin = new Regex(@"^\s*class\s*(.+?)\s*{\s*.*?$");
		private static Regex rxEnumerationBegin = new Regex(@"^\s*enum\s*(.+?)\s*{\s*.*?$");
		private static Regex rxScopeEnding = new Regex(@"^\s*\};?(?:\/\/.*)?\s*$");

		private static Regex rxParameter = new Regex(@"^\s*(.+?)\s*$");
		private static Regex rxEnumerationValue = new Regex(@"^\s*([^,\s=]+)\s*=?\s*(-)?\s*(\d+)?\s*,?\s*$");

		public static void AppendScriptAsXmlElement(XmlElement nodeAppend, dynamic asElement)
		{
			XmlDocument xmlDocument = nodeAppend.OwnerDocument;

			if (asElement.GetType() == typeof(ASScript))
			{
				ASScript asScript = (ASScript)asElement;
				XmlElement xmlScript = xmlDocument.CreateElement("Script");
				xmlScript.SetAttribute("Name", asScript.name);
				nodeAppend.AppendChild(xmlScript);

				XmlElement xmlClasses = xmlDocument.CreateElement("Classes");
				XmlElement xmlEnumerations = xmlDocument.CreateElement("Enumerations");
				XmlElement xmlFunctions = xmlDocument.CreateElement("Functions");
				XmlElement xmlVariables = xmlDocument.CreateElement("Variables");

				xmlScript.AppendChild(xmlClasses);
				xmlScript.AppendChild(xmlEnumerations);
				xmlScript.AppendChild(xmlFunctions);
				xmlScript.AppendChild(xmlVariables);

				foreach (ASClass asClass in asScript.classes.Values) AppendScriptAsXmlElement(xmlClasses, asClass);
				foreach (ASEnumeration asEnumeration in asScript.enumerations.Values) AppendScriptAsXmlElement(xmlEnumerations, asEnumeration);
				foreach (ASFunction asFunction in asScript.functions.Values) AppendScriptAsXmlElement(xmlFunctions, asFunction);
				foreach (ASVariable asVariable in asScript.variables.Values) AppendScriptAsXmlElement(xmlVariables, asVariable);
			}
			else if (asElement.GetType() == typeof(ASClass))
			{
				ASClass asClass = (ASClass)asElement;
				XmlElement xmlClass = xmlDocument.CreateElement("Class");
				xmlClass.SetAttribute("Name", asClass.name);
				nodeAppend.AppendChild(xmlClass);

				XmlElement xmlClasses = xmlDocument.CreateElement("Classes");
				XmlElement xmlEnumerations = xmlDocument.CreateElement("Enumerations");
				XmlElement xmlFunctions = xmlDocument.CreateElement("Functions");
				XmlElement xmlVariables = xmlDocument.CreateElement("Variables");

				xmlClass.AppendChild(xmlClasses);
				xmlClass.AppendChild(xmlEnumerations);
				xmlClass.AppendChild(xmlFunctions);
				xmlClass.AppendChild(xmlVariables);

				foreach (ASClass asClassInClass in asClass.classes.Values) AppendScriptAsXmlElement(xmlClasses, asClassInClass);
				foreach (ASEnumeration asEnumeration in asClass.enumerations.Values) AppendScriptAsXmlElement(xmlEnumerations, asEnumeration);
				foreach (ASFunction asFunction in asClass.functions.Values) AppendScriptAsXmlElement(xmlFunctions, asFunction);
				foreach (ASVariable asVariable in asClass.variables.Values) AppendScriptAsXmlElement(xmlVariables, asVariable);
			}
			else if (asElement.GetType() == typeof(ASEnumeration))
			{
				ASEnumeration asEnumeration = (ASEnumeration)asElement;
				XmlElement xmlEnumeration = xmlDocument.CreateElement("Enumeration");
				xmlEnumeration.SetAttribute("Name", asEnumeration.name);
				nodeAppend.AppendChild(xmlEnumeration);

				// Adding the enumerations sorted by their actual value not their name.
				// SortedList does not allow duplicate Keys therefore we use a normal list and sort it here.

				bool[] elementsUsed = new bool[asEnumeration.enumerationMembers.Count];
				int current = int.MinValue;
				int added = 0;

				while (added < asEnumeration.enumerationMembers.Count)
				{
					int nextSmallest = int.MaxValue;
					int nextSmallestIndex = -1;

					for (int i = 0; i < asEnumeration.enumerationMembers.Count; i++)
					{
						if (elementsUsed[i]) continue;
						if (asEnumeration.enumerationMembers.Values[i] <= nextSmallest)
						{
							nextSmallest = asEnumeration.enumerationMembers.Values[i];
							nextSmallestIndex = i;
						}
					}

					current = nextSmallest;
					elementsUsed[nextSmallestIndex] = true;
					added++;

					XmlElement xmlEnumerationMember = xmlDocument.CreateElement("Member");
					xmlEnumerationMember.SetAttribute("Name", asEnumeration.enumerationMembers.Keys[nextSmallestIndex]);
					xmlEnumerationMember.SetAttribute("Value", asEnumeration.enumerationMembers.Values[nextSmallestIndex].ToString());
					xmlEnumeration.AppendChild(xmlEnumerationMember);
				}
			}
			else if (asElement.GetType() == typeof(ASFunction))
			{
				ASFunction asFunction = (ASFunction)asElement;
				XmlElement xmlFunction = xmlDocument.CreateElement("Function");
				xmlFunction.SetAttribute("Name", asFunction.name);
				nodeAppend.AppendChild(xmlFunction);

				foreach (ASOverload asOverload in asFunction.overloads)
				{
					XmlElement xmlOverload = xmlDocument.CreateElement("Overload");
					xmlOverload.SetAttribute("Type", asOverload.returnType);
					xmlOverload.SetAttribute("Const", asOverload.isConst.ToString());
					xmlFunction.AppendChild(xmlOverload);

					foreach (ASParameter asParameter in asOverload.parameters)
					{
						XmlElement xmlParameter = xmlDocument.CreateElement("Parameter");
						xmlParameter.SetAttribute("Type", asParameter.type);
						xmlParameter.SetAttribute("Name", asParameter.name);
						xmlParameter.SetAttribute("Value", asParameter.defaultValue);
						xmlOverload.AppendChild(xmlParameter);
					}
				}
			}
			else if (asElement.GetType() == typeof(ASVariable))
			{
				ASVariable asVariable = (ASVariable)asElement;
				XmlElement xmlVariable = xmlDocument.CreateElement("Variable");
				xmlVariable.SetAttribute("Type", asVariable.type);
				xmlVariable.SetAttribute("Name", asVariable.name);
				nodeAppend.AppendChild(xmlVariable);
			}
		}

		public static ASScript ParseScript(string scriptName, string[] script)
		{
			ASScript asScript = new ASScript(scriptName);

			for (int lineIndex = 0; lineIndex < script.Length; lineIndex++)
			{
				LineType lineType = GetLineType(script[lineIndex]);

				switch (lineType)
				{
					case LineType.Unknown: break;
					case LineType.Ignorable: break;

					case LineType.ClassBegin:
						ASClass parseClass = ParseClass(script, ref lineIndex);
						asScript.classes.Add(parseClass.name, parseClass);

						break;

					case LineType.EnumerationBegin:
						ASEnumeration parseEnumeration = ParseEnumeration(script, ref lineIndex);
						asScript.enumerations.Add(parseEnumeration.name, parseEnumeration);

						break;

					case LineType.Function:
						ASOverload parseOverload = ParseOverload(script, ref lineIndex);

						// Check if the function already exists and then add the overload or create a new function first
						if (asScript.functions.ContainsKey(parseOverload.name))
						{
							asScript.functions[parseOverload.name].overloads.Add(parseOverload);
						}
						else
						{
							ASFunction asFunction = new ASFunction(parseOverload.name);
							asFunction.overloads.Add(parseOverload);
							asScript.functions.Add(asFunction.name, asFunction);
						}

						break;

					case LineType.Variable:
						ASVariable parseVariable = ParseVariable(script, ref lineIndex);
						asScript.variables.Add(parseVariable.name, parseVariable);

						break;
				}
			}

			return asScript;
		}

		private static ASClass ParseClass(string[] script, ref int lineIndex)
		{
			Match matchClass = rxClassBegin.Match(script[lineIndex]);
			ASClass asClass = new ASClass(matchClass.Groups[1].Value);

			lineIndex++;
			LineType lineType = GetLineType(script[lineIndex]);

			while (lineType != LineType.ScopeEnding)
			{
				switch (lineType)
				{
					case LineType.Unknown: break;
					case LineType.Ignorable: break;

					case LineType.ClassBegin:
						ASClass parseClass = ParseClass(script, ref lineIndex);
						asClass.classes.Add(parseClass.name, parseClass);
						break;

					case LineType.EnumerationBegin:
						ASEnumeration parseEnumeration = ParseEnumeration(script, ref lineIndex);
						asClass.enumerations.Add(parseEnumeration.name, parseEnumeration);
						break;

					case LineType.Function:
						ASOverload parseOverload = ParseOverload(script, ref lineIndex);

						// See ParseScript LineType.Function for explanation
						if (asClass.functions.ContainsKey(parseOverload.name))
						{
							asClass.functions[parseOverload.name].overloads.Add(parseOverload);
						}
						else
						{
							ASFunction asFunction = new ASFunction(parseOverload.name);
							asFunction.overloads.Add(parseOverload);
							asClass.functions.Add(asFunction.name, asFunction);
						}

						break;

					case LineType.Variable:
						ASVariable parseVariable = ParseVariable(script, ref lineIndex);
						asClass.variables.Add(parseVariable.name, parseVariable);

						break;
				}

				lineIndex++;
				lineType = GetLineType(script[lineIndex]);
			}

			return asClass;
		}

		private static ASEnumeration ParseEnumeration(string[] script, ref int lineIndex)
		{
			Match match = rxEnumerationBegin.Match(script[lineIndex]);
			ASEnumeration asEnumeration = new ASEnumeration(match.Groups[1].Value);

			lineIndex++;

			while (GetLineType(script[lineIndex]) != LineType.ScopeEnding)
			{
				Match matchEnumerationMember = rxEnumerationValue.Match(script[lineIndex]);

				asEnumeration.enumerationMembers.Add(
					matchEnumerationMember.Groups[1].Value,
					Convert.ToInt32(matchEnumerationMember.Groups[2].Value + matchEnumerationMember.Groups[3].Value)
				);

				lineIndex++;
			}

			return asEnumeration;
		}

		private static ASOverload ParseOverload(string[] script, ref int lineIndex)
		{
			Match matchFunction = rxFunction.Match(script[lineIndex]);

			string returnType;
			string functionName;
			string parameters;
			bool constMethod;

			returnType = matchFunction.Groups[1].Value;
			functionName = matchFunction.Groups[2].Value;
			parameters = matchFunction.Groups[3].Value;
			constMethod = matchFunction.Groups[4].Value == "const";

			if (functionName.Substring(0, 1) == "&" || functionName.Substring(0, 1) == "@")
			{
				returnType += functionName.Substring(0, 1);
				functionName = functionName.Substring(1);
			}

			ASOverload asOverload = new ASOverload(returnType, functionName, constMethod);
			asOverload.parameters = ParseParameters(parameters);

			return asOverload;
		}

		private static List<ASParameter> ParseParameters(string parameters)
		{
			List<ASParameter> asParameters = new List<ASParameter>();

			// Parsing parameters to distinguish between their type, name and defaultValue is a hard thing to do.
			// Explaining this is kinda complicated, basically we are going through the parameters
			// and checking if we are in a string or not (to determine the actual function parameters)
			// and then checking if the parameters have default values and names.

			// Sadly this impacts parsing speed, because this is probably not the fastest routine.

			// Don't parse if there are no parameters, and don't make special cases for void as the sole parameter.
			if (parameters.Replace(" ", "") == "" || parameters.Replace(" ", "").ToLower() == "void") return asParameters;

			// < > [ ] ( ) { } " " ' '
			int angleBracketLevel = 0;
			int arrayBracketLevel = 0;
			int normalBracketLevel = 0;
			int curlyBracketLevel = 0;

			bool inString = false;
			string stringStyle = "";

			int lastPos = 0;

			for (int i = 0; i < parameters.Length; i++)
			{
				string currentChar = parameters.Substring(i, 1);

				if (currentChar == "\"" || currentChar == "'")
				{
					if (inString)
					{
						// If we are in a string and read a non-escaped string mark which is equal
						// to the string style, then we have to leave the string.
						// No explicit bound checking, because no parameter begins with a " or '
						if (currentChar == stringStyle && parameters.Substring(i - 1, 1) != "\\")
						{
							inString = false;
						}
					}
					else // !inString
					{
						inString = true;
						stringStyle = currentChar;
					}
				}

				// Since we are in a string, we don't to check for the other conditions.
				if (inString) continue;

				switch (currentChar)
				{
					case "<": angleBracketLevel++; break;
					case ">": angleBracketLevel--; break;

					case "[": arrayBracketLevel++; break;
					case "]": arrayBracketLevel--; break;

					case "(": normalBracketLevel++; break;
					case ")": normalBracketLevel--; break;

					case "{": curlyBracketLevel++; break;
					case "}": curlyBracketLevel--; break;
				}

				// I know we can't theoretically drop below 0 but this check shows what's going on.
				bool bracketLevelZero = angleBracketLevel == 0 && arrayBracketLevel == 0 && normalBracketLevel == 0 && curlyBracketLevel == 0;

				if (bracketLevelZero && (currentChar == "," || i == parameters.Length - 1))
				{
					string currentParameter = parameters.Substring(lastPos, i - lastPos + (i == parameters.Length - 1 ? 1 : 0));
					lastPos = i + 1;

					// Split the parameter by the delimeter =.

					// If it splits atleast once, it means there is a default value.
					// Which means that [0] is the type + name (because they can't have an equal sign)
					// and [1] - [n-1] is the defaultValue.

					string[] splitParameter = currentParameter.Split('=');

					string typeAndName;

					string type;
					string name;
					string defaultValue = "";

					if (splitParameter.Length == 1) // No = found.
					{
						typeAndName = currentParameter;
					}
					else
					{
						typeAndName = splitParameter[0];
						defaultValue = string.Join("", splitParameter, 1, splitParameter.Length - 1);
					}

					// Remove beginning and trailing whitespaces.
					typeAndName = rxParameter.Match(typeAndName).Groups[1].Value;
					defaultValue = rxParameter.Match(defaultValue).Groups[1].Value;

					// Clean up the parameter because this is allowed (cleaning up the defaultValue might alter it)
					// and because we need to check for the possible missing identifier later.

					do
					{
						typeAndName = typeAndName.Replace("  ", " ");
					} while (typeAndName.Contains("  "));

					typeAndName = typeAndName.Replace(" &", "& ").Replace(" @", "@ ");
					typeAndName = typeAndName.Replace("&in", "& in").Replace("&out", "& out"); // Also gets &inout -> & inout

					// Determine if typeAndName contains an identifier (name).
					// Split by whitespaces, if it doesn't split, it doesnt contain an identifier.
					// If it splits, check the last index, replace "&"and"@" with "", if it matches "in" "out" "inout" "const" or any reserved keyword (type) then it doesnt have an identifier

					string[] splitName = typeAndName.Split(' ');

					if (splitName.Length == 1) // Couldn't split.
					{
						type = typeAndName;
						name = "";
					}
					else
					{
						string possibleIdentifier = splitName[splitName.Length - 1];

						string[] typeOperators = new string[] { "&", "@", "<", ">", "?" };
						bool containsOperator = false;

						foreach (string typeOperator in typeOperators)
						{
							if (possibleIdentifier.Contains(typeOperator))
							{
								containsOperator = true;
								break;
							}
						}

						if (containsOperator) // -> possibleIdentifier is not an identifier, it is a type
						{
							type = typeAndName;
							name = "";
						}
						else
						{
							// possibleIdentifier doesn't contain any of the symbols above, so we don't need to check for them.

							// We should actually check every possible used name, but this would drastically reduce our performance.
							// Just check the sane ones, like actual primitive types and classes.

							// Overgrowth 1.4 types
							string noIdentifiers =
								"void bool int8 int16 int int64 uint8 uint16 uint uint64 float double auto function funcdef class interface" +
								" enum namespace import const cast string array T BoneTransform C_ACCEL CItem CollisionPoint ConnectionType" +
								" ContainerAlignment dictionary dictionaryValue DividerOrientation EntityType EnvObject FontSetup Hotspot HUDImage" +
								" IMChangeImageFadeOutIn IMChangeTextFadeOutIn IMContainer IMDivider IMElement IMFadeIn IMFixedMessageOnClick" +
								" IMFixedMessageOnMouseOver IMGUI IMImage IMMessage IMMouseClickBehavior IMMouseOverBehavior IMMouseOverFadeIn" +
								" IMMouseOverMove IMMouseOverPulseBorder IMMouseOverPulseBorderAlpha IMMouseOverPulseColor IMMouseOverScale" +
								" IMMouseOverShowBorder IMMoveIn IMPulseAlpha IMPulseBorderAlpha IMSpacer IMText IMTextSelectionList IMTweenType" +
								" IMUIContext IMUIImage IMUIText IMUpdateBehavior ItemObject ivec2 ivec3 ivec4 JSON JSONValue JsonValueType" +
								" LevelDetails LevelSetReader LogType mat3 mat4 ModID ModLevel MovementObject NavPath NavPoint Object Parameter" +
								" PlaceholderObject quaternion RiggedObject SavedChunk SavedLevel ScriptParams SizePolicy Skeleton SplitScreenMode" +
								" TextCanvasTexture TextMetrics TextureAssetRef UIMouseState UIState UserVote vec2 vec3 vec4 in out inout"
							;

							string[] splitNoIdentifiers = noIdentifiers.Split(' ');
							bool containsType = false;

							foreach (string noIdentifier in splitNoIdentifiers)
							{
								if (typeAndName.ToLower() == noIdentifier.ToLower())
								{
									containsType = true;
									break;
								}
							}

							if (containsType)
							{
								type = typeAndName;
								name = "";
							}
							else
							{
								type = string.Join(" ", splitName, 0, splitName.Length - 1);
								name = splitName[splitName.Length - 1];
							}
						}
					}

					// Cleaning up the defaultValue is not worth the extra effort.
					// They are mostly fine, sometimes you find a uint ( - 1) or (vec2(0,0) and vec2(0, 0)) but that's about it

					ASParameter asParameter = new ASParameter(type, name, defaultValue);
					asParameters.Add(asParameter);
				}
			}

			return asParameters;
		}

		private static ASVariable ParseVariable(string[] script, ref int lineIndex)
		{
			Match match = rxVariable.Match(script[lineIndex]);

			string type;
			string name;

			type = (match.Groups[1].Value != "" ? "const " : "") + match.Groups[2].Value;
			name = match.Groups[3].Value;

			return new ASVariable(type, name);
		}

		private static LineType GetLineType(string line)
		{
			if (rxIgnorable.IsMatch(line)) return LineType.Ignorable;
			if (rxFunction.IsMatch(line)) return LineType.Function;
			if (rxVariable.IsMatch(line)) return LineType.Variable;
			if (rxClassBegin.IsMatch(line)) return LineType.ClassBegin;
			if (rxEnumerationBegin.IsMatch(line)) return LineType.EnumerationBegin;
			if (rxScopeEnding.IsMatch(line)) return LineType.ScopeEnding;

			return LineType.Unknown;
		}
	}

	struct ASScript
	{
		public string name;

		public SortedList<string, ASClass> classes;
		public SortedList<string, ASEnumeration> enumerations;
		public SortedList<string, ASFunction> functions;
		public SortedList<string, ASVariable> variables;

		public ASScript(string name)
		{
			this.name = name;

			this.classes = new SortedList<string, ASClass>();
			this.enumerations = new SortedList<string, ASEnumeration>();
			this.functions = new SortedList<string, ASFunction>();
			this.variables = new SortedList<string, ASVariable>();
		}
	}

	struct ASClass
	{
		public string name;
		public SortedList<string, ASClass> classes;
		public SortedList<string, ASEnumeration> enumerations;
		public SortedList<string, ASFunction> functions;
		public SortedList<string, ASVariable> variables;

		public ASClass(string name)
		{
			this.name = name;

			this.classes = new SortedList<string, ASClass>();
			this.enumerations = new SortedList<string, ASEnumeration>();
			this.functions = new SortedList<string, ASFunction>();
			this.variables = new SortedList<string, ASVariable>();
		}
	}

	struct ASFunction
	{
		public string name;
		public List<ASOverload> overloads;

		public ASFunction(string name)
		{
			this.name = name;

			this.overloads = new List<ASOverload>();
		}
	}

	struct ASOverload
	{
		public string returnType;
		public string name;
		public List<ASParameter> parameters;
		public bool isConst;

		public ASOverload(string returnType, string name, bool isConst)
		{
			this.returnType = returnType;
			this.name = name;
			this.isConst = isConst;

			this.parameters = new List<ASParameter>();
		}
	}

	struct ASParameter
	{
		public string type;
		public string name;
		public string defaultValue;
		public ASParameter(string type, string name, string defaultValue)
		{
			this.type = type;
			this.name = name;
			this.defaultValue = defaultValue;
		}
	}

	struct ASEnumeration
	{
		public string name;

		// Attention! We are inserting the enumeration members with their string as the key.
		// This will result in the list being sorted by the name -- however we want the opposite.
		// The items will be sorted by their value when written to the Database.xml
		public SortedList<string, int> enumerationMembers;

		public ASEnumeration(string name)
		{
			this.name = name;
			this.enumerationMembers = new SortedList<string, int>();
		}
	}

	struct ASVariable
	{
		public string type;
		public string name;

		public ASVariable(string type, string name)
		{
			this.type = type;
			this.name = name;
		}
	}
}
