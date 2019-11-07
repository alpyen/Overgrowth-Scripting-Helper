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
                        ((CheckBox)c).Checked = Config.GetBool(Settings[key]);
                    }
                }
            }

            cbCustomFont.Text = "Use Custom Font";
        }

        // Since the Designer has no option to set the parent of a control directly, we need to specify this value manually.
        // The parent value for the group needs to stay the same otherwise some controls within them will disappear due to
        // the order they were created in.
        private void SetBackgroundTransparent(Control c)    
        {
            foreach (Control child in c.Controls)
                SetBackgroundTransparent(child);

            c.BackColor = Color.Transparent;
            if (!(c.Parent is GroupBox)) c.Parent = pbBackground;
        }

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Config.GetFont();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Config.Set(Settings[cbCustomFont.Name], cbCustomFont.Checked ? "true" : "false");
                Config.SetFont(fontDialog.Font);
            }
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            CheckBox clicked = (CheckBox)sender;
            Config.Set(Settings[clicked.Name], clicked.Checked ? "true" : "false");
        }
    }
}
