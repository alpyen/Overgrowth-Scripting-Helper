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
        private bool loaded = false;
        public SettingsWindow()
        {
            InitializeComponent();

            Control[] list = new Control[] { groupGeneral, groupAppearance, groupFilter, lblHorizontalLine, lblAbout };

            cbShowHelperWindowOnStartup.Checked = Config.General.ShowHelperWindowOnStartup;
            cbLiveFilteringMode.Checked = Config.General.LiveFilteringMode;

            cbMatchFunctionNames.Checked = Config.Filter.MatchFunctionNames;
            cbMatchParameterNames.Checked = Config.Filter.MatchParameterNames;
            cbMatchParameterTypes.Checked = Config.Filter.MatchParameterTypes;

            cbShowParameterNamesInFunctionSignatures.Checked = Config.Appearance.ShowParameterNamesInFunctionSignatures;
            cbShowTooltipsWhileHoveringOverTreeViewNodes.Checked = Config.Appearance.ShowTooltipsWhileHoveringOverTreeViewNodes;
            cbShowIconsForEachNode.Checked = Config.Appearance.ShowIconsForEachNode;
            cbUseCustomFont.Checked = Config.Appearance.UseCustomFont;
            fontDialog.Font = Config.Appearance.CustomFont;
            
            foreach (Control c in list)
                SetBackgroundTransparent(c);

            loaded = true;
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
            fontDialog.Font = Config.Appearance.CustomFont;
            if (fontDialog.ShowDialog() == DialogResult.OK) Config.Appearance.CustomFont = fontDialog.Font;
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            // If we don't check if the form is loaded, then settings the checked-attributes in the construction
            // will result in triggering this event!
            if (!loaded) return;

            Config.General.ShowHelperWindowOnStartup = cbShowHelperWindowOnStartup.Checked;
            Config.General.LiveFilteringMode = cbLiveFilteringMode.Checked;

            Config.Filter.MatchFunctionNames = cbMatchFunctionNames.Checked;
            Config.Filter.MatchParameterNames = cbMatchParameterNames.Checked;
            Config.Filter.MatchParameterTypes = cbMatchParameterTypes.Checked;

            Config.Appearance.ShowParameterNamesInFunctionSignatures = cbShowParameterNamesInFunctionSignatures.Checked;
            Config.Appearance.ShowTooltipsWhileHoveringOverTreeViewNodes = cbShowTooltipsWhileHoveringOverTreeViewNodes.Checked;
            Config.Appearance.ShowIconsForEachNode = cbShowIconsForEachNode.Checked;
            Config.Appearance.UseCustomFont = cbUseCustomFont.Checked;
        }
    }
}
