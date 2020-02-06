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
        private Dictionary<string, List<TreeNode>> treeNodesBackup = new Dictionary<string, List<TreeNode>>();
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
                database.Load("plugins\\Overgrowth++\\Database.xml"); 
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
                foreach (XmlElement currentScript in scripts)
                {
                    // Create a new tab page for the script type
                    TabPage tabPage = new TabPage(currentScript.GetAttribute("Name"));
                    tabScriptTypes.TabPages.Add(tabPage);

                    // Create the TreeView for the script type
                    TreeView treeView = new TreeView();
                    treeView.Dock = DockStyle.Fill;

                    if (Config.Appearance.ShowTooltipsWhileHoveringOverTreeViewNodes) treeView.ShowNodeToolTips = true;
                    if (Config.Appearance.UseCustomFont) treeView.Font = Config.Appearance.CustomFont;
                    if (Config.Appearance.ShowIconsForEachNode) treeView.ImageList = treeViewImageList;

                    tabPage.Controls.Add(treeView);
                    
                    // Prepare the backup dictionary entry
                    treeNodesBackup.Add(currentScript.GetAttribute("Name"), new List<TreeNode>());

                    // We create the Classes/Enumerations/Functions/Variables (the topmost ones in the file) separate
                    // because this way we don't have to move the Nodes later since we will be using recursive functions to build the TreeView
                    foreach (XmlNode currentElement in currentScript.ChildNodes)
                    {
                        TreeNode treeNode = new TreeNode(currentElement.Name);
                        treeView.Nodes.Add(treeNode);

                        AssignImageKey(treeNode, currentElement.Name);

                        foreach (XmlElement childElement in currentElement.ChildNodes)
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

                        // Add the node to the backup which will be used later while filtering
                        treeNodesBackup[currentScript.GetAttribute("Name")].Add((TreeNode)treeNode.Clone()) ;
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
         * 
         * How does database look?
         * 
         * <Scripts>
         *  <Script Name="Camera">
         *      <Classes>
         *          <Class Name="ASCollision">
         *              <Classes />
         *              <Enumerations />
         *              <Functions>
         *                  <Function Name="CheckRayCollisionCharacters">
         *                      <Overload Type="void" Const="False">
         *                          <Parameter Type="vec3" Name="start" Value="" />
         *                          <Parameter Type="vec3" Name="end" Value="" />
         *                      </Overload>
         *                  </Function>
         *              <Functions>
         *              <Variables />
         *          </Class>
         *     <Enumerations>
         *      <Enumeration Name="CameraFlags">
         *          <EnumerationMember Name="kEditorCamera" Value="1" />
         *          <EnumerationMember Name="kPreviewCamera" Value="2" />
         *      </Enumeration>
         *     </Enumerations>
         *     <Functions />
         *     <Variables>
         *      <Variable Name="_awake" />
         *      <Variable Name="_collectable" />
         *     </Variables>
         *  </Script>
         * </Scripts>
         */
        private void MakeTreeNode(XmlElement xmlElement, TreeNode parentTreeNode, string nodeType)
        {
            string nodeText;
            string nodeDescription = "To Be Filled By O.E.M." + xmlElement.GetAttribute("Description");

            // TODO: Comment for each type of node

            // Different node types in the TreeView have different display text.
            // A function only needs to show the name whereas the overload needs to fully display the overload.
            // We switch the type here and print each TreeNode text according to the type.
            switch (nodeType)
            {
                case "Group":
                    nodeText = xmlElement.Name;
                    break;

                case "Overload":
                    nodeText = xmlElement.GetAttribute("Type") + " " + ((XmlElement)xmlElement.ParentNode).GetAttribute("Name");

                    // Add the parameters
                    nodeText += "(";

                    for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
                    {
                        XmlElement currentParameter = (XmlElement)xmlElement.ChildNodes[i];

                        nodeText += currentParameter.GetAttribute("Type");
                        if (currentParameter.GetAttribute("Name") != "") nodeText += " " + currentParameter.GetAttribute("Name");
                        if (currentParameter.GetAttribute("Value") != "") nodeText += " = " + currentParameter.GetAttribute("Value");

                        if (i < xmlElement.ChildNodes.Count - 1) nodeText += ", ";
                    }

                    nodeText += ")";
                    if (xmlElement.GetAttribute("Const") == "True") nodeText += " const";
                    break;

                case "Parameter":
                    nodeText = xmlElement.GetAttribute("Type");
                    if (xmlElement.GetAttribute("Name") != "") nodeText += " " + xmlElement.GetAttribute("Name");
                    if (xmlElement.GetAttribute("Value") != "") nodeText += " = " + xmlElement.GetAttribute("Value");

                    break;

                case "EnumerationMember":
                    nodeText = xmlElement.GetAttribute("Name") + " = " + xmlElement.GetAttribute("Value");
                    break;

                default:
                    nodeText = xmlElement.GetAttribute("Name");
                    break;
            }

            TreeNode currentTreeNode = new TreeNode(nodeText);
            currentTreeNode.ToolTipText = nodeDescription;
            parentTreeNode.Nodes.Add(currentTreeNode);

            AssignImageKey(currentTreeNode, nodeType);

            string childType = "";

            switch (nodeType)
            {
                case "Group":
                    switch (xmlElement.Name)
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

            foreach (XmlElement childElement in xmlElement.ChildNodes)
            {
                MakeTreeNode(childElement, currentTreeNode, childType);
            }
        }

        // Assigns the correct ImageKey to a treeNode identified by the node type
        // We will use this also to recognise what Node we are currently on while filtering to match our settings
        private void AssignImageKey(TreeNode treeNode, string nodeType)
        {
            string imageKey;

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

                default: throw new Exception("Unknown Node Type \"" + nodeType + "\" parentNode.Text=" + treeNode.Parent.Text);
            }

            treeNode.ImageKey = imageKey;
            treeNode.SelectedImageKey = imageKey;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (Config.General.LiveFilteringMode) ApplyFilterToListView();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') ApplyFilterToListView();
        }

        private void ApplyFilterToListView()
        {
            TreeView currentTV = (TreeView)tabScriptTypes.SelectedTab.Controls[0];

            // Disable UI Updates for the TreeView while we are performing operations on it.
            // This way it won't perform any unnecessary refreshes while adding/removing nodes.
            currentTV.BeginUpdate();

            ReconstructTreeView(currentTV, treeNodesBackup[tabScriptTypes.SelectedTab.Text]);

            if (tbFilter.Text != "")
            {
                // Go backwards because we are deleting nodes.  
                for (int i = currentTV.Nodes.Count - 1; i >= 0; i--)
                {
                    TreeNode node = currentTV.Nodes[i];
                    ExpandNodeOnFilterMatch(node, tbFilter.Text);
                }
            }

            currentTV.EndUpdate();
        }

        private bool ExpandNodeOnFilterMatch(TreeNode node, string filter)
        {
            // Check what filter matching settings are valid.
            bool found = false;
            
            if (node.Text.ToLower().Contains(filter.ToLower())) found = true;

            for (int i = node.Nodes.Count - 1; i >= 0; i--)
                if (ExpandNodeOnFilterMatch(node.Nodes[i], filter)) found = true;

            if (found) node.Expand();
            else node.Remove();
            
            return found;
        }

        private void ReconstructTreeView(TreeView tv, List<TreeNode> nodes)
        {
            tv.Nodes.Clear();

            foreach (TreeNode node in nodes)
                tv.Nodes.Add((TreeNode)node.Clone());
        }
    }
}
