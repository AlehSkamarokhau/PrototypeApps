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
			this.pictureBlackBox = new System.Windows.Forms.PictureBox();
			this.gbManage = new System.Windows.Forms.GroupBox();
			this.dataGridViewManage = new System.Windows.Forms.DataGridView();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.gbOutput = new System.Windows.Forms.GroupBox();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.gbInputValues = new System.Windows.Forms.GroupBox();
			this.dataGridViewInputValues = new System.Windows.Forms.DataGridView();
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inputValuesGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbBlackBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBlackBox)).BeginInit();
			this.gbManage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewManage)).BeginInit();
			this.gbOutput.SuspendLayout();
			this.gbInputValues.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputValues)).BeginInit();
			this.mainMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbBlackBox
			// 
			this.gbBlackBox.Controls.Add(this.pictureBlackBox);
			this.gbBlackBox.Location = new System.Drawing.Point(12, 28);
			this.gbBlackBox.Name = "gbBlackBox";
			this.gbBlackBox.Size = new System.Drawing.Size(679, 310);
			this.gbBlackBox.TabIndex = 0;
			this.gbBlackBox.TabStop = false;
			this.gbBlackBox.Text = "Black Box";
			// 
			// pictureBlackBox
			// 
			this.pictureBlackBox.Image = global::ModelingLogicalSchemes.UIShell.Properties.Resources.SchemeFirstBlackBoxSmall;
			this.pictureBlackBox.Location = new System.Drawing.Point(21, 30);
			this.pictureBlackBox.Name = "pictureBlackBox";
			this.pictureBlackBox.Size = new System.Drawing.Size(638, 253);
			this.pictureBlackBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBlackBox.TabIndex = 0;
			this.pictureBlackBox.TabStop = false;
			// 
			// gbManage
			// 
			this.gbManage.Controls.Add(this.dataGridViewManage);
			this.gbManage.Location = new System.Drawing.Point(697, 28);
			this.gbManage.Name = "gbManage";
			this.gbManage.Size = new System.Drawing.Size(418, 255);
			this.gbManage.TabIndex = 1;
			this.gbManage.TabStop = false;
			this.gbManage.Text = "Manage";
			// 
			// dataGridViewManage
			// 
			this.dataGridViewManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewManage.Location = new System.Drawing.Point(6, 19);
			this.dataGridViewManage.Name = "dataGridViewManage";
			this.dataGridViewManage.Size = new System.Drawing.Size(406, 221);
			this.dataGridViewManage.TabIndex = 0;
			this.dataGridViewManage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManage_CellValueChanged);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(204, 279);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(127, 36);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(71, 279);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(127, 36);
			this.btnRun.TabIndex = 2;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// gbOutput
			// 
			this.gbOutput.Controls.Add(this.txtOutput);
			this.gbOutput.Location = new System.Drawing.Point(12, 344);
			this.gbOutput.Name = "gbOutput";
			this.gbOutput.Size = new System.Drawing.Size(679, 275);
			this.gbOutput.TabIndex = 2;
			this.gbOutput.TabStop = false;
			this.gbOutput.Text = "Output";
			// 
			// txtOutput
			// 
			this.txtOutput.BackColor = System.Drawing.SystemColors.Info;
			this.txtOutput.Location = new System.Drawing.Point(6, 19);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(667, 250);
			this.txtOutput.TabIndex = 0;
			// 
			// gbInputValues
			// 
			this.gbInputValues.Controls.Add(this.dataGridViewInputValues);
			this.gbInputValues.Controls.Add(this.btnExit);
			this.gbInputValues.Controls.Add(this.btnRun);
			this.gbInputValues.Location = new System.Drawing.Point(697, 289);
			this.gbInputValues.Name = "gbInputValues";
			this.gbInputValues.Size = new System.Drawing.Size(418, 330);
			this.gbInputValues.TabIndex = 3;
			this.gbInputValues.TabStop = false;
			this.gbInputValues.Text = "Input Values";
			// 
			// dataGridViewInputValues
			// 
			this.dataGridViewInputValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewInputValues.Location = new System.Drawing.Point(6, 19);
			this.dataGridViewInputValues.Name = "dataGridViewInputValues";
			this.dataGridViewInputValues.Size = new System.Drawing.Size(406, 254);
			this.dataGridViewInputValues.TabIndex = 4;
			this.dataGridViewInputValues.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInputValues_CellValueChanged);
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(1127, 24);
			this.mainMenuStrip.TabIndex = 4;
			this.mainMenuStrip.Text = "menuStrip1";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputValuesGeneratorToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// inputValuesGeneratorToolStripMenuItem
			// 
			this.inputValuesGeneratorToolStripMenuItem.Name = "inputValuesGeneratorToolStripMenuItem";
			this.inputValuesGeneratorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.inputValuesGeneratorToolStripMenuItem.Text = "Input Values Generator";
			this.inputValuesGeneratorToolStripMenuItem.Click += new System.EventHandler(this.inputValuesGeneratorToolStripMenuItem_Click);
			// 
			// ShellForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1127, 630);
			this.Controls.Add(this.gbInputValues);
			this.Controls.Add(this.gbOutput);
			this.Controls.Add(this.gbManage);
			this.Controls.Add(this.gbBlackBox);
			this.Controls.Add(this.mainMenuStrip);
			this.MainMenuStrip = this.mainMenuStrip;
			this.MaximumSize = new System.Drawing.Size(1143, 668);
			this.MinimumSize = new System.Drawing.Size(1143, 668);
			this.Name = "ShellForm";
			this.Text = "Shell";
			this.gbBlackBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBlackBox)).EndInit();
			this.gbManage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewManage)).EndInit();
			this.gbOutput.ResumeLayout(false);
			this.gbOutput.PerformLayout();
			this.gbInputValues.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputValues)).EndInit();
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbBlackBox;
		private System.Windows.Forms.GroupBox gbManage;
		private System.Windows.Forms.GroupBox gbOutput;
		private System.Windows.Forms.PictureBox pictureBlackBox;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.GroupBox gbInputValues;
		private System.Windows.Forms.DataGridView dataGridViewManage;
		private System.Windows.Forms.DataGridView dataGridViewInputValues;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inputValuesGeneratorToolStripMenuItem;
	}
}

