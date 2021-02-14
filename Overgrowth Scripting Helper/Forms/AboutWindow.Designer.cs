
namespace Overgrowth_Scripting_Helper
{
	partial class AboutWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
			this.pbBackground = new System.Windows.Forms.PictureBox();
			this.lblPluginName = new System.Windows.Forms.Label();
			this.lblCompiledForOvergrowth = new System.Windows.Forms.Label();
			this.lblProgrammedBy = new System.Windows.Forms.Label();
			this.lblGithubRepository = new System.Windows.Forms.Label();
			this.groupText = new System.Windows.Forms.GroupBox();
			this.lblText = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
			this.groupText.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbBackground
			// 
			this.pbBackground.Image = global::Overgrowth_Scripting_Helper.Properties.Resources.Background;
			this.pbBackground.Location = new System.Drawing.Point(0, 0);
			this.pbBackground.Name = "pbBackground";
			this.pbBackground.Size = new System.Drawing.Size(661, 366);
			this.pbBackground.TabIndex = 8;
			this.pbBackground.TabStop = false;
			// 
			// lblPluginName
			// 
			this.lblPluginName.AutoSize = true;
			this.lblPluginName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPluginName.Location = new System.Drawing.Point(5, 9);
			this.lblPluginName.Name = "lblPluginName";
			this.lblPluginName.Size = new System.Drawing.Size(336, 24);
			this.lblPluginName.TabIndex = 25;
			this.lblPluginName.Text = "Overgrowth Scripting Helper v1.0.0";
			// 
			// lblCompiledForOvergrowth
			// 
			this.lblCompiledForOvergrowth.AutoSize = true;
			this.lblCompiledForOvergrowth.Location = new System.Drawing.Point(15, 40);
			this.lblCompiledForOvergrowth.Name = "lblCompiledForOvergrowth";
			this.lblCompiledForOvergrowth.Size = new System.Drawing.Size(140, 13);
			this.lblCompiledForOvergrowth.TabIndex = 29;
			this.lblCompiledForOvergrowth.Text = "compiled for Overgrowth 0.0";
			// 
			// lblProgrammedBy
			// 
			this.lblProgrammedBy.AutoSize = true;
			this.lblProgrammedBy.Location = new System.Drawing.Point(333, 40);
			this.lblProgrammedBy.Name = "lblProgrammedBy";
			this.lblProgrammedBy.Size = new System.Drawing.Size(115, 13);
			this.lblProgrammedBy.TabIndex = 33;
			this.lblProgrammedBy.Text = "programmed by alpines";
			// 
			// lblGithubRepository
			// 
			this.lblGithubRepository.AutoSize = true;
			this.lblGithubRepository.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblGithubRepository.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGithubRepository.Location = new System.Drawing.Point(355, 55);
			this.lblGithubRepository.Name = "lblGithubRepository";
			this.lblGithubRepository.Size = new System.Drawing.Size(93, 13);
			this.lblGithubRepository.TabIndex = 34;
			this.lblGithubRepository.Text = "GitHub Repository";
			this.lblGithubRepository.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblGithubRepository_MouseClick);
			this.lblGithubRepository.MouseEnter += new System.EventHandler(this.lblGithubRepository_MouseEnter);
			this.lblGithubRepository.MouseLeave += new System.EventHandler(this.lblGithubRepository_MouseLeave);
			// 
			// groupText
			// 
			this.groupText.Controls.Add(this.lblText);
			this.groupText.Location = new System.Drawing.Point(9, 71);
			this.groupText.Name = "groupText";
			this.groupText.Size = new System.Drawing.Size(451, 142);
			this.groupText.TabIndex = 35;
			this.groupText.TabStop = false;
			// 
			// lblText
			// 
			this.lblText.AutoSize = true;
			this.lblText.Location = new System.Drawing.Point(6, 16);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(414, 117);
			this.lblText.TabIndex = 28;
			this.lblText.Text = resources.GetString("lblText.Text");
			// 
			// AboutWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 366);
			this.Controls.Add(this.groupText);
			this.Controls.Add(this.lblGithubRepository);
			this.Controls.Add(this.lblProgrammedBy);
			this.Controls.Add(this.lblCompiledForOvergrowth);
			this.Controls.Add(this.lblPluginName);
			this.Controls.Add(this.pbBackground);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutWindow";
			((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
			this.groupText.ResumeLayout(false);
			this.groupText.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbBackground;
		private System.Windows.Forms.Label lblPluginName;
		private System.Windows.Forms.Label lblCompiledForOvergrowth;
		private System.Windows.Forms.Label lblProgrammedBy;
		private System.Windows.Forms.Label lblGithubRepository;
		private System.Windows.Forms.GroupBox groupText;
		private System.Windows.Forms.Label lblText;
	}
}