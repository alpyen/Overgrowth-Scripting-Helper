
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
			this.lblProgrammedBy = new System.Windows.Forms.Label();
			this.lblGithubRepository = new System.Windows.Forms.Label();
			this.btnChangeFont = new System.Windows.Forms.Button();
			this.cbUseCustomFont = new System.Windows.Forms.CheckBox();
			this.cbShowIconsForEachNode = new System.Windows.Forms.CheckBox();
			this.cbLiveFilteringMode = new System.Windows.Forms.CheckBox();
			this.cbShowHelperWindowOnStartup = new System.Windows.Forms.CheckBox();
			this.lblPluginName = new System.Windows.Forms.Label();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.cbShowFunctionNameInOverloadSignatures = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
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
			// lblProgrammedBy
			// 
			this.lblProgrammedBy.AutoSize = true;
			this.lblProgrammedBy.ForeColor = System.Drawing.Color.White;
			this.lblProgrammedBy.Location = new System.Drawing.Point(488, 344);
			this.lblProgrammedBy.Name = "lblProgrammedBy";
			this.lblProgrammedBy.Size = new System.Drawing.Size(115, 13);
			this.lblProgrammedBy.TabIndex = 21;
			this.lblProgrammedBy.Text = "programmed by alpines";
			// 
			// lblGithubRepository
			// 
			this.lblGithubRepository.AutoSize = true;
			this.lblGithubRepository.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblGithubRepository.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGithubRepository.ForeColor = System.Drawing.Color.White;
			this.lblGithubRepository.Location = new System.Drawing.Point(13, 311);
			this.lblGithubRepository.Name = "lblGithubRepository";
			this.lblGithubRepository.Size = new System.Drawing.Size(93, 13);
			this.lblGithubRepository.TabIndex = 20;
			this.lblGithubRepository.Text = "GitHub Repository";
			this.lblGithubRepository.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblGithubRepository_MouseClick);
			this.lblGithubRepository.MouseEnter += new System.EventHandler(this.lblGithubRepository_MouseEnter);
			this.lblGithubRepository.MouseLeave += new System.EventHandler(this.lblGithubRepository_MouseLeave);
			// 
			// btnChangeFont
			// 
			this.btnChangeFont.Location = new System.Drawing.Point(25, 140);
			this.btnChangeFont.Name = "btnChangeFont";
			this.btnChangeFont.Size = new System.Drawing.Size(86, 23);
			this.btnChangeFont.TabIndex = 19;
			this.btnChangeFont.Text = "Change Font";
			this.btnChangeFont.UseVisualStyleBackColor = true;
			this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
			// 
			// cbUseCustomFont
			// 
			this.cbUseCustomFont.AutoSize = true;
			this.cbUseCustomFont.Location = new System.Drawing.Point(25, 117);
			this.cbUseCustomFont.Name = "cbUseCustomFont";
			this.cbUseCustomFont.Size = new System.Drawing.Size(107, 17);
			this.cbUseCustomFont.TabIndex = 18;
			this.cbUseCustomFont.Text = "Use Custom Font";
			this.cbUseCustomFont.UseVisualStyleBackColor = false;
			this.cbUseCustomFont.CheckedChanged += new System.EventHandler(this.cbUseCustomFont_CheckedChanged);
			// 
			// cbShowIconsForEachNode
			// 
			this.cbShowIconsForEachNode.AutoSize = true;
			this.cbShowIconsForEachNode.Location = new System.Drawing.Point(25, 94);
			this.cbShowIconsForEachNode.Name = "cbShowIconsForEachNode";
			this.cbShowIconsForEachNode.Size = new System.Drawing.Size(284, 17);
			this.cbShowIconsForEachNode.TabIndex = 17;
			this.cbShowIconsForEachNode.Text = "Show icons for each node (requires Notepad++ restart)";
			this.cbShowIconsForEachNode.UseVisualStyleBackColor = false;
			// 
			// cbLiveFilteringMode
			// 
			this.cbLiveFilteringMode.AutoSize = true;
			this.cbLiveFilteringMode.Location = new System.Drawing.Point(25, 48);
			this.cbLiveFilteringMode.Name = "cbLiveFilteringMode";
			this.cbLiveFilteringMode.Size = new System.Drawing.Size(277, 17);
			this.cbLiveFilteringMode.TabIndex = 16;
			this.cbLiveFilteringMode.Text = "Live filtering mode (warning: very performance heavy)";
			this.cbLiveFilteringMode.UseVisualStyleBackColor = false;
			// 
			// cbShowHelperWindowOnStartup
			// 
			this.cbShowHelperWindowOnStartup.AutoSize = true;
			this.cbShowHelperWindowOnStartup.Location = new System.Drawing.Point(25, 25);
			this.cbShowHelperWindowOnStartup.Name = "cbShowHelperWindowOnStartup";
			this.cbShowHelperWindowOnStartup.Size = new System.Drawing.Size(211, 17);
			this.cbShowHelperWindowOnStartup.TabIndex = 15;
			this.cbShowHelperWindowOnStartup.Text = "Show helper sidebar window on startup";
			this.cbShowHelperWindowOnStartup.UseVisualStyleBackColor = false;
			// 
			// lblPluginName
			// 
			this.lblPluginName.AutoSize = true;
			this.lblPluginName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPluginName.ForeColor = System.Drawing.Color.White;
			this.lblPluginName.Location = new System.Drawing.Point(12, 333);
			this.lblPluginName.Name = "lblPluginName";
			this.lblPluginName.Size = new System.Drawing.Size(336, 24);
			this.lblPluginName.TabIndex = 22;
			this.lblPluginName.Text = "Overgrowth Scripting Helper v1.0.0";
			// 
			// cbShowFunctionNameInOverloadSignatures
			// 
			this.cbShowFunctionNameInOverloadSignatures.AutoSize = true;
			this.cbShowFunctionNameInOverloadSignatures.Location = new System.Drawing.Point(25, 71);
			this.cbShowFunctionNameInOverloadSignatures.Name = "cbShowFunctionNameInOverloadSignatures";
			this.cbShowFunctionNameInOverloadSignatures.Size = new System.Drawing.Size(368, 17);
			this.cbShowFunctionNameInOverloadSignatures.TabIndex = 23;
			this.cbShowFunctionNameInOverloadSignatures.Text = "Show function names in overload signatures (requires Notepad++ restart)";
			this.cbShowFunctionNameInOverloadSignatures.UseVisualStyleBackColor = true;
			// 
			// SettingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 366);
			this.Controls.Add(this.cbShowFunctionNameInOverloadSignatures);
			this.Controls.Add(this.lblPluginName);
			this.Controls.Add(this.lblProgrammedBy);
			this.Controls.Add(this.lblGithubRepository);
			this.Controls.Add(this.btnChangeFont);
			this.Controls.Add(this.cbUseCustomFont);
			this.Controls.Add(this.cbShowIconsForEachNode);
			this.Controls.Add(this.cbLiveFilteringMode);
			this.Controls.Add(this.cbShowHelperWindowOnStartup);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pbBackground;
		private System.Windows.Forms.Label lblProgrammedBy;
		private System.Windows.Forms.Label lblGithubRepository;
		private System.Windows.Forms.Button btnChangeFont;
		private System.Windows.Forms.CheckBox cbUseCustomFont;
		private System.Windows.Forms.CheckBox cbShowIconsForEachNode;
		private System.Windows.Forms.CheckBox cbLiveFilteringMode;
		private System.Windows.Forms.CheckBox cbShowHelperWindowOnStartup;
		private System.Windows.Forms.Label lblPluginName;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.CheckBox cbShowFunctionNameInOverloadSignatures;
	}
}