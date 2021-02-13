using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Overgrowth_Scripting_Helper.NppPluginNET.PluginInfrastructure;

namespace Overgrowth_Scripting_Helper.NppPluginNET
{
	class Main
	{
		static bool showHelperWindow = false;
		static SettingsWindow settingsWindow = null;
		static HelperWindow helperWindow = null;

		static Icon tabIcon = null;
		static int idMyDlg = 0;

		static ScintillaGateway sgEditor = null;

		internal static void CommandMenuInit()
		{
			sgEditor = new ScintillaGateway(PluginBase.nppData._scintillaMainHandle);
			
			// Load settings
			StringBuilder settingsPath = new StringBuilder(Win32.MAX_PATH);
			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, settingsPath);
			
			if (!Directory.Exists(settingsPath.ToString()))
				Directory.CreateDirectory(settingsPath.ToString());

			StringBuilder pluginsPath = new StringBuilder(Win32.MAX_PATH);
			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINHOMEPATH, Win32.MAX_PATH, pluginsPath);

			Config.SettingsPath = Path.Combine(settingsPath.ToString(), Config.PluginName + ".ini");
			Config.DatabasePath = Path.Combine(pluginsPath.ToString(), Config.PluginName, "database.xml");

			Config.Load();

			// Initialize the windows and the window icons.
			helperWindow = new HelperWindow();
			settingsWindow = new SettingsWindow(helperWindow);

			// We do not call ToggleHelperWindow here because we have to wait until NPPN_READY is sent,
			// otherwise the window will show up, but the toolbar icon will not be pushed down.
			// We are inverting the showHelperWindow boolean because the toggle function will invert it again.
			// This way we don't need to implement more logic.
			DockHelperWindow();

			showHelperWindow = Config.ShowHelperWindowOnStartup;
			showHelperWindow = !showHelperWindow;

			// Set up the menu items.
			PluginBase.SetCommand(0, "Toggle Helper Window", ToggleHelperWindow);
			PluginBase.SetCommand(1, "Toggle Cheat Sheet Window", ToggleCheatSheetWindow);
			PluginBase.SetCommand(2, "", null);
			PluginBase.SetCommand(3, "Insert Camera Script Template", InsertCameraTemplate);
			PluginBase.SetCommand(4, "Insert Character Script Template", InsertCharacterTemplate);
			PluginBase.SetCommand(5, "Insert Hotspot Template", InsertHotspotTemplate);
			PluginBase.SetCommand(6, "Insert Level Script Template", InsertLevelTemplate);
			PluginBase.SetCommand(7, "", null);
			PluginBase.SetCommand(8, "Settings", OpenSettingsWindow);
			PluginBase.SetCommand(9, "About " + Config.PluginName, OpenAboutWindow);
		}

		internal static void SetToolBarIcon()
		{
			toolbarIcons tbIcons = new toolbarIcons();
			tbIcons.hToolbarBmp = Properties.Resources.RabbitTransparent16x16.GetHbitmap();
			IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
			Marshal.StructureToPtr(tbIcons, pTbIcons, false);
			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
			Marshal.FreeHGlobal(pTbIcons);
		}

		internal static void DockHelperWindow()
		{
			// Set the icon in the tab control that appears when multiple plugin windows are docked.
			using (Bitmap newBmp = new Bitmap(16, 16))
			{
				Graphics g = Graphics.FromImage(newBmp);
				ColorMap[] colorMap = new ColorMap[1];
				colorMap[0] = new ColorMap();
				colorMap[0].OldColor = Color.White;
				colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
				ImageAttributes attr = new ImageAttributes();
				attr.SetRemapTable(colorMap);
				g.DrawImage(Properties.Resources.RabbitWhite16x16, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
				tabIcon = Icon.FromHandle(newBmp.GetHicon());
			}

			// Dock the window.
			NppTbData _nppTbData = new NppTbData();
			_nppTbData.hClient = helperWindow.Handle;
			_nppTbData.pszName = helperWindow.Text;
			_nppTbData.dlgID = idMyDlg;
			_nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
			_nppTbData.hIconTab = (uint)tabIcon.Handle;
			_nppTbData.pszModuleName = Config.PluginName;
			IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
			Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMHIDE, 0, helperWindow.Handle);
		}

		internal static void ToggleHelperWindow()
		{
			if (Config.DatabaseXml == null)
			{
				MessageBox.Show(
						"Database.xml for " + Config.PluginName + " invalid or not found at:\n\"" +
						Path.GetDirectoryName(Config.DatabasePath) + "\\\"\n\n" +
						"Please copy the database to the desired location and restart Notepad++ otherwise the Helper Window will not work.",
						"Notepad++ " + Config.PluginName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation
					);

				return;
			}

			showHelperWindow = !showHelperWindow;

			Win32.SendMessage(PluginBase.nppData._nppHandle, showHelperWindow ? (uint)NppMsg.NPPM_DMMSHOW : (uint)NppMsg.NPPM_DMMHIDE, 0, helperWindow.Handle);
			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SETMENUITEMCHECK, PluginBase._funcItems.Items[idMyDlg]._cmdID, showHelperWindow ? 1 : 0);
		}

		internal static void ToggleCheatSheetWindow()
		{
			// TODO: ToggleCheatSheetWindow
		}

		internal static void InsertCameraTemplate() { sgEditor.InsertText(-1, Templates.CameraScript); }
		internal static void InsertCharacterTemplate() { sgEditor.InsertText(-1, Templates.CharacterScript); }
		internal static void InsertHotspotTemplate() { sgEditor.InsertText(-1, Templates.HotspotScript); }
		internal static void InsertLevelTemplate()	{ sgEditor.InsertText(-1, Templates.LevelScript); }

		internal static void OpenSettingsWindow()
		{
			settingsWindow.ShowDialog();
		}

		internal static void OpenAboutWindow()
		{
			// TODO: AboutWindow
		}
	}
}