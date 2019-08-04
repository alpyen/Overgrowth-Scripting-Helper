using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Overgrowth__
{
    class Config
    {
        private static XmlDocument SettingsXML = new XmlDocument();
        private static string SettingsPath;
        private static Dictionary<string, string> Storage = new Dictionary<string, string>();

        public static string[,] Keys = new string[,]
        {
            { "General", "ShowHelperWindowOnStartup", "false" },
            { "General", "LiveFilteringMode", "false" },
            { "Filter", "MatchFunctionNames", "true" },
            { "Filter", "MatchParameterNames", "false" },
            { "Filter", "MatchParameterTypes", "false" },
            { "Appearance", "ShowParameterNamesInFunctionSignatures", "false" },
            { "Appearance", "ShowBackgroundImage", "true" },
            { "Appearance", "ShowIconsForEachNode", "true" },
            { "Appearance", "UseCustomFont", "false" },
            { "Appearance", "FontName", "MS Sans Serif" },
            { "Appearance", "FontSize", "8.25" }
        };

        public static void Load(string path)
        {
            SettingsPath = path;

            if (!File.Exists(path))
            {
                FileStream settingsFile = File.Create(path);
                settingsFile.Close();
            }
            else
            {
                try { SettingsXML.Load(path); } catch (Exception) { SettingsXML = new XmlDocument(); }
            }

            XmlNode rootNode = SettingsXML.SelectSingleNode("/Settings");

            // Build XML Structure
            if (rootNode == null)
            {
                rootNode = SettingsXML.CreateElement("Settings");
                SettingsXML.AppendChild(rootNode);
            }
            for (int i = 0; i < Keys.GetLength(0); i++)
            {
                if (rootNode.SelectSingleNode(Keys[i, 0]) == null)
                {
                    rootNode.AppendChild(SettingsXML.CreateElement(Keys[i, 0]));
                }
            }

            bool rewriteSettings = false;

            for (int i = 0; i < Keys.GetLength(0); i++)
            {
                XmlNode node = rootNode.SelectSingleNode(Keys[i, 0] + "/" + Keys[i, 1]);

                if (node == null)
                {
                    Storage.Add(Keys[i, 1], Keys[i, 2]);

                    XmlNode saveNode = SettingsXML.CreateElement(Keys[i, 1]);
                    saveNode.InnerText = Keys[i, 2];

                    rootNode.SelectSingleNode(Keys[i, 0]).AppendChild(saveNode);
                    rewriteSettings = true;
                }
                else
                {
                    if (node.InnerText == "")
                    {
                        node.InnerText = Keys[i, 2];
                        rewriteSettings = true;
                    }

                    // Keys which are not booleans can be saved without lowercasing them.
                    // Infact this way the Font Name does not get destroyed.

                    if (Keys[i, 2] == "true" || Keys[i, 2] == "false")
                        Storage.Add(Keys[i, 1], node.InnerText.ToLower());
                    else
                        Storage.Add(Keys[i, 1], node.InnerText);
                }
            }

            if (rewriteSettings) Save();
        }

        public static string Get(string key)
        {
            return Storage[key];
        }

        public static void Set(string key, string value)
        {
            Storage[key] = value;

            for (int i = 0; i < Keys.GetLength(0); i++)
            {
                if (Keys[i, 1] == key)
                {
                    SettingsXML.SelectSingleNode("/Settings/" + Keys[i, 0] + "/" + Keys[i, 1]).InnerText = value;
                    break;
                }
            }
        }

        public static void Save()
        {
            SettingsXML.Save(SettingsPath);
        }
    }
}
