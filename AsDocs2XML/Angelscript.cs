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
        private static Regex rxFunction = new Regex(@"^\s*\s*((?:const)?\s*[^,\s]+?)\s*([^,\s]+?)\s*\(([^\)]*?)\)\s*(const)?.*?$");
        private static Regex rxVariable = new Regex(@"^\s*(const)?\s*([^,\s}]+?)\s*([^,\s*\(};]+?)\s*;\s*$");
        private static Regex rxClassBegin = new Regex(@"^\s*class\s*(.+?)\s*{\s*.*?$");
        private static Regex rxEnumerationBegin = new Regex(@"^\s*enum\s*(.+?)\s*{\s*.*?$");
        private static Regex rxScopeEnding = new Regex(@"^\s*\};(?:\/\/.*)?\s*$");

        private static Regex rxParameters = new Regex(@"\s*((?:[^,\s]+\s*)+)\s*,?");
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

                foreach(ASOverload asOverload in asFunction.overloads)
                {
                    // TODO: Generate full overload for SetAttribute(Name)
                    IEnumerable<string> parameters = asOverload.parameters.Select((parameter) => (parameter.type + " " + parameter.name));
                    string fullName = asOverload.returnType + " " + asOverload.name + "(" + string.Join(", ", parameters) + ")" + (asOverload.isConst ? " const" : "");

                    XmlElement xmlOverload = xmlDocument.CreateElement("Overload");
                    xmlOverload.SetAttribute("Type", asOverload.returnType);
                    xmlOverload.SetAttribute("Name", fullName);
                    xmlOverload.SetAttribute("Const", asOverload.isConst.ToString());
                    xmlFunction.AppendChild(xmlOverload);

                    foreach(ASParameter asParameter in asOverload.parameters)
                    {
                        // TODO: Print isConst, Name and Type in Parameter XML, not just the string

                        XmlElement xmlParameter = xmlDocument.CreateElement("Parameter");
                        xmlParameter.SetAttribute("Name", asParameter.name);
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

            /*<Scripts>
  <Camera>
    <Classes>
      <Class Name="ASCollisions">
        <Classes />
        <Enumerations />
        <Functions>
          <Function Name="CheckRayCollisionCharacters">
            <Overload Name="void CheckRayCollisionCharacters(vec3 start, vec3 end)">
              <Parameter Name="vec3 end" />
              <Parameter Name="vec3 start" />
            </Overload>
          </Function>
          
             <Enumerations>
      <Enumeration Name="CameraFlags">
        <EnumerationMember Name="kEditorCamera" Value="1" />
        <EnumerationMember Name="kPreviewCamera" Value="2" />
      </Enumeration>

      <Variables>
      <Variable Name="_awake" />
      <Variable Name="_collectable" />
      <Variable Name="_dead" />
             */
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
             *
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

            // Parsing Parameters
            // TODO: Implement parameter parsing

            asOverload.parameters.Add(new ASParameter("int", "lol"));
            asOverload.parameters.Add(new ASParameter("string", "notsolol"));

            return asOverload;
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

        //const string &in key
        //Campaign& opAssign(const Campaign &in other

        public ASParameter(string type, string name)
        {
            this.type = type;
            this.name = name;
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
