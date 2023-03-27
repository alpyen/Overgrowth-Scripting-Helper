
namespace Overgrowth_Scripting_Helper
{
	partial class CheatSheetWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("mod.xml", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Level.xml", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Scripts", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Default", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Any",
            "/",
            "Every other path."}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "#include",
            "Data/Scripts/",
            "Including a script file into the current script."}, -1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Campaign.Thumbnail",
            "Data/",
            "Thumbnail image for a campaign."}, -1);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Campaign.Menu_Script",
            "Data/Scripts/",
            "The menu script for a campaign."}, -1);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Campaign.Menu_Script",
            "Data/Scripts/",
            "The main script for a campaign."}, -1);
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Level.Thumbnail",
            "Data/",
            "Thumnail image for a level."}, -1);
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Level.InnerText",
            "Data/Levels/",
            "Path to the level file."}, -1);
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Script.InnerText",
            "Data/Scripts/",
            "Path to the level script file."}, -1);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheatSheetWindow));
			this.lvCheatSheet = new System.Windows.Forms.ListView();
			this.columnElement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnRoot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lvCheatSheet
			// 
			this.lvCheatSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnElement,
            this.columnRoot,
            this.columnDescription});
			this.lvCheatSheet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvCheatSheet.FullRowSelect = true;
			listViewGroup1.Header = "mod.xml";
			listViewGroup1.Name = "mod.xml";
			listViewGroup2.Header = "Level.xml";
			listViewGroup2.Name = "Level.xml";
			listViewGroup3.Header = "Scripts";
			listViewGroup3.Name = "Scripts";
			listViewGroup4.Header = "Default";
			listViewGroup4.Name = "Default";
			this.lvCheatSheet.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
			this.lvCheatSheet.HideSelection = false;
			listViewItem1.Group = listViewGroup4;
			listViewItem2.Group = listViewGroup3;
			listViewItem3.Group = listViewGroup1;
			listViewItem4.Group = listViewGroup1;
			listViewItem5.Group = listViewGroup1;
			listViewItem6.Group = listViewGroup1;
			listViewItem7.Group = listViewGroup1;
			listViewItem8.Group = listViewGroup2;
			this.lvCheatSheet.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
			this.lvCheatSheet.Location = new System.Drawing.Point(0, 0);
			this.lvCheatSheet.Name = "lvCheatSheet";
			this.lvCheatSheet.Size = new System.Drawing.Size(601, 350);
			this.lvCheatSheet.TabIndex = 0;
			this.lvCheatSheet.UseCompatibleStateImageBehavior = false;
			this.lvCheatSheet.View = System.Windows.Forms.View.Details;
			// 
			// columnElement
			// 
			this.columnElement.Text = "Element";
			this.columnElement.Width = 150;
			// 
			// columnRoot
			// 
			this.columnRoot.Text = "Root";
			this.columnRoot.Width = 150;
			// 
			// columnDescription
			// 
			this.columnDescription.Text = "Description";
			this.columnDescription.Width = 250;
			// 
			// CheatSheetWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 350);
			this.Controls.Add(this.lvCheatSheet);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CheatSheetWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CheatSheetWindow";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheatSheetWindow_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvCheatSheet;
		private System.Windows.Forms.ColumnHeader columnElement;
		private System.Windows.Forms.ColumnHeader columnRoot;
		private System.Windows.Forms.ColumnHeader columnDescription;
	}
}