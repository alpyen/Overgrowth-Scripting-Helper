namespace Overgrowth__
{
    partial class HelperWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.tabScriptTypes = new System.Windows.Forms.TabControl();
            this.tabCharacter = new System.Windows.Forms.TabPage();
            this.tvCharacter = new System.Windows.Forms.TreeView();
            this.tabLevel = new System.Windows.Forms.TabPage();
            this.tvLevel = new System.Windows.Forms.TreeView();
            this.tabHotspot = new System.Windows.Forms.TabPage();
            this.tvHotspot = new System.Windows.Forms.TreeView();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.tvCamera = new System.Windows.Forms.TreeView();
            this.tabScriptableCampaign = new System.Windows.Forms.TabPage();
            this.tvScriptableCampaign = new System.Windows.Forms.TreeView();
            this.tabScriptableUI = new System.Windows.Forms.TabPage();
            this.tvScriptableUI = new System.Windows.Forms.TreeView();
            this.tabScriptTypes.SuspendLayout();
            this.tabCharacter.SuspendLayout();
            this.tabLevel.SuspendLayout();
            this.tabHotspot.SuspendLayout();
            this.tabCamera.SuspendLayout();
            this.tabScriptableCampaign.SuspendLayout();
            this.tabScriptableUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter:";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(52, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(293, 20);
            this.tbFilter.TabIndex = 4;
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            // 
            // tabScriptTypes
            // 
            this.tabScriptTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabScriptTypes.Controls.Add(this.tabCharacter);
            this.tabScriptTypes.Controls.Add(this.tabLevel);
            this.tabScriptTypes.Controls.Add(this.tabHotspot);
            this.tabScriptTypes.Controls.Add(this.tabCamera);
            this.tabScriptTypes.Controls.Add(this.tabScriptableCampaign);
            this.tabScriptTypes.Controls.Add(this.tabScriptableUI);
            this.tabScriptTypes.Location = new System.Drawing.Point(0, 41);
            this.tabScriptTypes.Name = "tabScriptTypes";
            this.tabScriptTypes.SelectedIndex = 0;
            this.tabScriptTypes.Size = new System.Drawing.Size(359, 679);
            this.tabScriptTypes.TabIndex = 5;
            // 
            // tabCharacter
            // 
            this.tabCharacter.Controls.Add(this.tvCharacter);
            this.tabCharacter.Location = new System.Drawing.Point(4, 22);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tabCharacter.Size = new System.Drawing.Size(351, 653);
            this.tabCharacter.TabIndex = 0;
            this.tabCharacter.Text = "Character";
            this.tabCharacter.UseVisualStyleBackColor = true;
            // 
            // tvCharacter
            // 
            this.tvCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCharacter.Location = new System.Drawing.Point(3, 3);
            this.tvCharacter.Name = "tvCharacter";
            this.tvCharacter.Size = new System.Drawing.Size(345, 647);
            this.tvCharacter.TabIndex = 1;
            // 
            // tabLevel
            // 
            this.tabLevel.Controls.Add(this.tvLevel);
            this.tabLevel.Location = new System.Drawing.Point(4, 22);
            this.tabLevel.Name = "tabLevel";
            this.tabLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tabLevel.Size = new System.Drawing.Size(351, 653);
            this.tabLevel.TabIndex = 1;
            this.tabLevel.Text = "Level";
            this.tabLevel.UseVisualStyleBackColor = true;
            // 
            // tvLevel
            // 
            this.tvLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLevel.Location = new System.Drawing.Point(3, 3);
            this.tvLevel.Name = "tvLevel";
            this.tvLevel.Size = new System.Drawing.Size(345, 647);
            this.tvLevel.TabIndex = 2;
            // 
            // tabHotspot
            // 
            this.tabHotspot.Controls.Add(this.tvHotspot);
            this.tabHotspot.Location = new System.Drawing.Point(4, 22);
            this.tabHotspot.Name = "tabHotspot";
            this.tabHotspot.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotspot.Size = new System.Drawing.Size(351, 653);
            this.tabHotspot.TabIndex = 2;
            this.tabHotspot.Text = "Hotspot";
            this.tabHotspot.UseVisualStyleBackColor = true;
            // 
            // tvHotspot
            // 
            this.tvHotspot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHotspot.Location = new System.Drawing.Point(3, 3);
            this.tvHotspot.Name = "tvHotspot";
            this.tvHotspot.Size = new System.Drawing.Size(345, 647);
            this.tvHotspot.TabIndex = 2;
            // 
            // tabCamera
            // 
            this.tabCamera.Controls.Add(this.tvCamera);
            this.tabCamera.Location = new System.Drawing.Point(4, 22);
            this.tabCamera.Name = "tabCamera";
            this.tabCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabCamera.Size = new System.Drawing.Size(351, 653);
            this.tabCamera.TabIndex = 5;
            this.tabCamera.Text = "Camera";
            this.tabCamera.UseVisualStyleBackColor = true;
            // 
            // tvCamera
            // 
            this.tvCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCamera.Location = new System.Drawing.Point(3, 3);
            this.tvCamera.Name = "tvCamera";
            this.tvCamera.Size = new System.Drawing.Size(345, 647);
            this.tvCamera.TabIndex = 3;
            // 
            // tabScriptableCampaign
            // 
            this.tabScriptableCampaign.Controls.Add(this.tvScriptableCampaign);
            this.tabScriptableCampaign.Location = new System.Drawing.Point(4, 22);
            this.tabScriptableCampaign.Name = "tabScriptableCampaign";
            this.tabScriptableCampaign.Padding = new System.Windows.Forms.Padding(3);
            this.tabScriptableCampaign.Size = new System.Drawing.Size(351, 653);
            this.tabScriptableCampaign.TabIndex = 3;
            this.tabScriptableCampaign.Text = "Scriptable Campaign";
            this.tabScriptableCampaign.UseVisualStyleBackColor = true;
            // 
            // tvScriptableCampaign
            // 
            this.tvScriptableCampaign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvScriptableCampaign.Location = new System.Drawing.Point(3, 3);
            this.tvScriptableCampaign.Name = "tvScriptableCampaign";
            this.tvScriptableCampaign.Size = new System.Drawing.Size(345, 647);
            this.tvScriptableCampaign.TabIndex = 2;
            // 
            // tabScriptableUI
            // 
            this.tabScriptableUI.Controls.Add(this.tvScriptableUI);
            this.tabScriptableUI.Location = new System.Drawing.Point(4, 22);
            this.tabScriptableUI.Name = "tabScriptableUI";
            this.tabScriptableUI.Padding = new System.Windows.Forms.Padding(3);
            this.tabScriptableUI.Size = new System.Drawing.Size(351, 653);
            this.tabScriptableUI.TabIndex = 4;
            this.tabScriptableUI.Text = "Scriptable UI";
            this.tabScriptableUI.UseVisualStyleBackColor = true;
            // 
            // tvScriptableUI
            // 
            this.tvScriptableUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvScriptableUI.Location = new System.Drawing.Point(3, 3);
            this.tvScriptableUI.Name = "tvScriptableUI";
            this.tvScriptableUI.Size = new System.Drawing.Size(345, 647);
            this.tvScriptableUI.TabIndex = 3;
            // 
            // HelperWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 718);
            this.Controls.Add(this.tabScriptTypes);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.label2);
            this.Name = "HelperWindow";
            this.Text = "Overgrowth Scripting Helper";
            this.tabScriptTypes.ResumeLayout(false);
            this.tabCharacter.ResumeLayout(false);
            this.tabLevel.ResumeLayout(false);
            this.tabHotspot.ResumeLayout(false);
            this.tabCamera.ResumeLayout(false);
            this.tabScriptableCampaign.ResumeLayout(false);
            this.tabScriptableUI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.TabControl tabScriptTypes;
        private System.Windows.Forms.TabPage tabCharacter;
        private System.Windows.Forms.TreeView tvCharacter;
        private System.Windows.Forms.TabPage tabLevel;
        private System.Windows.Forms.TabPage tabHotspot;
        private System.Windows.Forms.TabPage tabScriptableCampaign;
        private System.Windows.Forms.TreeView tvLevel;
        private System.Windows.Forms.TreeView tvHotspot;
        private System.Windows.Forms.TreeView tvScriptableCampaign;
        private System.Windows.Forms.TabPage tabScriptableUI;
        private System.Windows.Forms.TreeView tvScriptableUI;
        private System.Windows.Forms.TabPage tabCamera;
        private System.Windows.Forms.TreeView tvCamera;
    }
}