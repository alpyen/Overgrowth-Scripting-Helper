using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Overgrowth_Scripting_Helper.NppPluginNET.PluginInfrastructure;
using System.Xml;
using System.IO;

namespace Overgrowth_Scripting_Helper
{
	public static class Config
	{
		public static string PluginName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
		public static string PluginVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
		public static string PluginRepositoryURL = "https://github.com/alpyen/Overgrowth-Scripting-Helper";

		public static string CompiledForOvergrowthVersion = "1.4";

		public static string SettingsPath;
		public static string DatabasePath;
		public static XmlDocument DatabaseXml;

		public static bool ShowHelperWindowOnStartup = false;
		public static bool LiveFilteringMode = false;
		public static bool ShowFunctionNameInOverloadSignatures = true;
		public static bool ShowParameterNamesInOverloadSignatures = true;
		public static bool ShowIconsForEachNode = true;
		public static bool UseCustomFont = false;

		public static Font CustomFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

		public static void Load()
		{
			StringBuilder readout = new StringBuilder();

			Win32.GetPrivateProfileString("Settings", "ShowHelperWindowOnStartup", "False", readout, 20, SettingsPath);
			ShowHelperWindowOnStartup = readout.ToString() == "True";

			Win32.GetPrivateProfileString("Settings", "LiveFilteringMode", "False", readout, 20, SettingsPath);
			LiveFilteringMode = readout.ToString() == "True";

			Win32.GetPrivateProfileString("Settings", "ShowFunctionNameInOverloadSignatures", "True", readout, 20, SettingsPath);
			ShowFunctionNameInOverloadSignatures = readout.ToString() == "True";

			Win32.GetPrivateProfileString("Settings", "ShowParameterNamesInOverloadSignatures", "True", readout, 20, SettingsPath);
			ShowParameterNamesInOverloadSignatures = readout.ToString() == "True";

			Win32.GetPrivateProfileString("Settings", "ShowIconsForEachNode", "True", readout, 20, SettingsPath);
			ShowIconsForEachNode = readout.ToString() == "True";

			Win32.GetPrivateProfileString("Settings", "UseCustomFont", "False", readout, 20, SettingsPath);
			UseCustomFont = readout.ToString() == "True";

			Win32.GetPrivateProfileString("Settings", "FontName", "Microsoft Sans Serif", readout, 20, SettingsPath);
			string fontName = readout.ToString();

			Win32.GetPrivateProfileString("Settings", "FontSize", "8,25", readout, 20, SettingsPath);
			float fontSize = Convert.ToSingle(readout.ToString());

			Win32.GetPrivateProfileString("Settings", "FontStyle", "Regular", readout, 20, SettingsPath);
			FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), readout.ToString());

			CustomFont.Dispose();
			CustomFont = new Font(fontName, fontSize, fontStyle);

			if (File.Exists(DatabasePath))
			{
				DatabaseXml = new XmlDocument();

				try { DatabaseXml.Load(DatabasePath); }
				catch (Exception) { DatabaseXml = null; }
			}
		}

		public static void Save()
		{
			Win32.WritePrivateProfileString("Settings", "ShowHelperWindowOnStartup", ShowHelperWindowOnStartup.ToString(), SettingsPath);
			Win32.WritePrivateProfileString("Settings", "LiveFilteringMode", LiveFilteringMode.ToString(), SettingsPath);
			Win32.WritePrivateProfileString("Settings", "ShowFunctionNameInOverloadSignatures", ShowFunctionNameInOverloadSignatures.ToString(), SettingsPath);
			Win32.WritePrivateProfileString("Settings", "ShowParameterNamesInOverloadSignatures", ShowParameterNamesInOverloadSignatures.ToString(), SettingsPath);
			Win32.WritePrivateProfileString("Settings", "ShowIconsForEachNode", ShowIconsForEachNode.ToString(), SettingsPath);
			Win32.WritePrivateProfileString("Settings", "UseCustomFont", UseCustomFont.ToString(), SettingsPath);

			Win32.WritePrivateProfileString("Settings", "FontName", CustomFont.Name, SettingsPath);
			Win32.WritePrivateProfileString("Settings", "FontSize", CustomFont.Size.ToString(), SettingsPath);
			Win32.WritePrivateProfileString("Settings", "FontStyle", CustomFont.Style.ToString(), SettingsPath);
		}
	}
}
