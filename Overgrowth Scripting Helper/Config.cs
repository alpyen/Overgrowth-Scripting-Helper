using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Overgrowth_Scripting_Helper.NppPluginNET.PluginInfrastructure;

namespace Overgrowth_Scripting_Helper
{
    public static class Config
    {
        public static string Path;

        public static bool ShowHelperWindowOnStartup = false;
        public static bool LiveFilteringMode = false;
        public static bool HideParameterNamesInFunctionSignatures = false;
        public static bool ShowIconsForEachNode = true;
        public static bool UseCustomFont = false;

        public static Font CustomFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

        public static void Load()
        {
            StringBuilder sbReadout = new StringBuilder();

            Win32.GetPrivateProfileString("Settings", "ShowHelperWindowOnStartup", "False", sbReadout, 20, Path);
            ShowHelperWindowOnStartup = sbReadout.ToString() == "True";

            Win32.GetPrivateProfileString("Settings", "LiveFilteringMode", "False", sbReadout, 20, Path);
            LiveFilteringMode = sbReadout.ToString() == "True";

            Win32.GetPrivateProfileString("Settings", "HideParameterNamesInFunctionSignatures", "False", sbReadout, 20, Path);
            HideParameterNamesInFunctionSignatures = sbReadout.ToString() == "True";

            Win32.GetPrivateProfileString("Settings", "ShowIconsForEachNode", "True", sbReadout, 20, Path);
            ShowIconsForEachNode = sbReadout.ToString() == "True";

            Win32.GetPrivateProfileString("Settings", "UseCustomFont", "False", sbReadout, 20, Path);
            UseCustomFont = sbReadout.ToString() == "True";

            Win32.GetPrivateProfileString("Settings", "FontName", "Microsoft Sans Serif", sbReadout, 20, Path);
            string fontName = sbReadout.ToString();

            Win32.GetPrivateProfileString("Settings", "FontSize", "8,25", sbReadout, 20, Path);
            float fontSize = Convert.ToSingle(sbReadout.ToString());

            Win32.GetPrivateProfileString("Settings", "FontStyle", "Regular", sbReadout, 20, Path);
            FontStyle fontStyle = (FontStyle) Enum.Parse(typeof(FontStyle), sbReadout.ToString());

            CustomFont.Dispose();
            CustomFont = new Font(fontName, fontSize, fontStyle);
        }

        public static void Save()
        {
            Win32.WritePrivateProfileString("Settings", "ShowHelperWindowOnStartup", ShowHelperWindowOnStartup.ToString(), Path);
            Win32.WritePrivateProfileString("Settings", "LiveFilteringMode", LiveFilteringMode.ToString(), Path);
            Win32.WritePrivateProfileString("Settings", "HideParameterNamesInFunctionSignatures", HideParameterNamesInFunctionSignatures.ToString(), Path);
            Win32.WritePrivateProfileString("Settings", "ShowIconsForEachNode", ShowIconsForEachNode.ToString(), Path);
            Win32.WritePrivateProfileString("Settings", "UseCustomFont", UseCustomFont.ToString(), Path);

            Win32.WritePrivateProfileString("Settings", "FontName", CustomFont.Name, Path);
            Win32.WritePrivateProfileString("Settings", "FontSize", CustomFont.Size.ToString(), Path);
            Win32.WritePrivateProfileString("Settings", "FontStyle", CustomFont.Style.ToString(), Path);
        }
    }
}
