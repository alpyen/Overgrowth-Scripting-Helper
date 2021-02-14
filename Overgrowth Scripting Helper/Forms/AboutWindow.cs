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
	public partial class AboutWindow : Form
	{
		public AboutWindow()
		{
			InitializeComponent();

			// Set the window title.
			this.Text = "About " + Config.PluginName;

			lblPluginName.Text = Config.PluginName + " " + Config.PluginVersion;

			// Setting the transparency in the designer is not enough.
			// Achieving transparency with a picturebox as a background requires setting the parent control.
			List<Control> transparentControls = new List<Control>() {
				groupText, lblPluginName, lblProgrammedBy, lblGithubRepository, lblText
			};

			foreach (Control control in transparentControls)
			{
				control.BackColor = Color.Transparent;
				if (!(control.Parent is GroupBox)) control.Parent = pbBackground;
			}
		}

		private void lblGithubRepository_MouseEnter(object sender, EventArgs e)
		{
			lblGithubRepository.ForeColor = Color.Blue;
		}

		private void lblGithubRepository_MouseLeave(object sender, EventArgs e)
		{
			lblGithubRepository.ForeColor = Color.Black;
		}

		private void lblGithubRepository_MouseClick(object sender, MouseEventArgs e)
		{
			System.Diagnostics.Process.Start(Config.PluginRepositoryURL);
		}

	}
}
