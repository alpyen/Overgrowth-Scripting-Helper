using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

namespace Overgrowth_Scripting_Helper
{
	public partial class HelperWindow : Form
	{
		private ImageList TreeViewImageList = new ImageList();
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

			// The helper window will not be set visible even when it's forced on startup
			// when the database is invalid or missing, therefore we can just return here.
			if (Config.DatabaseXml == null) return;

			// Setup the icons for the tree view (arranging this in a for loop doesn't save any real space if you want it readable.)
			this.TreeViewImageList.Images.Add("Classes",		Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Enumerations",	Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Functions",		Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Variables",		Properties.Resources.Group16x16);
			this.TreeViewImageList.Images.Add("Class",			Properties.Resources.Class16x16);
			this.TreeViewImageList.Images.Add("Function",		Properties.Resources.Function16x16);
			this.TreeViewImageList.Images.Add("Overload",		Properties.Resources.Overload16x16);
			this.TreeViewImageList.Images.Add("Parameter",		Properties.Resources.Variable16x16);
			this.TreeViewImageList.Images.Add("Enumeration",	Properties.Resources.Enumeration16x16);
			this.TreeViewImageList.Images.Add("Member",			Properties.Resources.Member16x16);
			this.TreeViewImageList.Images.Add("Variable",		Properties.Resources.Variable16x16);

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

					// Iterate through the elements in the 2nd level
					foreach (XmlNode childElementNode in scriptElementNode.ChildNodes)
						this.CreateTreeNode(childElementNode, scriptElementTreeNode);

					currentBackupNodes.Add((TreeNode)scriptElementTreeNode.Clone());
				}

				this.BackupNodes.Add(currentScriptNode.Attributes["Name"].Value, currentBackupNodes);

				currentScriptTreeView.EndUpdate();
			}
		}

		void CreateTreeNode(XmlNode currentNode, TreeNode parentTreeNode)
		{
			string currentText = "";
			
			switch (currentNode.Name)
			{
				case "Classes":
				case "Enumerations":
				case "Functions":
				case "Variables":
					currentText = currentNode.Name;
					break;

				case "Class":
				case "Enumeration":
				case "Function":
					currentText = currentNode.Attributes["Name"].Value;
					break;

				case "Member":
					currentText = currentNode.Attributes["Name"].Value + " = " + currentNode.Attributes["Value"].Value;
					break;

				case "Variable":
					currentText = currentNode.Attributes["Type"].Value + " " + currentNode.Attributes["Name"].Value;
					break;

				case "Overload":
					currentText = currentNode.Attributes["Type"].Value + " " + (Config.ShowFunctionNameInOverloadSignatures ? currentNode.ParentNode.Attributes["Name"].Value : "");
					currentText += "(";

					// Don't forget to add the parameters!
					for (int i = 0; i < currentNode.ChildNodes.Count; i++)
					{
						currentText += currentNode.ChildNodes[i].Attributes["Value"].Value;
						if (i < currentNode.ChildNodes.Count - 1) currentText += ", ";
					}

					currentText += ")";
					if (currentNode.Attributes["Const"].Value == "True") currentText += " const";
					break;

				case "Parameter":
					currentText = currentNode.Attributes["Value"].Value;
					break;
			}

			TreeNode currentTreeNode = new TreeNode(currentText);
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
					bool childWillSurvive = treeView.Nodes[i].Text.ToLower().Contains(filterText);

					FilterTreeNode(treeView.Nodes[i], filterText, childWillSurvive);
				}
					
			}

			treeView.EndUpdate();
		}

		private bool FilterTreeNode(TreeNode treeNode, string filterText, bool nodeWillSurvive)
		{
			bool keepNodeAlive = treeNode.Text.ToLower().Contains(filterText);
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
