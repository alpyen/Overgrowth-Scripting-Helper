using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace Overgrowth__
{
    class Main
    {
        internal const string PluginName = "Overgrowth++";
        internal static string PluginVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, 5);

        static HelperWindow helperWindow;
        static SettingsWindow settingsWindow;

        static bool helperWindowDocked = false;

        static string settingsFilePath = null;

        static int idMyDlg = -1;

        static Bitmap tbBmp = Properties.Resources.rabbit_png_small;
        static Bitmap tbBmp_tbTab = Properties.Resources.rabbit_bmp_small;
        static Icon tbIcon = null;

        public static void OnNotification(ScNotification notification)
        {  
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
        }

        internal static void CommandMenuInit()
        {
            StringBuilder sb = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sb);

            settingsFilePath = sb.ToString();

            if (!Directory.Exists(settingsFilePath + "\\")) Directory.CreateDirectory(settingsFilePath);
            settingsFilePath = settingsFilePath + "\\Overgrowth++";

            if (!Directory.Exists(settingsFilePath + "\\")) Directory.CreateDirectory(settingsFilePath);
            settingsFilePath = settingsFilePath + "\\Overgrowth++.xml";

            PluginBase.SetCommand(0, "Show Helper Sidebar", ToggleHelperWindow, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(1, "Settings", ShowSettings);
            PluginBase.SetCommand(2, "About Overgrowth++", AboutPlugin);
            idMyDlg = 0;

            Config.Load(settingsFilePath);
            helperWindow = new HelperWindow();
            settingsWindow = new SettingsWindow();

            if (Config.General.ShowHelperWindowOnStartup) ToggleHelperWindow();
        }

        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {

        }

        internal static void AboutPlugin()
        {
            MessageBox.Show(
                PluginName + " " + PluginVersion + " programmed by alpines.\r\n" +
                "\r\n" +
                "Overgrowth++ helps you to write better Angelscript code for the game " +
                "by providing documentation of the game API so you can easily navigate through it." +
                "\r\n\r\n" +
                "Do you like the plugin? Let me know!\r\n" +
                "https://ag.systems/" + "\r\n\r\n" +
                "Icons from the 'Silk Icon Set 1.3' by Mark James https://www.famfamfam.com/lab/icons/silk/" + "\r\n" +
                "Licensed as CC-BY 2.5 - check it out, it's really neat!", "About Overgrowth++", MessageBoxButtons.OK, MessageBoxIcon.Information
            );
        }
        internal static void ShowSettings()
        {
            settingsWindow.ShowDialog();
            Config.Save();
        }

        internal static void ToggleHelperWindow()
        {
            if (!helperWindowDocked)
            {
                helperWindowDocked = true;

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = helperWindow.Handle;
                _nppTbData.pszName = helperWindow.Text;
                _nppTbData.dlgID = idMyDlg;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, helperWindow.Handle);
            }
        }
    }
}