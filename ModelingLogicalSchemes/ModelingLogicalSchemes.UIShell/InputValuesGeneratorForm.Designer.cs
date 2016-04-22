namespace ModelingLogicalSchemes.UIShell
{
	partial class InputValuesGeneratorForm
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
			this.lblNumberElementInputs = new System.Windows.Forms.Label();
			this.txtNumberElementInputs = new System.Windows.Forms.TextBox();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.lblResults = new System.Windows.Forms.Label();
			this.dataGridViewResult = new System.Windows.Forms.DataGridView();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblGenerateMode = new System.Windows.Forms.Label();
			this.cmbBoxGenerateMode = new System.Windows.Forms.ComboBox();
			this.btnRunTestScheme = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
			this.SuspendLayout();
			// 
			// lblNumberElementInputs
			// 
			this.lblNumberElementInputs.AutoSize = true;
			this.lblNumberElementInputs.Location = new System.Drawing.Point(12, 9);
			this.lblNumberElementInputs.Name = "lblNumberElementInputs";
			this.lblNumberElementInputs.Size = new System.Drawing.Size(132, 13);
			this.lblNumberElementInputs.TabIndex = 0;
			this.lblNumberElementInputs.Text = "Number of Element Inputs:";
			// 
			// txtNumberElementInputs
			// 
			this.txtNumberElementInputs.Location = new System.Drawing.Point(147, 6);
			this.txtNumberElementInputs.Name = "txtNumberElementInputs";
			this.txtNumberElementInputs.Size = new System.Drawing.Size(100, 20);
			this.txtNumberElementInputs.TabIndex = 1;
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(253, 4);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 2;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// lblResults
			// 
			this.lblResults.AutoSize = true;
			this.lblResults.Location = new System.Drawing.Point(12, 66);
			this.lblResults.Name = "lblResults";
			this.lblResults.Size = new System.Drawing.Size(42, 13);
			this.lblResults.TabIndex = 3;
			this.lblResults.Text = "Results";
			// 
			// dataGridViewResult
			// 
			this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewResult.Location = new System.Drawing.Point(12, 82);
			this.dataGridViewResult.Name = "dataGridViewResult";
			this.dataGridViewResult.Size = new System.Drawing.Size(626, 495);
			this.dataGridViewResult.TabIndex = 4;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(313, 583);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(114, 31);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// lblGenerateMode
			// 
			this.lblGenerateMode.AutoSize = true;
			this.lblGenerateMode.Location = new System.Drawing.Point(57, 38);
			this.lblGenerateMode.Name = "lblGenerateMode";
			this.lblGenerateMode.Size = new System.Drawing.Size(84, 13);
			this.lblGenerateMode.TabIndex = 6;
			this.lblGenerateMode.Text = "Generate Mode:";
			// 
			// cmbBoxGenerateMode
			// 
			this.cmbBoxGenerateMode.FormattingEnabled = true;
			this.cmbBoxGenerateMode.Location = new System.Drawing.Point(147, 35);
			this.cmbBoxGenerateMode.Name = "cmbBoxGenerateMode";
			this.cmbBoxGenerateMode.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxGenerateMode.TabIndex = 7;
			// 
			// btnRunTestScheme
			// 
			this.btnRunTestScheme.Location = new System.Drawing.Point(193, 583);
			this.btnRunTestScheme.Name = "btnRunTestScheme";
			this.btnRunTestScheme.Size = new System.Drawing.Size(114, 31);
			this.btnRunTestScheme.TabIndex = 8;
			this.btnRunTestScheme.Text = "Run Test Scheme";
			this.btnRunTestScheme.UseVisualStyleBackColor = true;
			// 
			// InputValuesGeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 626);
			this.Controls.Add(this.btnRunTestScheme);
			this.Controls.Add(this.cmbBoxGenerateMode);
			this.Controls.Add(this.lblGenerateMode);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.dataGridViewResult);
			this.Controls.Add(this.lblResults);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.txtNumberElementInputs);
			this.Controls.Add(this.lblNumberElementInputs);
			this.Name = "InputValuesGeneratorForm";
			this.Text = "Input Values Generator";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNumberElementInputs;
		private System.Windows.Forms.TextBox txtNumberElementInputs;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label lblResults;
		private System.Windows.Forms.DataGridView dataGridViewResult;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblGenerateMode;
		private System.Windows.Forms.ComboBox cmbBoxGenerateMode;
		private System.Windows.Forms.Button btnRunTestScheme;
	}
}