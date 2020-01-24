namespace Overgrowth__

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
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.groupAppearance = new System.Windows.Forms.GroupBox();
            this.cbShowIconsForEachNode = new System.Windows.Forms.CheckBox();
            this.cbUseCustomFont = new System.Windows.Forms.CheckBox();
            this.cbShowBackgroundImage = new System.Windows.Forms.CheckBox();
            this.btnChangeFont = new System.Windows.Forms.Button();
            this.cbShowParameterNamesInFunctionSignatures = new System.Windows.Forms.CheckBox();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.cbMatchParameterTypes = new System.Windows.Forms.CheckBox();
            this.cbMatchParameterNames = new System.Windows.Forms.CheckBox();
            this.cbMatchFunctionNames = new System.Windows.Forms.CheckBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblHorizontalLine = new System.Windows.Forms.Label();
            this.groupGeneral = new System.Windows.Forms.GroupBox();
            this.cbShowHelperWindowOnStartup = new System.Windows.Forms.CheckBox();
            this.cbLiveFilteringMode = new System.Windows.Forms.CheckBox();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.groupAppearance.SuspendLayout();
            this.groupFilter.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAppearance
            // 
            this.groupAppearance.Controls.Add(this.cbShowIconsForEachNode);
            this.groupAppearance.Controls.Add(this.cbUseCustomFont);
            this.groupAppearance.Controls.Add(this.cbShowBackgroundImage);
            this.groupAppearance.Controls.Add(this.btnChangeFont);
            this.groupAppearance.Controls.Add(this.cbShowParameterNamesInFunctionSignatures);
            this.groupAppearance.Location = new System.Drawing.Point(12, 217);
            this.groupAppearance.Name = "groupAppearance";
            this.groupAppearance.Size = new System.Drawing.Size(368, 120);
            this.groupAppearance.TabIndex = 4;
            this.groupAppearance.TabStop = false;
            this.groupAppearance.Text = "Appearance (requires restart of N++)";
            // 
            // cbShowIconsForEachNode
            // 
            this.cbShowIconsForEachNode.AutoSize = true;
            this.cbShowIconsForEachNode.Checked = true;
            this.cbShowIconsForEachNode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowIconsForEachNode.ForeColor = System.Drawing.Color.White;
            this.cbShowIconsForEachNode.Location = new System.Drawing.Point(19, 69);
            this.cbShowIconsForEachNode.Name = "cbShowIconsForEachNode";
            this.cbShowIconsForEachNode.Size = new System.Drawing.Size(150, 17);
            this.cbShowIconsForEachNode.TabIndex = 5;
            this.cbShowIconsForEachNode.Text = "Show icons for each node";
            this.cbShowIconsForEachNode.UseVisualStyleBackColor = true;
            this.cbShowIconsForEachNode.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbUseCustomFont
            // 
            this.cbUseCustomFont.AutoSize = true;
            this.cbUseCustomFont.ForeColor = System.Drawing.Color.White;
            this.cbUseCustomFont.Location = new System.Drawing.Point(19, 92);
            this.cbUseCustomFont.Name = "cbUseCustomFont";
            this.cbUseCustomFont.Size = new System.Drawing.Size(107, 17);
            this.cbUseCustomFont.TabIndex = 4;
            this.cbUseCustomFont.Text = "Use Custom Font";
            this.cbUseCustomFont.UseVisualStyleBackColor = true;
            this.cbUseCustomFont.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbShowBackgroundImage
            // 
            this.cbShowBackgroundImage.AutoSize = true;
            this.cbShowBackgroundImage.Checked = true;
            this.cbShowBackgroundImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowBackgroundImage.ForeColor = System.Drawing.Color.White;
            this.cbShowBackgroundImage.Location = new System.Drawing.Point(19, 46);
            this.cbShowBackgroundImage.Name = "cbShowBackgroundImage";
            this.cbShowBackgroundImage.Size = new System.Drawing.Size(144, 17);
            this.cbShowBackgroundImage.TabIndex = 3;
            this.cbShowBackgroundImage.Text = "Show background image";
            this.cbShowBackgroundImage.UseVisualStyleBackColor = true;
            this.cbShowBackgroundImage.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Location = new System.Drawing.Point(265, 88);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(97, 23);
            this.btnChangeFont.TabIndex = 2;
            this.btnChangeFont.Text = "Change Font";
            this.btnChangeFont.UseVisualStyleBackColor = true;
            this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
            // 
            // cbShowParameterNamesInFunctionSignatures
            // 
            this.cbShowParameterNamesInFunctionSignatures.AutoSize = true;
            this.cbShowParameterNamesInFunctionSignatures.ForeColor = System.Drawing.Color.White;
            this.cbShowParameterNamesInFunctionSignatures.Location = new System.Drawing.Point(19, 23);
            this.cbShowParameterNamesInFunctionSignatures.Name = "cbShowParameterNamesInFunctionSignatures";
            this.cbShowParameterNamesInFunctionSignatures.Size = new System.Drawing.Size(240, 17);
            this.cbShowParameterNamesInFunctionSignatures.TabIndex = 0;
            this.cbShowParameterNamesInFunctionSignatures.Text = "Show parameter names in function signatures";
            this.cbShowParameterNamesInFunctionSignatures.UseVisualStyleBackColor = true;
            this.cbShowParameterNamesInFunctionSignatures.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.cbMatchParameterTypes);
            this.groupFilter.Controls.Add(this.cbMatchParameterNames);
            this.groupFilter.Controls.Add(this.cbMatchFunctionNames);
            this.groupFilter.Location = new System.Drawing.Point(12, 104);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(368, 107);
            this.groupFilter.TabIndex = 5;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Filter";
            // 
            // cbMatchParameterTypes
            // 
            this.cbMatchParameterTypes.AutoSize = true;
            this.cbMatchParameterTypes.Location = new System.Drawing.Point(19, 75);
            this.cbMatchParameterTypes.Name = "cbMatchParameterTypes";
            this.cbMatchParameterTypes.Size = new System.Drawing.Size(134, 17);
            this.cbMatchParameterTypes.TabIndex = 2;
            this.cbMatchParameterTypes.Text = "Match parameter types";
            this.cbMatchParameterTypes.UseVisualStyleBackColor = true;
            this.cbMatchParameterTypes.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbMatchParameterNames
            // 
            this.cbMatchParameterNames.AutoSize = true;
            this.cbMatchParameterNames.Location = new System.Drawing.Point(19, 52);
            this.cbMatchParameterNames.Name = "cbMatchParameterNames";
            this.cbMatchParameterNames.Size = new System.Drawing.Size(140, 17);
            this.cbMatchParameterNames.TabIndex = 1;
            this.cbMatchParameterNames.Text = "Match parameter names";
            this.cbMatchParameterNames.UseVisualStyleBackColor = true;
            this.cbMatchParameterNames.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbMatchFunctionNames
            // 
            this.cbMatchFunctionNames.AutoSize = true;
            this.cbMatchFunctionNames.Checked = true;
            this.cbMatchFunctionNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMatchFunctionNames.Enabled = false;
            this.cbMatchFunctionNames.Location = new System.Drawing.Point(19, 29);
            this.cbMatchFunctionNames.Name = "cbMatchFunctionNames";
            this.cbMatchFunctionNames.Size = new System.Drawing.Size(131, 17);
            this.cbMatchFunctionNames.TabIndex = 0;
            this.cbMatchFunctionNames.Text = "Match function names";
            this.cbMatchFunctionNames.UseVisualStyleBackColor = true;
            this.cbMatchFunctionNames.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.White;
            this.lblAbout.Location = new System.Drawing.Point(441, 344);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(203, 13);
            this.lblAbout.TabIndex = 6;
            this.lblAbout.Text = "programmed by alpines - www.ag.systems";
            // 
            // lblHorizontalLine
            // 
            this.lblHorizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHorizontalLine.ForeColor = System.Drawing.Color.White;
            this.lblHorizontalLine.Location = new System.Drawing.Point(14, 351);
            this.lblHorizontalLine.Name = "lblHorizontalLine";
            this.lblHorizontalLine.Size = new System.Drawing.Size(422, 2);
            this.lblHorizontalLine.TabIndex = 7;
            // 
            // groupGeneral
            // 
            this.groupGeneral.Controls.Add(this.cbShowHelperWindowOnStartup);
            this.groupGeneral.Controls.Add(this.cbLiveFilteringMode);
            this.groupGeneral.Location = new System.Drawing.Point(12, 12);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.Size = new System.Drawing.Size(368, 86);
            this.groupGeneral.TabIndex = 8;
            this.groupGeneral.TabStop = false;
            this.groupGeneral.Text = "General";
            // 
            // cbShowHelperWindowOnStartup
            // 
            this.cbShowHelperWindowOnStartup.AutoSize = true;
            this.cbShowHelperWindowOnStartup.Location = new System.Drawing.Point(19, 29);
            this.cbShowHelperWindowOnStartup.Name = "cbShowHelperWindowOnStartup";
            this.cbShowHelperWindowOnStartup.Size = new System.Drawing.Size(211, 17);
            this.cbShowHelperWindowOnStartup.TabIndex = 1;
            this.cbShowHelperWindowOnStartup.Text = "Show helper sidebar window on startup";
            this.cbShowHelperWindowOnStartup.UseVisualStyleBackColor = true;
            this.cbShowHelperWindowOnStartup.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // cbLiveFilteringMode
            // 
            this.cbLiveFilteringMode.AutoSize = true;
            this.cbLiveFilteringMode.Location = new System.Drawing.Point(19, 52);
            this.cbLiveFilteringMode.Name = "cbLiveFilteringMode";
            this.cbLiveFilteringMode.Size = new System.Drawing.Size(277, 17);
            this.cbLiveFilteringMode.TabIndex = 0;
            this.cbLiveFilteringMode.Text = "Live filtering mode (warning: very performance heavy)";
            this.cbLiveFilteringMode.UseVisualStyleBackColor = true;
            this.cbLiveFilteringMode.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // pbBackground
            // 
            this.pbBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackground.Image = global::Overgrowth__.Properties.Resources.background;
            this.pbBackground.ImageLocation = "";
            this.pbBackground.InitialImage = null;
            this.pbBackground.Location = new System.Drawing.Point(0, 0);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(661, 366);
            this.pbBackground.TabIndex = 3;
            this.pbBackground.TabStop = false;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 366);
            this.Controls.Add(this.groupGeneral);
            this.Controls.Add(this.lblHorizontalLine);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.groupFilter);
            this.Controls.Add(this.groupAppearance);
            this.Controls.Add(this.pbBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Overgrowth++ Settings";
            this.groupAppearance.ResumeLayout(false);
            this.groupAppearance.PerformLayout();
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.GroupBox groupAppearance;
        private System.Windows.Forms.Button btnChangeFont;
        private System.Windows.Forms.CheckBox cbShowParameterNamesInFunctionSignatures;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.CheckBox cbMatchParameterTypes;
        private System.Windows.Forms.CheckBox cbMatchParameterNames;
        private System.Windows.Forms.CheckBox cbMatchFunctionNames;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblHorizontalLine;
        private System.Windows.Forms.CheckBox cbShowBackgroundImage;
        private System.Windows.Forms.GroupBox groupGeneral;
        private System.Windows.Forms.CheckBox cbLiveFilteringMode;
        private System.Windows.Forms.CheckBox cbUseCustomFont;
        private System.Windows.Forms.CheckBox cbShowIconsForEachNode;
        private System.Windows.Forms.CheckBox cbShowHelperWindowOnStartup;
    }
}