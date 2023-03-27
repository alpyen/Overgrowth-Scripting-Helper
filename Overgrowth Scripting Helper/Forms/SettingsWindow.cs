using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Overgrowth_Scripting_Helper
{
	public partial class SettingsWindow : Form
	{
		private HelperWindow helperWindow;

		public SettingsWindow(HelperWindow helperWindow)
		{
			InitializeComponent();

			// We keep a reference to the helper window around to change the font of the tree view
			// while adjusting it, because this is much better than restarting
			// every time after changing the font slightly.
			this.helperWindow = helperWindow;

			// Set the window title.
			this.Text = Config.PluginName + " - Settings";

			// Setting the transparency in the designer is not enough.
			// Achieving transparency with a picturebox as a background requires setting the parent control.
			List<Control> transparentControls = new List<Control>() {
				groupGeneral, groupAppearance,
				cbShowHelperWindowOnStartup, cbLiveFilteringMode, cbShowFunctionNameInOverloadSignatures,
				cbShowParameterNamesInOverloadSignatures, cbShowIconsForEachNode, cbUseCustomFont, btnChangeFont,
			};	

			foreach (Control control in transparentControls)
			{
				control.BackColor = Color.Transparent;
				if (!(control.Parent is GroupBox)) control.Parent = pbBackground;
			}

			// Load the settings into the checkboxes.
			cbShowHelperWindowOnStartup.Checked = Config.ShowHelperWindowOnStartup;
			cbLiveFilteringMode.Checked = Config.LiveFilteringMode;
			cbShowFunctionNameInOverloadSignatures.Checked = Config.ShowFunctionNameInOverloadSignatures;
			cbShowParameterNamesInOverloadSignatures.Checked = Config.ShowParameterNamesInOverloadSignatures;
			cbShowIconsForEachNode.Checked = Config.ShowIconsForEachNode;
			cbUseDarkMode.Checked = Config.UseDarkMode;
			cbUseCustomFont.Checked = Config.UseCustomFont;
			cbUseCustomFont.Text = "Use Custom Font - " + Config.CustomFont.Name + ", " + Config.CustomFont.Size + ", " + Config.CustomFont.Style;
		}

		private void SettingsWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			Config.ShowHelperWindowOnStartup = cbShowHelperWindowOnStartup.Checked;
			Config.LiveFilteringMode = cbLiveFilteringMode.Checked;
			Config.ShowFunctionNameInOverloadSignatures = cbShowFunctionNameInOverloadSignatures.Checked;
			Config.ShowParameterNamesInOverloadSignatures = cbShowParameterNamesInOverloadSignatures.Checked;
			Config.ShowIconsForEachNode = cbShowIconsForEachNode.Checked;
			Config.UseDarkMode = cbUseDarkMode.Checked;
			Config.UseCustomFont = cbUseCustomFont.Checked;
			// Saved when adjusting the font.
			// Config.CustomFont = fontDialog.Font;

			Config.Save();
		}

		private void btnChangeFont_Click(object sender, EventArgs e)
		{
			fontDialog.Font = Config.CustomFont;

			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				Config.CustomFont = fontDialog.Font;

				cbUseCustomFont.Text = "Use Custom Font - " + Config.CustomFont.Name + ", " + Config.CustomFont.Size + ", " + Config.CustomFont.Style;
				helperWindow.SetTreeViewFonts(cbUseCustomFont.Checked ? Config.CustomFont : SystemFonts.DefaultFont);
			}

		}

		private void cbUseCustomFont_CheckedChanged(object sender, EventArgs e)
		{
			helperWindow.SetTreeViewFonts(cbUseCustomFont.Checked ? Config.CustomFont : SystemFonts.DefaultFont);
		}
	}
}
