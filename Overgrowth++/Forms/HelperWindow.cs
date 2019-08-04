using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Xml;

namespace Overgrowth__
{
    public partial class HelperWindow : Form
    {
        private Dictionary<string, List<TreeNode>> clonedBackup = new Dictionary<string, List<TreeNode>>();
        private ImageList treeViewIcons = new ImageList();

        public HelperWindow()
        {
            // Tabs und Treeviews automatisch erzeugen je nachdem was im XML zu finden ist

            InitializeComponent();

            treeViewIcons.ImageSize = new Size(16, 16);
            treeViewIcons.Images.Add("Class", Properties.Resources.classes);
            treeViewIcons.Images.Add("Function", Properties.Resources.functions);
            treeViewIcons.Images.Add("Enumeration", Properties.Resources.enums);
            treeViewIcons.Images.Add("Variable", Properties.Resources.variables);
            treeViewIcons.Images.Add("Type", Properties.Resources.types);

            string[] types = new string[] { "Character", "Level", "Hotspot", "Camera", "ScriptableCampaign", "ScriptableUI" };
            TreeView[] typeTreeViews = new TreeView[] { tvCharacter, tvLevel, tvHotspot, tvCamera, tvScriptableCampaign, tvScriptableUI };

            XmlDocument database = new XmlDocument();
            database.Load(@"E:\Programmiersprachen\AutoIt3\Overgrowth Calltipmaker\Notepad++ Overgrowth\plugins\Overgrowth++\Database.xml");

            for (int i = 0; i < types.Length; i++)
            {
                typeTreeViews[i].ImageList = treeViewIcons;

                if (Config.Get("UseCustomFont") == "true")
                    typeTreeViews[i].Font = new System.Drawing.Font(Config.Get("FontName"), System.Convert.ToSingle(Config.Get("FontSize")));

                XmlNode currentTypeNode = database.SelectSingleNode("/Scripts/" + types[i]);
                if (currentTypeNode == null) continue;

                typeTreeViews[i].BeginUpdate();

                TreeNode rootTreeNode = typeTreeViews[i].Nodes.Add(types[i]);

                clonedBackup.Add(types[i], new List<TreeNode>());

                foreach (XmlNode childNode in currentTypeNode.ChildNodes)
                {
                    appendChildren(childNode, rootTreeNode, childNode.Name);
                    TreeNode currentTypeTreeNode = rootTreeNode.Nodes[0];
                    AssignImageKey(currentTypeTreeNode, rootTreeNode.Nodes[0].Name);
                    rootTreeNode.Nodes[0].Remove();
                    typeTreeViews[i].Nodes.Add(currentTypeTreeNode);
                }

                rootTreeNode.Remove();

                typeTreeViews[i].EndUpdate();
            }

            for (int i = 0; i < types.Length; i++)
            {
                foreach (TreeNode rootNode in typeTreeViews[i].Nodes)
                {
                    TreeNode cloned = new TreeNode(rootNode.Text); // (TreeNode)rootNode.Clone();
                    cloneNode(cloned, rootNode);

                    clonedBackup[types[i]].Add(cloned);
                }
            }
        }

        private void cloneNode(TreeNode clone, TreeNode original)
        {
            foreach (TreeNode childOfOriginal in original.Nodes)
            {
                TreeNode childClone = new TreeNode(childOfOriginal.Text);// (TreeNode)childOfOriginal.Clone();

                clone.Nodes.Add(childClone);
                cloneNode(childClone, childOfOriginal);
            }
        }

        /*
         * We are letting the parent node set the children items because
         * we have no root element in this TreeView.
         */

        private void appendChildren(XmlNode currentNode, TreeNode parentNode, string currentType)
        {
            TreeNode currentTreeNode = new TreeNode();
            AssignImageKey(currentTreeNode, currentType);

            string childType = "";

            switch (currentType)
            {
                case "Classes": childType = "Class"; currentTreeNode.Text = currentNode.Name; break;
                case "Functions": childType = "Function"; currentTreeNode.Text = currentNode.Name; break;
                case "Enumerations": childType = "Enumeration"; currentTreeNode.Text = currentNode.Name; break;
                case "Variables": childType = "Variable"; currentTreeNode.Text = currentNode.Name; break;

                case "Class": childType = "ClassMember"; currentTreeNode.Text = currentNode.Name; break;
                case "Function": childType = "Overload"; currentTreeNode.Text = currentNode.Name; break;
                case "Enumeration": childType = "EnumMember"; currentTreeNode.Text = currentNode.Name; break;
                case "Variable": childType = ""; currentTreeNode.Text = currentNode.InnerText; break;

                case "ClassMember": childType = GetClassChildType(currentNode.Name); currentTreeNode.Text = currentNode.Name; break;
                case "EnumMember": childType = ""; currentTreeNode.Text = currentNode.Name + " = " + currentNode.InnerText; break;
                case "Overload": childType = "Param"; currentTreeNode.Text = currentNode.Attributes["Signature"].Value; break;
                case "Param": childType = ""; currentTreeNode.Text = currentNode.InnerText; break;
            }

            parentNode.Nodes.Add(currentTreeNode);

            if (currentType == "EnumMember" || currentType == "Param" || currentType == "Variable") return;

            foreach (XmlNode childNode in currentNode.ChildNodes)
            {
                appendChildren(childNode, currentTreeNode, childType);
            }
        }

        private void AssignImageKey(TreeNode node, string type)
        {
            switch (type)
            {
                case "Classes":
                case "Functions":
                case "Enumerations":
                case "Variables":
                    type = "Class"; break;

                case "Function":
                case "Overload":
                    type = "Function"; break;

                case "Class":
                    type = "Class"; break;

                case "Enumeration":
                case "EnumMember":
                    type = "Enumeration"; break;

                case "Variable":
                    type = "Variable"; break;

                default:
                    type = ""; break;
            }

            node.ImageKey = type;
            node.SelectedImageKey = type;
        }

        private string GetClassChildType(string s)
        {
            switch (s)
            {
                case "Functions": return "Function";
                case "Classes": return "Class";
                case "Enumerations": return "Enumeration";
                case "Variables": return "Variable";
            }

            return "";
        }

        private bool checkAndExpand(TreeNode node, string filter)
        {
            bool returnValue = false;

            if (node.Nodes.Count > 0)
            {
                //foreach (TreeNode childNode in node.Nodes)
                for (int i = node.Nodes.Count - 1; i >= 0; i--)
                {
                    if (checkAndExpand(node.Nodes[i], filter))
                    {
                        returnValue = true;
                    }
                }
            }

            if (node.Text.ToLower().Contains(filter.ToLower())) returnValue = true;

            if (returnValue)
            {
                node.Expand();
                return true;
            }
            else
            {
                node.Remove();
                return false;
            }
        }

        private void reconstructTreeView(TreeView tv, List<TreeNode> nodes)
        {
            tv.Nodes.Clear();

            foreach (TreeNode node in nodes)
            {
                // We don't use node.Clone because it takes longer than creating a new one with the same text.
                // And since we don't set custom font this is OK.
                TreeNode clone = new TreeNode(node.Text);// (TreeNode)node.Clone();
                reconstructTreeNode(clone, node);

                tv.Nodes.Add(clone);
            }
        }

        private void reconstructTreeNode(TreeNode clone, TreeNode original)
        {
            foreach (TreeNode child in original.Nodes)
            {
                TreeNode childClone = new TreeNode(child.Text);// (TreeNode)child.Clone();
                reconstructTreeNode(childClone, child);

                clone.Nodes.Add(childClone);
            }
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || Config.Get("LiveFilteringMode") == "true")
            {
                TreeView currentTV = (TreeView)tabScriptTypes.SelectedTab.Controls[0];
                reconstructTreeView(currentTV, clonedBackup[tabScriptTypes.SelectedTab.Text]);
                
                if (tbFilter.Text != "")
                {
                    for (int i = currentTV.Nodes.Count - 1; i >= 0; i--)
                    {
                        TreeNode node = currentTV.Nodes[i];

                        if (node != null) checkAndExpand(node, tbFilter.Text);
                        else System.Diagnostics.Debug.WriteLine("Null found!");
                    }
                }
            }
        }
    }
}
