namespace ModelingLogicalSchemes.UIShell
{
	partial class ShellForm
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
			this.gbBlackBox = new System.Windows.Forms.GroupBox();
			this.gbManage = new System.Windows.Forms.GroupBox();
			this.gbOutput = new System.Windows.Forms.GroupBox();
			this.pictureBlackBox = new System.Windows.Forms.PictureBox();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.gbBlackBox.SuspendLayout();
			this.gbOutput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBlackBox)).BeginInit();
			this.SuspendLayout();
			// 
			// gbBlackBox
			// 
			this.gbBlackBox.Controls.Add(this.pictureBlackBox);
			this.gbBlackBox.Location = new System.Drawing.Point(12, 12);
			this.gbBlackBox.Name = "gbBlackBox";
			this.gbBlackBox.Size = new System.Drawing.Size(679, 415);
			this.gbBlackBox.TabIndex = 0;
			this.gbBlackBox.TabStop = false;
			this.gbBlackBox.Text = "Black Box";
			// 
			// gbManage
			// 
			this.gbManage.Location = new System.Drawing.Point(697, 12);
			this.gbManage.Name = "gbManage";
			this.gbManage.Size = new System.Drawing.Size(351, 591);
			this.gbManage.TabIndex = 1;
			this.gbManage.TabStop = false;
			this.gbManage.Text = "Manage";
			// 
			// gbOutput
			// 
			this.gbOutput.Controls.Add(this.txtOutput);
			this.gbOutput.Location = new System.Drawing.Point(12, 433);
			this.gbOutput.Name = "gbOutput";
			this.gbOutput.Size = new System.Drawing.Size(679, 170);
			this.gbOutput.TabIndex = 2;
			this.gbOutput.TabStop = false;
			this.gbOutput.Text = "Output";
			// 
			// pictureBlackBox
			// 
			this.pictureBlackBox.Image = global::ModelingLogicalSchemes.UIShell.Properties.Resources.SchemeFirstBlackBoxSmall;
			this.pictureBlackBox.Location = new System.Drawing.Point(19, 77);
			this.pictureBlackBox.Name = "pictureBlackBox";
			this.pictureBlackBox.Size = new System.Drawing.Size(638, 253);
			this.pictureBlackBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBlackBox.TabIndex = 0;
			this.pictureBlackBox.TabStop = false;
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(6, 19);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(667, 145);
			this.txtOutput.TabIndex = 0;
			// 
			// ShellForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1060, 615);
			this.Controls.Add(this.gbOutput);
			this.Controls.Add(this.gbManage);
			this.Controls.Add(this.gbBlackBox);
			this.Name = "ShellForm";
			this.Text = "Shell";
			this.gbBlackBox.ResumeLayout(false);
			this.gbOutput.ResumeLayout(false);
			this.gbOutput.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBlackBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbBlackBox;
		private System.Windows.Forms.GroupBox gbManage;
		private System.Windows.Forms.GroupBox gbOutput;
		private System.Windows.Forms.PictureBox pictureBlackBox;
		private System.Windows.Forms.TextBox txtOutput;
	}
}

