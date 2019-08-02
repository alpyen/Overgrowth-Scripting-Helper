using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Overgrowth__
{
    public partial class SettingsWindow : Form
    {
        private Dictionary<string, string> Settings = new Dictionary<string, string>();

        public SettingsWindow()
        {
            InitializeComponent();
            
            Control[] list = new Control[] { groupGeneral, groupAppearance, groupFilter, lblHorizontalLine, lblAbout };

            Settings.Add(cbShowHelperWindowOnStartup.Name, "ShowHelperWindowOnStartup");
            Settings.Add(cbLiveFilteringMode.Name, "LiveFilteringMode");

            Settings.Add(cbMatchFunctionNames.Name, "MatchFunctionNames");
            Settings.Add(cbMatchParameterNames.Name, "MatchParameterNames");
            Settings.Add(cbMatchParameterTypes.Name, "MatchParameterTypes");

            Settings.Add(cbShowParameterNamesInFunctionSignatures.Name, "ShowParameterNamesInFunctionSignatures");
            Settings.Add(cbShowBackgroundImage.Name, "ShowBackgroundImage");
            Settings.Add(cbShowIconsForEachNode.Name, "ShowIconsForEachNode");
            Settings.Add(cbCustomFont.Name, "UseCustomFont");

            foreach (Control c in list)
                SetBackgroundTransparent(c);
            
            foreach (string key in Settings.Keys)
            {
                Control[] controls = this.Controls.Find(key, true);
                foreach (Control c in controls)
                {
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Checked = ((Config.Get(Settings[key]) == "true") ? true : false);
                    }
                }
            }

            cbCustomFont.Text = "Custom Font: " + Config.Get("FontName") + " " + Config.Get("FontSize");
        }

        private void SetBackgroundTransparent(Control c)
        {
            foreach (Control child in c.Controls)
                SetBackgroundTransparent(child);

            c.BackColor = Color.Transparent;
            if (!(c.Parent is GroupBox)) c.Parent = pbBackground;
        }

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                cbCustomFont.Text = "Custom Font: " + fontDialog.Font.Name + " " + fontDialog.Font.Size;
                Config.Set(Settings[cbCustomFont.Name], cbCustomFont.Checked ? "true" : "false");
                Config.Set("FontName", fontDialog.Font.Name);
                Config.Set("FontSize", fontDialog.Font.Size.ToString());
            }
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            CheckBox clicked = (CheckBox)sender;
            Config.Set(Settings[clicked.Name], clicked.Checked ? "true" : "false");
        }
    }
}
