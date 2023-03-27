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
	public partial class CheatSheetWindow : Form
	{
		public CheatSheetWindow()
		{
			InitializeComponent();

			// Set the window title.
			this.Text = Config.PluginName + " - Cheat Sheet for Overgrowth " + Config.CompiledForOvergrowthVersion;
		}

		private void CheatSheetWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Main.ToggleCheatSheetWindow();
		}

		public void SetWindowTheme(bool useDarkMode)
		{
			Color foreColor = useDarkMode ? Color.FromArgb(0xDD, 0xDD, 0xDD) : Color.Black;
			Color backColor = useDarkMode ? Color.FromArgb(0x22, 0x22, 0x22) : Color.White;

			this.ForeColor = useDarkMode ? foreColor : DefaultForeColor;
			this.BackColor = useDarkMode ? backColor : DefaultBackColor;

			lvCheatSheet.ForeColor = foreColor;
			lvCheatSheet.BackColor = backColor;

			
		}
	}
}
