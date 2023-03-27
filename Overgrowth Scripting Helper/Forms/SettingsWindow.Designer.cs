
namespace Overgrowth_Scripting_Helper
{
	partial class SettingsWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
			this.pbBackground = new System.Windows.Forms.PictureBox();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.groupGeneral = new System.Windows.Forms.GroupBox();
			this.cbLiveFilteringMode = new System.Windows.Forms.CheckBox();
			this.cbShowHelperWindowOnStartup = new System.Windows.Forms.CheckBox();
			this.groupAppearance = new System.Windows.Forms.GroupBox();
			this.cbShowParameterNamesInOverloadSignatures = new System.Windows.Forms.CheckBox();
			this.btnChangeFont = new System.Windows.Forms.Button();
			this.cbUseCustomFont = new System.Windows.Forms.CheckBox();
			this.cbShowIconsForEachNode = new System.Windows.Forms.CheckBox();
			this.cbShowFunctionNameInOverloadSignatures = new System.Windows.Forms.CheckBox();
			this.cbUseDarkMode = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
			this.groupGeneral.SuspendLayout();
			this.groupAppearance.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbBackground
			// 
			this.pbBackground.Image = global::Overgrowth_Scripting_Helper.Properties.Resources.Background;
			this.pbBackground.Location = new System.Drawing.Point(0, 0);
			this.pbBackground.Name = "pbBackground";
			this.pbBackground.Size = new System.Drawing.Size(661, 366);
			this.pbBackground.TabIndex = 7;
			this.pbBackground.TabStop = false;
			// 
			// groupGeneral
			// 
			this.groupGeneral.Controls.Add(this.cbLiveFilteringMode);
			this.groupGeneral.Controls.Add(this.cbShowHelperWindowOnStartup);
			this.groupGeneral.Location = new System.Drawing.Point(12, 12);
			this.groupGeneral.Name = "groupGeneral";
			this.groupGeneral.Size = new System.Drawing.Size(434, 81);
			this.groupGeneral.TabIndex = 24;
			this.groupGeneral.TabStop = false;
			this.groupGeneral.Text = "General";
			// 
			// cbLiveFilteringMode
			// 
			this.cbLiveFilteringMode.AutoSize = true;
			this.cbLiveFilteringMode.Location = new System.Drawing.Point(17, 47);
			this.cbLiveFilteringMode.Name = "cbLiveFilteringMode";
			this.cbLiveFilteringMode.Size = new System.Drawing.Size(277, 17);
			this.cbLiveFilteringMode.TabIndex = 19;
			this.cbLiveFilteringMode.Text = "Live filtering mode (warning: very performance heavy)";
			this.cbLiveFilteringMode.UseVisualStyleBackColor = false;
			// 
			// cbShowHelperWindowOnStartup
			// 
			this.cbShowHelperWindowOnStartup.AutoSize = true;
			this.cbShowHelperWindowOnStartup.Location = new System.Drawing.Point(17, 24);
			this.cbShowHelperWindowOnStartup.Name = "cbShowHelperWindowOnStartup";
			this.cbShowHelperWindowOnStartup.Size = new System.Drawing.Size(211, 17);
			this.cbShowHelperWindowOnStartup.TabIndex = 18;
			this.cbShowHelperWindowOnStartup.Text = "Show helper sidebar window on startup";
			this.cbShowHelperWindowOnStartup.UseVisualStyleBackColor = false;
			// 
			// groupAppearance
			// 
			this.groupAppearance.Controls.Add(this.cbUseDarkMode);
			this.groupAppearance.Controls.Add(this.cbShowParameterNamesInOverloadSignatures);
			this.groupAppearance.Controls.Add(this.btnChangeFont);
			this.groupAppearance.Controls.Add(this.cbUseCustomFont);
			this.groupAppearance.Controls.Add(this.cbShowIconsForEachNode);
			this.groupAppearance.Controls.Add(this.cbShowFunctionNameInOverloadSignatures);
			this.groupAppearance.Location = new System.Drawing.Point(12, 99);
			this.groupAppearance.Name = "groupAppearance";
			this.groupAppearance.Size = new System.Drawing.Size(434, 179);
			this.groupAppearance.TabIndex = 25;
			this.groupAppearance.TabStop = false;
			this.groupAppearance.Text = "Appearance";
			// 
			// cbShowParameterNamesInOverloadSignatures
			// 
			this.cbShowParameterNamesInOverloadSignatures.AutoSize = true;
			this.cbShowParameterNamesInOverloadSignatures.Location = new System.Drawing.Point(17, 47);
			this.cbShowParameterNamesInOverloadSignatures.Name = "cbShowParameterNamesInOverloadSignatures";
			this.cbShowParameterNamesInOverloadSignatures.Size = new System.Drawing.Size(377, 17);
			this.cbShowParameterNamesInOverloadSignatures.TabIndex = 34;
			this.cbShowParameterNamesInOverloadSignatures.Text = "Show parameter names in overload signatures (requires Notepad++ restart)";
			this.cbShowParameterNamesInOverloadSignatures.UseVisualStyleBackColor = false;
			// 
			// btnChangeFont
			// 
			this.btnChangeFont.Location = new System.Drawing.Point(17, 139);
			this.btnChangeFont.Name = "btnChangeFont";
			this.btnChangeFont.Size = new System.Drawing.Size(86, 23);
			this.btnChangeFont.TabIndex = 33;
			this.btnChangeFont.Text = "Change Font";
			this.btnChangeFont.UseVisualStyleBackColor = true;
			this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
			// 
			// cbUseCustomFont
			// 
			this.cbUseCustomFont.AutoSize = true;
			this.cbUseCustomFont.Location = new System.Drawing.Point(17, 116);
			this.cbUseCustomFont.Name = "cbUseCustomFont";
			this.cbUseCustomFont.Size = new System.Drawing.Size(107, 17);
			this.cbUseCustomFont.TabIndex = 32;
			this.cbUseCustomFont.Text = "Use Custom Font";
			this.cbUseCustomFont.UseVisualStyleBackColor = false;
			this.cbUseCustomFont.Click += new System.EventHandler(this.cbUseCustomFont_CheckedChanged);
			// 
			// cbShowIconsForEachNode
			// 
			this.cbShowIconsForEachNode.AutoSize = true;
			this.cbShowIconsForEachNode.Location = new System.Drawing.Point(17, 70);
			this.cbShowIconsForEachNode.Name = "cbShowIconsForEachNode";
			this.cbShowIconsForEachNode.Size = new System.Drawing.Size(284, 17);
			this.cbShowIconsForEachNode.TabIndex = 31;
			this.cbShowIconsForEachNode.Text = "Show icons for each node (requires Notepad++ restart)";
			this.cbShowIconsForEachNode.UseVisualStyleBackColor = false;
			// 
			// cbShowFunctionNameInOverloadSignatures
			// 
			this.cbShowFunctionNameInOverloadSignatures.AutoSize = true;
			this.cbShowFunctionNameInOverloadSignatures.Location = new System.Drawing.Point(17, 24);
			this.cbShowFunctionNameInOverloadSignatures.Name = "cbShowFunctionNameInOverloadSignatures";
			this.cbShowFunctionNameInOverloadSignatures.Size = new System.Drawing.Size(368, 17);
			this.cbShowFunctionNameInOverloadSignatures.TabIndex = 28;
			this.cbShowFunctionNameInOverloadSignatures.Text = "Show function names in overload signatures (requires Notepad++ restart)";
			this.cbShowFunctionNameInOverloadSignatures.UseVisualStyleBackColor = true;
			// 
			// cbUseDarkMode
			// 
			this.cbUseDarkMode.AutoSize = true;
			this.cbUseDarkMode.Location = new System.Drawing.Point(17, 93);
			this.cbUseDarkMode.Name = "cbUseDarkMode";
			this.cbUseDarkMode.Size = new System.Drawing.Size(101, 17);
			this.cbUseDarkMode.TabIndex = 35;
			this.cbUseDarkMode.Text = "Use Dark Mode";
			this.cbUseDarkMode.UseVisualStyleBackColor = false;
			// 
			// SettingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 366);
			this.Controls.Add(this.groupAppearance);
			this.Controls.Add(this.groupGeneral);
			this.Controls.Add(this.pbBackground);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SettingsWindow";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsWindow_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
			this.groupGeneral.ResumeLayout(false);
			this.groupGeneral.PerformLayout();
			this.groupAppearance.ResumeLayout(false);
			this.groupAppearance.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox pbBackground;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.GroupBox groupGeneral;
		private System.Windows.Forms.GroupBox groupAppearance;
		private System.Windows.Forms.CheckBox cbLiveFilteringMode;
		private System.Windows.Forms.CheckBox cbShowHelperWindowOnStartup;
		private System.Windows.Forms.Button btnChangeFont;
		private System.Windows.Forms.CheckBox cbUseCustomFont;
		private System.Windows.Forms.CheckBox cbShowIconsForEachNode;
		private System.Windows.Forms.CheckBox cbShowFunctionNameInOverloadSignatures;
		private System.Windows.Forms.CheckBox cbShowParameterNamesInOverloadSignatures;
		private System.Windows.Forms.CheckBox cbUseDarkMode;
	}
}