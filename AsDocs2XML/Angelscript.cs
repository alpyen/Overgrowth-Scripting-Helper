using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

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
        private static Regex rxFunction = new Regex(@"^\s*((const)?\s*([^,\s]+?)\s*([^,\s]+?)\s*\(([^\)]*?)\)\s*(const)?).*?$");
        private static Regex rxVariable = new Regex(@"^\s*(const)?\s*([^,\s}]+?)\s*([^,\s*\(}]+?)\s*$");
        private static Regex rxClassBegin = new Regex(@"^\s*class\s*(.+?)\s*{\s*.*?$");
        private static Regex rxEnumerationBegin = new Regex(@"^\s*enum\s*(.+?)\s*{\s*.*?$");
        private static Regex rxScopeEnding = new Regex(@"^\s*\};(?:\/\/.*)?\s*$");

        private static Regex rxParameters = new Regex(@"\s*((?:[^,\s]+\s*)+)\s*,?");
        private static Regex rxEnumerationValue = new Regex(@"^\s*([^,\s=]+)\s*=\s*-?(\d+)\s*,?\s*$");

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

        public static ASScript ParseScript(string scriptName, string[] script)
        {
            ASScript asScript = new ASScript(scriptName);

            for (int lineIndex = 0; lineIndex < script.Length; lineIndex++)
            {
                LineType lineType = GetLineType(script[lineIndex]);
                //Console.WriteLine("[" + (lineIndex + 1) + ", " + lineType + "] = " + script[lineIndex] + "");
                
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
                        ASFunction parseFunction = ParseFunction(asScript.functions, script, ref lineIndex);

                        // See ParseFunction for further information
                        //if (asScript.functions.ContainsKey(parseFunction.name)) asScript.functions[parseFunction.name] = parseFunction;
                        //else asScript.functions.Add(parseFunction.name, parseFunction);

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

            while (GetLineType(script[lineIndex]) != LineType.ScopeEnding)
            {
                LineType lineType = GetLineType(script[lineIndex]);

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
                        ASFunction parseFunction = ParseFunction(asClass.functions, script, ref lineIndex);

                        // See ParseFunction for further information
                        //if (asClass.functions.ContainsKey(parseFunction.name)) asClass.functions[parseFunction.name] = parseFunction;
                        //else asClass.functions.Add(parseFunction.name, parseFunction);

                        break;

                    case LineType.Variable:
                        ASVariable parseVariable = ParseVariable(script, ref lineIndex);
                        asClass.variables.Add(parseVariable.name, parseVariable);

                        break;
                }

                lineIndex++;
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

        private static ASFunction ParseFunction(SortedList<string, ASFunction> functions, string[] script, ref int lineIndex)
        {
            // The ParseFunction is special since it needs to detect the overloading of functions.
            // Therefore we pass the functions of the parent (ASScript/ASClass) so we can check it in here
            // rather than duplicating the code for ParseScript and ParseClass!

            // We take out the (possibly) existing function and add the overload to it.
            // Although we shouldn't need to update the list in the parent loop (since it's a reference)
            // we are still doing it for semantic understanding.

            /*
             *  void RibbonItemSetEnabled(const string &in, bool);
             *  vec3 opMul(const vec3 &in) const;
             *  const string &GetString (const string &in key);
             *  const float &opIndex(uint) const;
             *  JSON& opAssign(const JSON &in other);
             *  
             *  const string &GetString (const string &in key);
             *  const string &GetString (const string &in key, const string &out bla);
             *
             */
            Match matchFunction = rxFunction.Match(script[lineIndex]);

            ASFunction asFunction = new ASFunction(matchFunction.Groups[1].Value);

            // TODO: Implement

            // Wenn eine Funktion bereits vorhanden ist muss das überprüft werden! Überladung und so

            return asFunction;
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
        public bool isConst;
        public string returnType;
        public List<ASParameter> parameters;

        public ASOverload(bool isConst, string returnType)
        {
            this.isConst = isConst;
            this.returnType = returnType;

            this.parameters = new List<ASParameter>();
        }
    }

    struct ASParameter
    {
        public bool isConst;
        public string type;
        public string name;

        //const string &in key
        //Campaign& opAssign(const Campaign &in other

        public ASParameter(bool isConst, string type, string name)
        {
            this.isConst = isConst;
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
