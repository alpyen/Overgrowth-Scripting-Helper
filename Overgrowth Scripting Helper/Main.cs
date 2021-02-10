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
        internal const string PluginName = "Overgrowth Scripting Helper";

        static frmMyDlg frmMyDlg = null;
        static int idMyDlg = -1;
        static Bitmap tbBmp = Properties.Resources.star;
        static Bitmap tbBmp_tbTab = Properties.Resources.star_bmp;
        static Icon tbIcon = null;

        internal static void CommandMenuInit()
        {
            StringBuilder sbSettingsPath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbSettingsPath);

            if (!Directory.Exists(sbSettingsPath.ToString()))
                Directory.CreateDirectory(sbSettingsPath.ToString());

            Config.Path = Path.Combine(sbSettingsPath.ToString(), PluginName + ".ini");
            Config.Load();

            // TODO: Implement startup routine

                // TODO: Check config if helper window should show on start and show it accordingly.
                // TODO: Remove standard pictures, add the old pictures again, don't forget to credit Silk icons in About

            PluginBase.SetCommand(0, "Toggle Helper Window", ToggleHelperWindow);
            PluginBase.SetCommand(1, "Toggle Cheat Sheet Window", ToggleCheatSheetWindow);
            PluginBase.SetCommand(2, "", null);
            PluginBase.SetCommand(3, "Insert Camera Script Template", InsertCameraTemplate);
            PluginBase.SetCommand(4, "Insert Character Script Template", InsertCharacterTemplate);
            PluginBase.SetCommand(5, "Insert Hotspot Template", InsertHotspotTemplate);
            PluginBase.SetCommand(6, "Insert Level Script Template", InsertLevelTemplate);
            PluginBase.SetCommand(7, "Insert Scriptable Campaign Script Template", InsertScriptableCampaignTemplate);
            PluginBase.SetCommand(8, "Insert Scriptable UI Script Template", InsertScriptableUiTemplate);
            PluginBase.SetCommand(9, "", null);
            PluginBase.SetCommand(10, "Settings", OpenSettingsWindow);
            PluginBase.SetCommand(11, "About Overgrowth Scripting Helper", OpenAboutWindow);

            idMyDlg = 1;

            //PluginBase.SetCommand(0, "MyMenuCommand", myMenuFunction, new ShortcutKey(false, false, false, Keys.None));
            //PluginBase.SetCommand(1, "MyDockableDialog", myDockableDialog); idMyDlg = 1;
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

        internal static void ToggleHelperWindow()
        {
            // TODO: implement
        }

        internal static void ToggleCheatSheetWindow()
        {
            // TODO: implement
        }

        internal static void InsertCameraTemplate()
        {
            // TODO: implement
        }

        internal static void InsertCharacterTemplate()
        {
            // TODO: implement
        }

        internal static void InsertHotspotTemplate()
        {
            // TODO: implement
        }

        internal static void InsertLevelTemplate()
        {
            // TODO: implement
        }

        internal static void InsertScriptableCampaignTemplate()
        {
            // TODO: implement
        }

        internal static void InsertScriptableUiTemplate()
        {
            // TODO: implement
        }

        internal static void OpenSettingsWindow()
        {
            // TODO: implement
        }

        internal static void OpenAboutWindow()
        {
            // TODO: implement
        }

        internal static void myDockableDialog()
        {
            if (frmMyDlg == null)
            {
                frmMyDlg = new frmMyDlg();

                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(tbBmp_tbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmMyDlg.Handle;
                _nppTbData.pszName = "My dockable dialog";
                _nppTbData.dlgID = idMyDlg;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_DMMSHOW, 0, frmMyDlg.Handle);
            }
        }
    }
}