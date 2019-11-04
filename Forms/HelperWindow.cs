using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

namespace Overgrowth__
{
    public partial class HelperWindow : Form
    {
        private Dictionary<string, List<TreeNode>> clonedBackup = new Dictionary<string, List<TreeNode>>();
        private ImageList treeViewImageList = new ImageList();

        public HelperWindow()
        {
            InitializeComponent();
            
            // Add the icons to the TreeView ImageList, so we later only need to assign the ImageKey.
            treeViewImageList.ImageSize = new Size(16, 16);
            treeViewImageList.Images.Add("Group", Properties.Resources.group);
            treeViewImageList.Images.Add("Class", Properties.Resources._class);
            treeViewImageList.Images.Add("Function", Properties.Resources.function);
            treeViewImageList.Images.Add("Overload", Properties.Resources.overload);
            treeViewImageList.Images.Add("Parameter", Properties.Resources.variable);
            treeViewImageList.Images.Add("Enumeration", Properties.Resources.enumeration);
            treeViewImageList.Images.Add("EnumerationMember", Properties.Resources.enumeration_member);
            treeViewImageList.Images.Add("Variable", Properties.Resources.variable);

            // Loading the Database.xml file (which needs to be placed right beside the Overgrowth++.dll in the Npp Plugin folder)
            XmlDocument database = new XmlDocument();

            try
            { 
                database.Load(@"C:\Users\fractal\Desktop\Notepad++ Overgrowth Angelscript\plugins\Overgrowth++\Database.xml"); 
            }
            catch (Exception e)
            {
                MessageBox.Show("There seems to be something wrong with loading the Database.xml file!" + "\r\n\r\n" +
                    "Error Message: " + e.Message, "Oops! An error occured :(", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            
            // Create tabs for each Tag find under <Scripts> which represent the Script-Type (Character, Level, Hotspot, ...)
            try
            {
                XmlNodeList scripts = database.SelectNodes("/Scripts/*");

                // Go through each scripttype (Character, Level, Hotspot, ...)
                foreach (XmlNode script in scripts)
                {
                    // Create a new tab page for the script type
                    TabPage tabPage = new TabPage(script.Name);
                    tabScriptTypes.TabPages.Add(tabPage);

                    // Create the TreeView for the script type
                    TreeView treeView = new TreeView();
                    treeView.Dock = DockStyle.Fill;

                    if (Config.Get("UseCustomFont") == "true")
                        treeView.Font = new Font(Config.Get("FontName"), Convert.ToSingle(Config.Get("FontSize")));
                    
                    treeView.ImageList = treeViewImageList;
                    tabPage.Controls.Add(treeView); 

                    // We create the Classes/Enumerations/Functions/Variables (the topmost ones in the file) separate
                    // because this way we don't have to move the Nodes later since we will be using recursive functions to build the TreeView
                    foreach (XmlNode currentElement in script.ChildNodes)
                    {
                        TreeNode treeNode = new TreeNode(currentElement.Name);
                        treeView.Nodes.Add(treeNode);

                        AssignImageKey(treeNode, currentElement.Name);

                        foreach (XmlNode childElement in currentElement.ChildNodes)
                        {
                            string childType = "";

                            switch (currentElement.Name)
                            {
                                case "Classes": childType = "Class"; break;
                                case "Enumerations": childType = "Enumeration"; break;
                                case "Functions": childType = "Function"; break;
                                case "Variables": childType = "Variable"; break;
                            }

                            MakeTreeNode(childElement, treeNode, childType);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured while parsing the Database.xml file." + "\r\n\r\n" +
                    "Error Message: " + e.Message, "Oops! An error occured :(", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        /* This is where the TreeNode-Creation magic happens.
         * 
         * For the database to make its way into the TreeView we need to step through it and add each item.
         * Using a recursive function will save us a lot of trouble since we only need to provide a template on how one XmlNode should be handled.
         * Once that is done, we simply need to call the function for its child nodes and we will automatically step through the whole database.
         * 
         * Since our Database is not very deep (recursively) we don't need to worry about overflowing our stack.
         */
        private void MakeTreeNode(XmlNode xmlNode, TreeNode parentTreeNode, string nodeType)
        {
            string nodeText = ((XmlElement)xmlNode).HasAttribute("Name") ? ((XmlElement)xmlNode).GetAttribute("Name") : xmlNode.Name;
            TreeNode currentTreeNode = new TreeNode(nodeText);
            parentTreeNode.Nodes.Add(currentTreeNode);

            AssignImageKey(currentTreeNode, nodeType);

            string childType = "";

            switch (nodeType)
            {
                case "Group":
                    switch (xmlNode.Name)
                    {
                        case "Classes": childType = "Class"; break;
                        case "Enumerations": childType = "Enumeration"; break;
                        case "Functions": childType = "Function"; break;
                        case "Variables": childType = "Variable"; break;
                    }
                    break;

                case "Class": childType = "Group"; break;
                case "Enumeration": childType = "EnumerationMember"; break;
                case "Function": childType = "Overload"; break;
                case "Overload": childType = "Parameter"; break;

                // Variable and Parameter have no children, therefore it will not run the foreach loop which means we don't have to set a childType.
            }

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                MakeTreeNode(childNode, currentTreeNode, childType);
            }
        }

        // Assigns the correct ImageKey to a treeNode identified by the node type
        private void AssignImageKey(TreeNode treeNode, string nodeType)
        {
            string imageKey = "";

            switch (nodeType)
            {
                case "Group":
                case "Classes":
                case "Functions":
                case "Enumerations":
                case "Variables":
                    imageKey = "Group";
                    break;

                case "Class": imageKey = "Class"; break;
                case "Function": imageKey = "Function"; break;
                case "Overload": imageKey = "Overload"; break;
                case "Parameter": imageKey = "Parameter"; break;
                case "Enumeration": imageKey = "Enumeration"; break;
                case "EnumerationMember": imageKey = "EnumerationMember"; break;
                case "Variable": imageKey = "Variable"; break;

                default: throw new Exception("Unbekannter Node Type \"" + nodeType + "\" parentNode.Text=" + treeNode.Parent.Text);
            }

            treeNode.ImageKey = imageKey;
            treeNode.SelectedImageKey = imageKey;
        }

        /////////////////////// ALTER SHIT

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

        private void AssignImageKey1(TreeNode node, string type)
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
