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
	}
}
