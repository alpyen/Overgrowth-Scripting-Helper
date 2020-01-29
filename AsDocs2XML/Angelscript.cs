using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.Xml;

namespace AsDocs2XML
{
    /*
     * This is where the magic happens!
     * 
     * The ASHelper class providers functions to parse the header documentations.
     * 
     */
    static class ASHelper
    {
        private enum LineType { Unknown, Ignorable, ClassBegin, Function, EnumerationBegin, Variable, ScopeEnding }

        // Don't judge me for these patterns! I barely know enough Regex to keep my head above the water level x)
        private static Regex rxIgnorable = new Regex(@"^\s*(?:\/\/.*)?$");
        private static Regex rxFunction = new Regex(@"^\s*((?:const)?\s*[^,\s]+?)\s*([^,\s]+?)\s*\(([^\/]*)\)\s*(const)?.*?$");
        private static Regex rxVariable = new Regex(@"^\s*(const)?\s*([^,\s}]+?)\s*([^,\s*\(};]+?)\s*;\s*$");
        private static Regex rxClassBegin = new Regex(@"^\s*class\s*(.+?)\s*{\s*.*?$");
        private static Regex rxEnumerationBegin = new Regex(@"^\s*enum\s*(.+?)\s*{\s*.*?$");
        private static Regex rxScopeEnding = new Regex(@"^\s*\};(?:\/\/.*)?\s*$");

        private static Regex rxParameters = new Regex(@"\s*((?:[^,\s]+\s*)+)\s*,?");
        private static Regex rxParameter = new Regex(@"^\s*(?:(?:(.+)\s+(.+?)\s*=\s*(.+))|(?:(.+)\s+(.+))|(.+))\s*$");
        private static Regex rxEnumerationValue = new Regex(@"^\s*([^,\s=]+)\s*=\s*-?(\d+)\s*,?\s*$");

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

                foreach (KeyValuePair<string, int> enumerationMember in asEnumeration.enumerationMembers)
                {
                    // TODO: Append by Value not by String sorting!

                    XmlElement xmlEnumerationMember = xmlDocument.CreateElement("EnumerationMember");
                    xmlEnumerationMember.SetAttribute("Name", enumerationMember.Key);
                    xmlEnumerationMember.SetAttribute("Value", enumerationMember.Value.ToString());
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

                    foreach(ASParameter asParameter in asOverload.parameters)
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
                // Console.WriteLine("[" + (lineIndex + 1) + ", " + lineType + "] = " + script[lineIndex] + "");

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
                // Console.WriteLine("[" + (lineIndex + 1) + ", " + lineType + "] = " + script[lineIndex] + "");

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
                    Convert.ToInt32(matchEnumerationMember.Groups[2].Value)
                );

                lineIndex++;
            }

            return asEnumeration;
        }

        private static ASOverload ParseOverload(string[] script, ref int lineIndex)
        {
            /*
             *  void RibbonItemSetEnabled(const string &in, bool);
             *  const vec3 opMul(const vec3 &in) const;
             *  const string &GetString (const string &in key);
             *  const float &opIndex(uint) const;
             *  JSON& opAssign(const JSON &in other);
             *  
             *  const string &GetString (const string &in key);
             *  const string &GetString (const string &in key, const string &out bla);
             *  bool ImGui_Begin(const string &in name, bool &inout is_open, int flags = 0); // bool ImGui_Begin(const string &in name, bool &inout is_open, ImGuiWindowFlags flags = 0)
             *  bool ImGui_BeginChild(const string &in str_id, const vec2 &in size = vec2(0,0), bool border = false, int extra_flags = 0); // bool ImGui_BeginChild(const string &in str_id, const vec2 &in size = vec2(0,0), bool border = false, ImGuiWindowFlags extra_flags = 0)
             */
            Match matchFunction = rxFunction.Match(script[lineIndex]);
            
            string returnType;
            string functionName;
            string parameters;
            bool constMethod;

            // The Regex will capture at most 4 groups.
            // (returnType) (functionName) (params) (const)

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

            // Since parameters can have defaultValues which might contain commas we can't simply split by a comma.
            // We need to split it by checking if the comma is inside a bracket, if it is, we don't split at that particular index.

            int bracketLevel = 0;
            int lastPos = 0;

            /*
             * rxParmeter matches different styles of parameters. If a certain style is not met the indices stay empty
             * and it will fill the indices with the matching style.
             * 
             * 1st Style: int a = 5
             * 2nd Style: int a
             * 3rd Style: int
             * 
             * [1] = type
             * [2] = name
             * [3] = defaultValue
             * 
             * [4] = type
             * [5] = name
             * 
             * [6] = type
             * 
             */

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters.Substring(i, 1) == "(")
                {
                    bracketLevel++;
                }
                else if (parameters.Substring(i, 1) == ")")
                {
                    bracketLevel--;
                }
                else if (parameters.Substring(i, 1) == "," || i == parameters.Length - 1)
                {
                    if (bracketLevel != 0) break; // Check if we are inside brackets

                    string currentParameter = parameters.Substring(lastPos, i - lastPos + (i == parameters.Length - 1 ? 1 : 0));
                    lastPos = i + 1;

                    Match matchParameter = rxParameter.Match(currentParameter);

                    string type;
                    string name;
                    string defaultValue;

                    if (matchParameter.Groups[1].Value != "")
                    {
                        type = matchParameter.Groups[1].Value;
                        name = matchParameter.Groups[2].Value;
                        defaultValue = matchParameter.Groups[3].Value;
                    }
                    else if (matchParameter.Groups[4].Value != "")
                    {
                        type = matchParameter.Groups[4].Value;
                        name = matchParameter.Groups[5].Value;
                        defaultValue = "";
                    }
                    else // matchParameter.Groups[6].Value != ""
                    {
                        type = matchParameter.Groups[6].Value;
                        name = "";
                        defaultValue = "";
                    }

                    if (name.Length > 0  && (name.Substring(0, 1) == "&" || name.Substring(0, 1) == "@"))
                    {
                        type += name.Substring(0, 1);
                        name = name.Substring(1);
                    }

                    ASParameter asParameter = new ASParameter(type, name, defaultValue);
                    asParameters.Add(asParameter);
                }
            }

            return asParameters;
        }

        private static ASVariable ParseVariable(string[] script, ref int lineIndex)
        {
            Match match = rxVariable.Match(script[lineIndex]);

            bool isConst;
            string type;
            string name;

            if (match.Groups.Count == 4)
            {
                isConst = true;
                type = match.Groups[2].Value;
                name = match.Groups[3].Value;
            }
            else // match.Groups.Count == 3
            {
                isConst = false;
                type = match.Groups[1].Value;
                name = match.Groups[2].Value;
            }

            return new ASVariable(isConst, type, name);
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

    /*
     * Mirroring the structure of the Angelscript scripts inside AsDocs2XML
     * 
     * We are using SortedLists to sort everything while parsing the files so we don't need to deal with
     * stupid XML sorting routines later when we are generating the Database.xml file! :)
     * 
     * Since some elements will be sorted by their name we don't actually need to save the name explicity
     * inside the element itself -- but we will do that anyway for completeness and uniformities sake.
     * 
     */
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

        //const string &in key
        //Campaign& opAssign(const Campaign &in other

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
        public bool isConst;
        public string type;
        public string name;

        public ASVariable(bool isConst, string type, string name)
        {
            this.isConst = isConst;
            this.type = type;
            this.name = name;
        }
    }
}
