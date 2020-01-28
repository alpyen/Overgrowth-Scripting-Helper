using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsDocs2XML
{  
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
    class ASScript
    {
        public string name;

        public SortedList<string, ASClass> classes;
        public SortedList<string, ASEnumeration> enumerations;
        public SortedList<string, ASFunction> functions;
        public SortedList<string, ASVariable> variables;

        public ASScript(string name, string[] script)
        {
            this.name = name;
            this.parseScript(script);
        }

        private void parseScript(string[] script)
        {
            // Do the magic
        }
    }

    class ASClass
    {
        public string name;
        public SortedList<string, ASClass> classes;
        public SortedList<string, ASEnumeration> enumerations;
        public SortedList<string, ASVariable> variables;

        public ASClass(string[] script, int line)
        {
            this.parseClass(script, line);
        }

        private void parseClass(string[] script, int line)
        {
            // Do the magic 2
        }
    }

    struct ASFunction
    {
        /*
         *  void RibbonItemSetEnabled(const string &in, bool);
         *  vec3 opMul(const vec3 &in) const;
         *  const string &GetString (const string &in key);
         *  const float &opIndex(uint) const;
         *  JSON& opAssign(const JSON &in other);
         */
        public string name;
        public List<ASOverload> overloads;            
    }

    struct ASOverload
    {
        public bool isConst;
        public string returnType;
        public List<ASParameter> parameters;

        //const string &GetString (const string &in key);
        //const string &GetString (const string &in key, const string &out bla);
    }

    struct ASParameter
    {
        public bool isConst;
        public string type;
        public string name;

        //const string &in key
    }

    struct ASEnumeration
    {
        public string name;

        // Be careful! We are using the enum values as the key since we want to sort after the values
        // and not the enum member names!
        public SortedList<int, string> enumerationMembers;

        /*enum MouseButton {
            LEFT = 0,
            MIDDLE = 1,
            RIGHT = 2,
            FOURTH = 3,
            FIFTH = 4,
            SIXTH = 5,
            SEVENTH = 6,
            EIGHT = 7,
            NINTH = 8,
            TENTH = 9,
            TWELFTH = 10
        };*/
    }

    struct ASVariable
    {
        public bool isConst;
        public string type;
        public string name;

        //const int _sound_priority_very_high;
    }
}
