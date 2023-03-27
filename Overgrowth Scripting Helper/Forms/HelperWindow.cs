using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Runtime.InteropServices;

namespace Overgrowth_Scripting_Helper
{
	public partial class HelperWindow : Form
	{
		private ImageList TreeViewImageList = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };
		private bool HoldingEnterKey = false;

		// Hold a list of the complete tree nodes of each script type because when we are filtering,
		// we need to reconstruct the tree again. Doing this with a temporary backup is much faster.
		// Saving all intermediate steps while filtering would make this much faster (for the live edit)
		// but is a lot of work to implement for now.
		private Dictionary<string, List<TreeNode>> BackupNodes = new Dictionary<string, List<TreeNode>>();

		public HelperWindow()
		{
			InitializeComponent();

			// Set the window title.
			this.Text = Config.PluginName;
		}

		public void SetWindowTheme(bool useDarkMode)
		{
			Color foreColor = useDarkMode ? Color.FromArgb(0xDD, 0xDD, 0xDD) : Color.Black;
			Color backColor = useDarkMode ? Color.FromArgb(0x22, 0x22, 0x22) : Color.White;

			// Auch für CheatSheetWindow
			this.ForeColor = useDarkMode ? foreColor : DefaultForeColor;
			this.BackColor = useDarkMode ? backColor : DefaultBackColor;

			foreach (Control pluginControl in this.Controls)
			{
				pluginControl.ForeColor = useDarkMode ? foreColor : DefaultForeColor;
				pluginControl.BackColor = useDarkMode ? backColor : DefaultBackColor;

				if (pluginControl.GetType() == typeof(TabControl))
				{
					foreach (Control tabPage in pluginControl.Controls)
					{
						tabPage.ForeColor = useDarkMode ? foreColor : DefaultForeColor;
						tabPage.BackColor = useDarkMode ? backColor : DefaultBackColor;

						foreach (Control tabPageContent in tabPage.Controls)
						{
							tabPageContent.ForeColor = useDarkMode ? foreColor : DefaultForeColor;
							tabPageContent.BackColor = useDarkMode ? backColor : Color.White;
						}
					}
				}
			}

			this.tbFilter.BackColor = Color.Black;
			this.tbFilter.ForeColor = Color.Black;
		}

		public void ParseDatabase()
		{
			// Setup the icons for the tree view (arranging this in a for loop doesn't save any real space if you want it readable.)
			this.TreeViewImageList.Images.Add("Classes", Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Enumerations", Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Functions", Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Variables", Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Class", Properties.Resources.Class16x16);
			this.TreeViewImageList.Images.Add("Function", Properties.Resources.Function16x16);
			this.TreeViewImageList.Images.Add("Overload", Properties.Resources.Overload16x16);
			this.TreeViewImageList.Images.Add("Parameter", Properties.Resources.Variable16x16);
			this.TreeViewImageList.Images.Add("Enumeration", Properties.Resources.Enumeration16x16);
			this.TreeViewImageList.Images.Add("Member", Properties.Resources.Member16x16);
			this.TreeViewImageList.Images.Add("Variable", Properties.Resources.Variable16x16);

			// Create Tab Controls and TreeViews
			XmlNodeList scriptNodes = Config.DatabaseXml.SelectNodes("/Scripts/*");

			// Iterate through every available script type (Camera, Character, Hotspot, Level, Scriptable Campaign, Scriptable UI)
			foreach (XmlNode currentScriptNode in scriptNodes)
			{
				TabPage currentScriptTabPage = new TabPage(currentScriptNode.Attributes["Name"].Value);

				TreeView currentScriptTreeView = new TreeView();
				currentScriptTreeView.Dock = DockStyle.Fill;
				if (Config.ShowIconsForEachNode) currentScriptTreeView.ImageList = this.TreeViewImageList;
				if (Config.UseCustomFont) currentScriptTreeView.Font = Config.CustomFont;

				currentScriptTabPage.Controls.Add(currentScriptTreeView);
				tabScripts.TabPages.Add(currentScriptTabPage);
				
				// The reason we have this code sort of duplicated is that we want to have
				// multiple root nodes in the treeview. However, moving tree nodes is not possible.
				// So we treat those cases explicitly, and then parse the rest recursively.

				// We don't need to update the tree view while creating it.
				currentScriptTreeView.BeginUpdate();

				List<TreeNode> currentBackupNodes = new List<TreeNode>();

				// Iterate through the highest level (Classes, Enumerations, Functions, Values)
				foreach (XmlNode scriptElementNode in currentScriptNode.ChildNodes)
				{
					TreeNode scriptElementTreeNode = new TreeNode(scriptElementNode.Name);
					currentScriptTreeView.Nodes.Add(scriptElementTreeNode);

					// Attach the corresponding XmlNode to the TreeNode as the Tag. Why?
					// Because when the user selects the option to hide information from the tree node texts
					// like hide function names in overload signatures, we will expand/search/remove wrong elements!
					scriptElementTreeNode.Tag = scriptElementNode.Name.ToLower();

					// Iterate through the elements in the 2nd level
					foreach (XmlNode childElementNode in scriptElementNode.ChildNodes)
						this.CreateTreeNode(childElementNode, scriptElementTreeNode);

					currentBackupNodes.Add((TreeNode)scriptElementTreeNode.Clone());
				}

				this.BackupNodes.Add(currentScriptNode.Attributes["Name"].Value, currentBackupNodes);

				currentScriptTreeView.EndUpdate();
			}
		}

		// Handles the closing of helper window when the X is pressed.
		// Method is based on MarkdownViewer++'s implementation.
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			const int WM_NOTIFY = 0x004E;

			if (m.Msg == WM_NOTIFY)
			{
				NMHDR notification = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));

				if (notification.code == (int)Kbg.NppPluginNET.PluginInfrastructure.DockMgrMsg.DMN_CLOSE)
				{
					Main.ToggleHelperWindow();
				}
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		struct NMHDR
		{
			public IntPtr hwndFrom;
			public IntPtr idFrom;
			public uint code;
		}

		void CreateTreeNode(XmlNode currentNode, TreeNode parentTreeNode)
		{
			string currentText = ""; // Used for displaying.
			string fullText = ""; // Used for searching.
			
			switch (currentNode.Name)
			{
				case "Classes":
				case "Enumerations":
				case "Functions":
				case "Variables":
					currentText = currentNode.Name;
					fullText = currentText;
					break;

				case "Class":
				case "Enumeration":
				case "Function":
					currentText = currentNode.Attributes["Name"].Value;
					fullText = currentText;
					break;

				case "Member":
					currentText = currentNode.Attributes["Name"].Value + " = " + currentNode.Attributes["Value"].Value;
					fullText = currentText;
					break;

				case "Variable":
					currentText = currentNode.Attributes["Type"].Value + " " + currentNode.Attributes["Name"].Value;
					fullText = currentText;
					break;

				case "Overload":
					currentText = currentNode.Attributes["Type"].Value + " ";
					fullText = currentNode.Attributes["Type"].Value + " ";

					// I know that this case could be compacted a little,
					// but this way we highlight really what the difference between currentText and fullText is.

					if (Config.ShowFunctionNameInOverloadSignatures) currentText += currentNode.ParentNode.Attributes["Name"].Value;
					fullText += currentNode.ParentNode.Attributes["Name"].Value;

					currentText += "(";
					fullText += "(";

					// Don't forget to add the parameters!
					for (int i = 0; i < currentNode.ChildNodes.Count; i++)
					{
						currentText += currentNode.ChildNodes[i].Attributes["Type"].Value;
						fullText += currentNode.ChildNodes[i].Attributes["Type"].Value;

						if (currentNode.ChildNodes[i].Attributes["Name"].Value != "")
						{
							if (Config.ShowParameterNamesInOverloadSignatures) currentText += " " + currentNode.ChildNodes[i].Attributes["Name"].Value;
							fullText += " " + currentNode.ChildNodes[i].Attributes["Name"].Value;
						}

						if (currentNode.ChildNodes[i].Attributes["Value"].Value != "")
						{
							currentText += " = " + currentNode.ChildNodes[i].Attributes["Value"].Value;
							fullText += " = " + currentNode.ChildNodes[i].Attributes["Value"].Value;
						}
						
						if (i < currentNode.ChildNodes.Count - 1)
						{
							currentText += ", ";
							fullText += ", ";
						}
					}

					currentText += ")";
					fullText += ")";

					if (currentNode.Attributes["Const"].Value == "True")
					{
						currentText += " const";
						fullText += " const";
					}

					break;

				case "Parameter":
					currentText = currentNode.Attributes["Type"].Value;
					if (currentNode.Attributes["Name"].Value != "") currentText += " " + currentNode.Attributes["Name"].Value;
					if (currentNode.Attributes["Value"].Value != "") currentText += " = " + currentNode.Attributes["Value"].Value;

					fullText = currentText;
					break;
			}

			TreeNode currentTreeNode = new TreeNode(currentText);
			currentTreeNode.Tag = fullText.ToLower();
			currentTreeNode.ImageKey = currentNode.Name;
			currentTreeNode.SelectedImageKey = currentNode.Name;

			parentTreeNode.Nodes.Add(currentTreeNode);

			foreach (XmlNode childNode in currentNode.ChildNodes)
				CreateTreeNode(childNode, currentTreeNode);
		}

		// We are not using KeyPress because that doesn't return a KeyCode.
		// Just add a small security feature to not spam the filtering with holding the enter key.
		private void tbFilter_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && !this.HoldingEnterKey)
			{
				this.HoldingEnterKey = true;

				this.FilterTreeView((TreeView)tabScripts.SelectedTab.Controls[0], tbFilter.Text.ToLower());
			}
		}

		private void tbFilter_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && this.HoldingEnterKey)
			{
				this.HoldingEnterKey = false;
			}
		}

		private void tbFilter_TextChanged(object sender, EventArgs e)
		{
			if (Config.LiveFilteringMode) this.FilterTreeView((TreeView)tabScripts.SelectedTab.Controls[0], tbFilter.Text.ToLower());
		}

		private void FilterTreeView(TreeView treeView, string filterText)
		{
			// How does filtering work? First of, reconstruct the whole tree view because
			// we might have filtered before with a different search term.
			// Recursively search through the tree view, if you find an element where the
			// name is matching the filter text, keep it alive, and its surroundings.
			// Meaning, do not delete any of its children (just return from there) and its parents.

			treeView.BeginUpdate();

			this.ReconstructTreeView(treeView, tabScripts.SelectedTab.Text);

			if (filterText != "")
			{
				for (int i = treeView.Nodes.Count - 1; i >= 0; i--)
				{
					bool childWillSurvive = ((string)treeView.Nodes[i].Tag).Contains(filterText);

					FilterTreeNode(treeView.Nodes[i], filterText, childWillSurvive);
				}
					
			}

			treeView.EndUpdate();
		}

		private bool FilterTreeNode(TreeNode treeNode, string filterText, bool nodeWillSurvive)
		{
			bool keepNodeAlive = ((string)treeNode.Tag).Contains(filterText);
			bool childWillSurvive = keepNodeAlive | nodeWillSurvive;

			for (int i = treeNode.Nodes.Count - 1; i >= 0; i--)
				keepNodeAlive |= FilterTreeNode(treeNode.Nodes[i], filterText, childWillSurvive);

			if (keepNodeAlive) treeNode.Expand();
			else if (!nodeWillSurvive) treeNode.Remove();

			return keepNodeAlive;

		}

		private void ReconstructTreeView(TreeView treeView, string scriptName)
		{
			treeView.Nodes.Clear();

			foreach (TreeNode treeNode in this.BackupNodes[scriptName])
				treeView.Nodes.Add((TreeNode)treeNode.Clone());
		}

		public void SetTreeViewFonts(Font font)
		{
			foreach (TabPage tabPage in tabScripts.TabPages)
				tabPage.Controls[0].Font = font;
		}
	}
}
