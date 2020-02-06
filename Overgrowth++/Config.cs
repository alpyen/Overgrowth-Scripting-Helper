using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;
using System.Xml;

namespace Overgrowth__
{
    public static class Config
    {
        private static XmlDocument SettingsXML = new XmlDocument();
        private static string SettingsPath;
        private static Dictionary<string, string> Storage = new Dictionary<string, string>();

        /*
         * Why is there no generic Save/Load class?
         * 
         * Writing a generic Save/Load class to support different types of classes is just too much work.
         * Since we are dealing wiht just a handful of settings we can easily store them separately.
         * 
         * It might look bad and be considered not future-proof (if we need way more settings to store)
         * but it will serve as a good base without bloating the code that is accessing it with specific overloads or casts.
         * 
         * I know that it would be much shorter but I don't wanna bother spending time with such feature which has almost no benefits (in this scale!)
         */

        public static class General
        {
            public static bool ShowHelperWindowOnStartup = false;
            public static bool LiveFilteringMode = false;
        }

        public static class Filter
        {
            public static bool MatchFunctionNames = true;
            public static bool MatchParameterNames = false;
            public static bool MatchParameterTypes = false;
        }

        public static class Appearance
        {
            public static bool ShowParameterNamesInFunctionSignatures = false;
            public static bool ShowTooltipsWhileHoveringOverTreeViewNodes = true;
            public static bool ShowIconsForEachNode = true;
            public static bool UseCustomFont = false;
            public static Font CustomFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        }

        public static void Load(string path)
        {
            SettingsPath = path;

            bool settingsFileExists = File.Exists(path);

            if (!settingsFileExists)
            {
                System.Windows.Forms.MessageBox.Show("A default settings file has been created!", "Overgrowth++", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                File.Create(path).Close();

                SettingsXML = CreateDefaultXML();
                Save();
            }

            try
            {
                SettingsXML.Load(path);

                General.ShowHelperWindowOnStartup = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/General/ShowHelperWindowOnStartup").InnerText);
                General.LiveFilteringMode = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/General/LiveFilteringMode").InnerText);

                Filter.MatchFunctionNames = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Filter/MatchFunctionNames").InnerText);
                Filter.MatchParameterNames = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Filter/MatchParameterNames").InnerText);
                Filter.MatchParameterTypes = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Filter/MatchParameterTypes").InnerText);

                Appearance.ShowParameterNamesInFunctionSignatures = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Appearance/ShowParameterNamesInFunctionSignatures").InnerText);
                Appearance.ShowTooltipsWhileHoveringOverTreeViewNodes = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Appearance/ShowTooltipsWhileHoveringOverTreeViewNodes").InnerText);
                Appearance.ShowIconsForEachNode = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Appearance/ShowIconsForEachNode").InnerText);
                Appearance.UseCustomFont = Convert.ToBoolean(SettingsXML.SelectSingleNode("/Settings/Appearance/UseCustomFont").InnerText);

                string fontName = SettingsXML.SelectSingleNode("/Settings/Appearance/FontName").InnerText;
                float fontSize = Convert.ToSingle(SettingsXML.SelectSingleNode("/Settings/Appearance/FontSize").InnerText);
                FontStyle fontStyle = (FontStyle) Enum.Parse(typeof(FontStyle), SettingsXML.SelectSingleNode("/Settings/Appearance/FontStyle").InnerText);

                Appearance.CustomFont = new Font(fontName, fontSize, fontStyle);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error loading the settings file.\nDefault settings will be loaded and saved.", "Overgrowth++", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
           
                SettingsXML = CreateDefaultXML();
                Save();
            }
        }

        /*
         * This function will create only a default XML if the values in the variables were not overwritten!
         */
        private static XmlDocument CreateDefaultXML()
        {
            XmlDocument settingsXML = new XmlDocument();

            XmlNode nodeRoot = settingsXML.CreateElement("Settings");
            settingsXML.AppendChild(nodeRoot);

            XmlNode nodeGeneral = AppendChildWithTextToXmlNode(nodeRoot, "General");

            AppendChildWithTextToXmlNode(nodeGeneral, "ShowHelperWindowOnStartup", General.ShowHelperWindowOnStartup.ToString());
            AppendChildWithTextToXmlNode(nodeGeneral, "LiveFilteringMode", General.LiveFilteringMode.ToString());

            XmlNode nodeFilter = AppendChildWithTextToXmlNode(nodeRoot, "Filter");

            AppendChildWithTextToXmlNode(nodeFilter, "MatchFunctionNames", Filter.MatchFunctionNames.ToString());
            AppendChildWithTextToXmlNode(nodeFilter, "MatchParameterNames", Filter.MatchParameterNames.ToString());
            AppendChildWithTextToXmlNode(nodeFilter, "MatchParameterTypes", Filter.MatchParameterTypes.ToString());

            XmlNode nodeAppearance = AppendChildWithTextToXmlNode(nodeRoot, "Appearance");

            AppendChildWithTextToXmlNode(nodeAppearance, "ShowParameterNamesInFunctionSignatures", Appearance.ShowParameterNamesInFunctionSignatures.ToString());
            AppendChildWithTextToXmlNode(nodeAppearance, "ShowTooltipsWhileHoveringOverTreeViewNodes", Appearance.ShowTooltipsWhileHoveringOverTreeViewNodes.ToString());
            AppendChildWithTextToXmlNode(nodeAppearance, "ShowIconsForEachNode", Appearance.ShowIconsForEachNode.ToString());
            AppendChildWithTextToXmlNode(nodeAppearance, "UseCustomFont", Appearance.UseCustomFont.ToString());

            AppendChildWithTextToXmlNode(nodeAppearance, "FontName", Appearance.CustomFont.FontFamily.Name);
            AppendChildWithTextToXmlNode(nodeAppearance, "FontSize", Appearance.CustomFont.Size.ToString());
            AppendChildWithTextToXmlNode(nodeAppearance, "FontStyle", Appearance.CustomFont.Style.ToString());

            return settingsXML;
        }

        private static XmlNode AppendChildWithTextToXmlNode(XmlNode parent, string nodeTag, string nodeText = "")
        {
            XmlNode childNode = parent.OwnerDocument.CreateElement(nodeTag);
            childNode.InnerText = nodeText;

            parent.AppendChild(childNode);
            return childNode;
        }
        
        public static void Save()
        {
            SettingsXML.SelectSingleNode("/Settings/General/ShowHelperWindowOnStartup").InnerText = General.ShowHelperWindowOnStartup.ToString();
            SettingsXML.SelectSingleNode("/Settings/General/LiveFilteringMode").InnerText = General.LiveFilteringMode.ToString();

            SettingsXML.SelectSingleNode("/Settings/Filter/MatchFunctionNames").InnerText = Filter.MatchFunctionNames.ToString();
            SettingsXML.SelectSingleNode("/Settings/Filter/MatchParameterNames").InnerText = Filter.MatchParameterNames.ToString();
            SettingsXML.SelectSingleNode("/Settings/Filter/MatchParameterTypes").InnerText = Filter.MatchParameterTypes.ToString();

            SettingsXML.SelectSingleNode("/Settings/Appearance/ShowParameterNamesInFunctionSignatures").InnerText = Appearance.ShowParameterNamesInFunctionSignatures.ToString();
            SettingsXML.SelectSingleNode("/Settings/Appearance/ShowTooltipsWhileHoveringOverTreeViewNodes").InnerText = Appearance.ShowTooltipsWhileHoveringOverTreeViewNodes.ToString();
            SettingsXML.SelectSingleNode("/Settings/Appearance/ShowIconsForEachNode").InnerText = Appearance.ShowIconsForEachNode.ToString();
            SettingsXML.SelectSingleNode("/Settings/Appearance/UseCustomFont").InnerText = Appearance.UseCustomFont.ToString();

            SettingsXML.SelectSingleNode("/Settings/Appearance/FontName").InnerText = Appearance.CustomFont.FontFamily.Name;
            SettingsXML.SelectSingleNode("/Settings/Appearance/FontSize").InnerText = Appearance.CustomFont.Size.ToString();
            SettingsXML.SelectSingleNode("/Settings/Appearance/FontStyle").InnerText = Appearance.CustomFont.Style.ToString();
            
            SettingsXML.Save(SettingsPath);
        }
    }
}
