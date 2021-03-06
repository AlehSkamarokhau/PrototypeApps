﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using ModelingLogicalSchemes.Components.Common.DI;
using ModelingLogicalSchemes.Components.Helpers;
using ModelingLogicalSchemes.Components.Interfaces;

namespace ModelingLogicalSchemes.UIShell
{
	public partial class InputValuesGeneratorForm : Form
	{
		#region Constants

		private const string GENERATE_MODE_NONE = "None";

		private const string GENERATE_MODE_MINIMAL_COMPLEXITY = "Minimal Complexity";

		private const string GENERATE_MODE_MINIMAL_TIME = "Minimal Time";

		#endregion

		#region Private Fields

		private ShellForm _shellForm;

		private IBlackBoxController _blackBoxController;

		#endregion

		#region Private Members

		private ShellForm ShellForm
		{
			get
			{
				return _shellForm;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("ShellForm");
				}

				_shellForm = value;
			}
		}

		private IBlackBoxController BlackBoxController
		{
			get
			{
				if (_blackBoxController == null)
				{
					_blackBoxController = DependencyResolver.Resolve<IBlackBoxController>();
				}

				return _blackBoxController;
			}
		}

		private void InitializeDataGridViewResult(int countInputs, int countOutputs)
		{
			dataGridViewResult.Rows.Clear();
			dataGridViewResult.Columns.Clear();

			dataGridViewResult.AllowUserToAddRows = false;

			for (int i = 1; i <= countInputs; i++)
			{
				dataGridViewResult.Columns.Add(i.ToString(), i.ToString());
				dataGridViewResult.Columns[-1 + i].ReadOnly = true;
			}

			for (int i = 1; i <= countOutputs; i++)
			{
				dataGridViewResult.Columns.Add(String.Format("Output #{0}", i), String.Format("Output #{0}", i));
				dataGridViewResult.Columns[-1 + i].ReadOnly = true;
			}
		}

		private void SetToDataGridViewResult(IDictionary<bool[], bool[]> results)
		{
			InitializeDataGridViewResult(results.First().Key.Length, results.First().Value.Length);
			dataGridViewResult.Rows.Clear();

			List<int[]> result = new List<int[]>();

			foreach (KeyValuePair<bool[], bool[]> item in results)
			{
				int[] currentRes = new int[item.Key.Length + item.Value.Length];

				for (int i = 0; i < item.Key.Length; i++)
				{
					if (item.Key[i])
					{
						currentRes[i] = 1;
					}
					else
					{
						currentRes[i] = 0;
					}
				}

				for (int i = 0; i < item.Value.Length; i++)
				{
					if (item.Value[i])
					{
						currentRes[item.Key.Length + i] = 1;
					}
					else
					{
						currentRes[item.Key.Length + i] = 0;
					}
				}

				result.Add(currentRes);
			}

			for (int i = 0; i < result.Count; i++)
			{
				dataGridViewResult.Rows.Add();

				for (int j = 0; j < result[i].Length; j++)
				{
					dataGridViewResult.Rows[i].Cells[j].Value = result[i][j];
				}
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

		private int GetCountValuesInCollection(bool[] values, ICollection<bool[]> collection)
		{
			int count = 0;

			foreach (bool[] item in collection)
			{
				if (item.SequenceEqual(values))
				{
					count++;
				}
			}

			return count;
		}

		#endregion

		#region Constructor

		public InputValuesGeneratorForm(ShellForm shellForm)
		{
			InitializeComponent();

			ShellForm = shellForm;

			txtNumberElementInputs.Text = ShellForm.GetInputValuesFromDataGridViewInputValues().Length.ToString();
			txtNumberElementInputs.Enabled = false;

			cmbBoxGenerateMode.Items.Add(GENERATE_MODE_NONE);
			cmbBoxGenerateMode.Items.Add(GENERATE_MODE_MINIMAL_COMPLEXITY);
			cmbBoxGenerateMode.Items.Add(GENERATE_MODE_MINIMAL_TIME);

			cmbBoxGenerateMode.Text = GENERATE_MODE_MINIMAL_COMPLEXITY;
			cmbBoxGenerateMode.Enabled = false;
		}

		#endregion

		#region Events Handlers

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			if (cmbBoxGenerateMode.Text == GENERATE_MODE_MINIMAL_COMPLEXITY)
			{
				IList<bool[]> inputValues = InputValuesHelper.GetFullCollectionInputValues(int.Parse(txtNumberElementInputs.Text));

				BlackBoxController.SetConfigurationToBlackBox(ShellForm.GetCurrentFunctionElementsConfiguration(), ShellForm.GetCurrentBrokenElementsConfiguration());

				IDictionary<bool[], bool[]> rawResults = new Dictionary<bool[], bool[]>();

				foreach (bool[] currentInputValues in inputValues)
				{
					rawResults.Add(currentInputValues, BlackBoxController.GetOutputValuesFromBlackBox(currentInputValues));
				}

				IDictionary<bool[], bool[]> result = new Dictionary<bool[], bool[]>();

				foreach (KeyValuePair<bool[], bool[]> currentRawResult in rawResults)
				{
					if (GetCountValuesInCollection(currentRawResult.Value, result.Values) == 0)
					{
						result.Add(currentRawResult);
					}
				}

				SetToDataGridViewResult(result);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void btnRunTestScheme_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Sorry. This feature is not supported.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion
	}
}
