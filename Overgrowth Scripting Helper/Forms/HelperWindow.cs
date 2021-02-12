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

		public HelperWindow()
		{
			InitializeComponent();

			// The helper window will not be set visible even when it's forced on startup
			// when the database is invalid or missing, therefore we can just return here.
			if (Config.DatabaseXml == null) return;

			// Setup the icons for the tree view (arranging this in a for loop doesn't save any real space if you want it readable.)
			TreeViewImageList.Images.Add("Classes",			Properties.Resources.Group16x16);
			TreeViewImageList.Images.Add("Enumerations",	Properties.Resources.Group16x16);
			TreeViewImageList.Images.Add("Functions",		Properties.Resources.Group16x16);
			TreeViewImageList.Images.Add("Variables",		Properties.Resources.Group16x16);
			TreeViewImageList.Images.Add("Class",			Properties.Resources.Class16x16);
			TreeViewImageList.Images.Add("Function",		Properties.Resources.Function16x16);
			TreeViewImageList.Images.Add("Overload",		Properties.Resources.Overload16x16);
			TreeViewImageList.Images.Add("Parameter",		Properties.Resources.Variable16x16);
			TreeViewImageList.Images.Add("Enumeration",		Properties.Resources.Enumeration16x16);
			TreeViewImageList.Images.Add("Member",			Properties.Resources.Member16x16);
			TreeViewImageList.Images.Add("Variable",		Properties.Resources.Variable16x16);

			// Create Tab Controls and TreeViews
			XmlNodeList scriptNodes = Config.DatabaseXml.SelectNodes("/Scripts/*");
			
			// Iterate through every available script type (Camera, Character, Hotspot, Level, Scriptable Campaign, Scriptable UI)
			foreach (XmlNode currentScriptNode in scriptNodes)
			{
				TabPage currentScriptTabPage = new TabPage(currentScriptNode.Attributes["Name"].Value);
				
				TreeView currentScriptTreeView = new TreeView();
				currentScriptTreeView.Dock = DockStyle.Fill;
				if (Config.ShowIconsForEachNode) currentScriptTreeView.ImageList = TreeViewImageList;
				if (Config.UseCustomFont) currentScriptTreeView.Font = Config.CustomFont;

				currentScriptTabPage.Controls.Add(currentScriptTreeView);
				tabScripts.TabPages.Add(currentScriptTabPage);

				// The reason we have this code sort of duplicated is that we want to have
				// multiple root nodes in the treeview. However, moving tree nodes is not possible.
				// So we treat those cases explicitly, and then parse the rest recursively.

				// We don't need to update the tree view while creating it.
				currentScriptTreeView.BeginUpdate();

				// Iterate through the highest level (Classes, Enumerations, Functions, Values)
				foreach (XmlNode scriptElementNode in currentScriptNode.ChildNodes)
				{
					TreeNode scriptElementTreeNode = new TreeNode(scriptElementNode.Name);
					currentScriptTreeView.Nodes.Add(scriptElementTreeNode);
					
					// Iterate through the elements in the 2nd level
					foreach (XmlNode childElementNode in scriptElementNode.ChildNodes)
						CreateTreeNode(childElementNode, scriptElementTreeNode);
				}

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

				case "Variable":
					currentText = currentNode.Attributes["Type"].Value + " " + currentNode.Attributes["Name"].Value;
					break;

				case "Overload":
					currentText = currentNode.Attributes["Type"].Value + " " + currentNode.ParentNode.Attributes["Name"].Value;
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
	}
}
