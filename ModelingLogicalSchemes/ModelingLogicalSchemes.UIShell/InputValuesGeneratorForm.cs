using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelingLogicalSchemes.Components.Helpers;

namespace ModelingLogicalSchemes.UIShell
{
	public partial class InputValuesGeneratorForm : Form
	{
		private void InitializeDataGridViewResult(int countInputs)
		{
			dataGridViewResult.Rows.Clear();
			dataGridViewResult.Columns.Clear();

			dataGridViewResult.AllowUserToAddRows = false;

			for (int i = 1; i <= countInputs; i++)
			{
				dataGridViewResult.Columns.Add(i.ToString(), i.ToString());
				dataGridViewResult.Columns[-1 + i].ReadOnly = true;
			}
		}

		private IList<int[]> ConvertToIntCollection(IList<bool[]> boolCollection)
		{
			IList<int[]> result = new List<int[]>();

			foreach (bool[] item in boolCollection)
			{
				int[] currentItemResult = new int[item.Length];

				for (int i = 0; i < item.Length; i++)
				{
					if (item[i])
					{
						currentItemResult[i] = 1;
					}
					else
					{
						currentItemResult[i] = 0;
					}
				}

				result.Add(currentItemResult);
			}

			return result;
		}

		public InputValuesGeneratorForm()
		{
			InitializeComponent();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			InitializeDataGridViewResult(int.Parse(txtNumberElementInputs.Text));
			IList<int[]> inputValues = ConvertToIntCollection(InputValuesHelper.GetFullCollectionInputValues(int.Parse(txtNumberElementInputs.Text)));

			for (int i = 0; i < inputValues.Count; i++)
			{
				int[] temp = inputValues[i];

				dataGridViewResult.Rows.Add();

				for (int j = 0; j < temp.Length; j++)
				{
					dataGridViewResult.Rows[i].Cells[j].Value = temp[j];
				}
			}
		}
	}
}
