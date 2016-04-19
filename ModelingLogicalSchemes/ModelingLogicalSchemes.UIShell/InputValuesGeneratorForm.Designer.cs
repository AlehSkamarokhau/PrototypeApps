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
			this.lblResult = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
			// 
			// lblResult
			// 
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(12, 37);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(37, 13);
			this.lblResult.TabIndex = 3;
			this.lblResult.Text = "Result";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 53);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(626, 367);
			this.dataGridView1.TabIndex = 4;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(281, 426);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(86, 31);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// InputValuesGeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 469);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.txtNumberElementInputs);
			this.Controls.Add(this.lblNumberElementInputs);
			this.Name = "InputValuesGeneratorForm";
			this.Text = "Input Values Generator";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNumberElementInputs;
		private System.Windows.Forms.TextBox txtNumberElementInputs;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnClose;
	}
}