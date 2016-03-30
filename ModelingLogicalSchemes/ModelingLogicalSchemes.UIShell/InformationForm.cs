using System;
using System.Windows.Forms;

namespace ModelingLogicalSchemes.UIShell
{
	public partial class InformationForm : Form
	{
		public InformationForm()
		{
			InitializeComponent();
		}

		public void ShowInformation(string info)
		{
			if (String.IsNullOrWhiteSpace(info))
			{
				throw new ArgumentException("info");
			}

			txtInfo.Text = info;

			Show();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Sorry. This feature is not supported.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
