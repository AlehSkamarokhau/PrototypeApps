using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ModelingLogicalSchemes.Components.Common;
using ModelingLogicalSchemes.Components.Common.DI;

using ModelingLogicalSchemes.Components.Entities;

using ModelingLogicalSchemes.Components.Interfaces;

namespace ModelingLogicalSchemes.UIShell
{
	public partial class ShellForm : Form
	{
		#region Constants

		private const int COUNT_LOGICAL_ELEMENTS = 8;


		private const string NUM_ELEMENT_COLUMN_HEADER_TEXT = "Num. El.";

		private const string FUNCTION_TYPE_COLUMN_HEADER_TEXT = "Function";

		private const string BROKEN_TYPE_COLUMN_HEADER_TEXT = "Broken Type";


		private const string NUM_INPUT_COLUMN_HEADER_TEXT = "Num. Input.";

		private const string INPUT_VALUE_COLUMN_HEADER_TEXT = "Input Value";

		#endregion

		#region Private Fields

		private IBlackBoxController _blackBoxController;

		private IDictionary<int, FunctionTypes> _functionConfiguration;

		private IDictionary<int, BrokenTypes> _brokenConfiguration;

		private int[] _inputValues;

		private int[] _outputValues;

		#endregion

		#region Private Properties

		private IBlackBoxController BlackBoxController
		{
			get
			{
				return _blackBoxController;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_blackBoxController = value;
			}
		}

		private IDictionary<int, FunctionTypes> FunctionConfiguration
		{
			get
			{
				return _functionConfiguration;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_functionConfiguration = value;
			}
		}

		private IDictionary<int, BrokenTypes> BrokenConfiguration
		{
			get
			{
				return _brokenConfiguration;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_brokenConfiguration = value;
			}
		}

		private int[] InputValues
		{
			get
			{
				return _inputValues;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_inputValues = value;
			}
		}

		private int[] OutputValues
		{
			get
			{
				return _outputValues;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_outputValues = value;
			}
		}

		#endregion

		#region Private Members

		#region Initialize

		private void Initialize()
		{
			BlackBoxController = DependencyResolver.Resolve<IBlackBoxController>();
		}

		private void InitializeDataGridViewManage()
		{
			dataGridViewManage.Columns.Clear();
			dataGridViewManage.Rows.Clear();

			dataGridViewManage.AllowUserToAddRows = false;

			dataGridViewManage.Columns.Add("NumElement", NUM_ELEMENT_COLUMN_HEADER_TEXT);
			dataGridViewManage.Columns[0].ReadOnly = true;

			DataGridViewComboBoxColumn functionTypeColumn = new DataGridViewComboBoxColumn();
			functionTypeColumn.Name = FUNCTION_TYPE_COLUMN_HEADER_TEXT;
			functionTypeColumn.DataSource = Enum.GetValues(typeof(FunctionTypes));
			functionTypeColumn.ValueType = typeof(FunctionTypes);

			dataGridViewManage.Columns.Add(functionTypeColumn);

			DataGridViewComboBoxColumn brokenTypeColumn = new DataGridViewComboBoxColumn();
			brokenTypeColumn.Name = BROKEN_TYPE_COLUMN_HEADER_TEXT;
			brokenTypeColumn.DataSource = Enum.GetValues(typeof(BrokenTypes));
			brokenTypeColumn.ValueType = typeof(BrokenTypes);

			dataGridViewManage.Columns.Add(brokenTypeColumn);
		}

		private void InitializeDataGridViewInputValues()
		{
			dataGridViewInputValues.Columns.Clear();
			dataGridViewInputValues.Rows.Clear();

			dataGridViewInputValues.AllowUserToAddRows = false;

			dataGridViewInputValues.Columns.Add("NumInput", NUM_INPUT_COLUMN_HEADER_TEXT);
			dataGridViewInputValues.Columns[0].ReadOnly = false;

			DataGridViewComboBoxColumn inputValuesColumn = new DataGridViewComboBoxColumn();
			inputValuesColumn.Name = INPUT_VALUE_COLUMN_HEADER_TEXT;
			inputValuesColumn.DataSource = new int[] { 0, 1 };
			inputValuesColumn.ValueType = typeof(int);

			dataGridViewInputValues.Columns.Add(inputValuesColumn);
		}

		#endregion

		#region Elements Configuration

		private IDictionary<int, FunctionTypes> GetFunctionElementsConfiguration()
		{
			Dictionary<int, FunctionTypes> functionElementsConfiguration = new Dictionary<int, FunctionTypes>(8);

			functionElementsConfiguration.Add(1, FunctionTypes.AND);
			functionElementsConfiguration.Add(2, FunctionTypes.NXOR);
			functionElementsConfiguration.Add(3, FunctionTypes.NOT);
			functionElementsConfiguration.Add(4, FunctionTypes.OR);
			functionElementsConfiguration.Add(5, FunctionTypes.AND);
			functionElementsConfiguration.Add(6, FunctionTypes.NOR);
			functionElementsConfiguration.Add(7, FunctionTypes.AND);
			functionElementsConfiguration.Add(8, FunctionTypes.OR);

			return functionElementsConfiguration;
		}

		private IDictionary<int, BrokenTypes> GetBrokenElementsConfiguration()
		{
			Dictionary<int, BrokenTypes> brokenElementsConfiguration = new Dictionary<int, BrokenTypes>(8);

			brokenElementsConfiguration.Add(1, BrokenTypes.Non);
			brokenElementsConfiguration.Add(2, BrokenTypes.Non);
			brokenElementsConfiguration.Add(3, BrokenTypes.Non);
			brokenElementsConfiguration.Add(4, BrokenTypes.Non);
			brokenElementsConfiguration.Add(5, BrokenTypes.Non);
			brokenElementsConfiguration.Add(6, BrokenTypes.Non);
			brokenElementsConfiguration.Add(7, BrokenTypes.Non);
			brokenElementsConfiguration.Add(8, BrokenTypes.Non);

			return brokenElementsConfiguration;
		}

		public IDictionary<int, FunctionTypes> GetCurrentFunctionElementsConfiguration()
		{
			IDictionary<int, FunctionTypes> result = new Dictionary<int, FunctionTypes>();

			foreach (DataGridViewRow currentRow in dataGridViewManage.Rows)
			{
				result.Add((int)currentRow.Cells[0].Value, (FunctionTypes)currentRow.Cells[1].Value);
			}

			FunctionConfiguration = result;

			return result;
		}

		public IDictionary<int, BrokenTypes> GetCurrentBrokenElementsConfiguration()
		{
			IDictionary<int, BrokenTypes> result = new Dictionary<int, BrokenTypes>();

			foreach (DataGridViewRow currentRow in dataGridViewManage.Rows)
			{
				result.Add((int)currentRow.Cells[0].Value, (BrokenTypes)currentRow.Cells[2].Value);
			}

			BrokenConfiguration = result;

			return result;
		}

		private void SetToDataGridViewManage(IDictionary<int, FunctionTypes> functionConfiguration,
									 IDictionary<int, BrokenTypes> brokenConfiguration)
		{
			dataGridViewManage.Rows.Clear();

			foreach (int currentFunctionConfigKey in functionConfiguration.Keys)
			{
				dataGridViewManage.Rows.Add(currentFunctionConfigKey,
											functionConfiguration[currentFunctionConfigKey],
											brokenConfiguration[currentFunctionConfigKey]);
			}
		}

		#endregion

		#region Input Values

		private int[] GetInitializeInputValues()
		{
			int[] firstInputValues = new int[] { 1, 1, 1, 1, 1 };
			return firstInputValues;
		}

		public bool[] GetInputValuesFromDataGridViewInputValues()
		{
			int[] rawResult = new int[GetInitializeInputValues().Length];

			for (int i = 0; i < rawResult.Length; i++)
			{
				rawResult[i] = (int)dataGridViewInputValues.Rows[i].Cells[1].Value;
			}

			InputValues = rawResult;

			return ConvertValuesToBool(rawResult);
		}

		private void SetToDataGridViewInputValues(int[] inputValues)
		{
			dataGridViewInputValues.Rows.Clear();

			for (int i = 0; i < inputValues.Length; i++)
			{
				dataGridViewInputValues.Rows.Add((1 + i), inputValues[i]);
			}
		}

		#endregion

		#region Converting Input Values

		private bool[] ConvertValuesToBool(int[] values)
		{
			bool[] boolValues = new bool[values.Length];

			for (int i = 0; i < values.Length; i++)
			{
				if (values[i] == 1)
				{
					boolValues[i] = true;
				}
				else if (values[i] == 0)
				{
					boolValues[i] = false;
				}
			}

			return boolValues;
		}

		private int[] ConvertValuesToInt(bool[] values)
		{
			int[] intValues = new int[values.Length];

			for (int i = 0; i < values.Length; i++)
			{
				if (values[i])
				{
					intValues[i] = 1;
				}
				else
				{
					intValues[i] = 0;
				}
			}

			return intValues;
		}

		#endregion

		#region Print To Output

		private void PrintToOutputDictionaryConfiguration<TValue>(IDictionary<int, TValue> configuration, string nameConfiguration)
		{
			StringBuilder buildOutput = new StringBuilder();

			buildOutput.AppendFormat("Read {0}:{1}{1}", nameConfiguration, Environment.NewLine);

			for (int i = 1; i <= configuration.Keys.Count; i++)
			{
				buildOutput.AppendFormat("Num. El.: {0}; {1}: {2};{3}{3}", i, nameConfiguration, configuration[i].ToString(), Environment.NewLine);
			}

			txtOutput.Text += buildOutput.ToString();
		}

		private void PrintToOutputInputValues(int[] inputValues)
		{
			StringBuilder buildOutput = new StringBuilder();

			buildOutput.AppendFormat("Input Values: {0}{0}", Environment.NewLine);

			for (int i = 0; i < inputValues.Length; i++)
			{
				buildOutput.AppendFormat("Num. Input: {0}; Value: {1};{2}{2}", 1 + i, inputValues[i], Environment.NewLine);
			}

			txtOutput.Text += buildOutput.ToString();
		}

		#endregion

		private string GetInformationalMsgWithOutputValues(params int[] outputValues)
		{
			StringBuilder strBuild = new StringBuilder();

			strBuild.Append("Values On Outputs of Elements\r\n");
			strBuild.AppendLine();

			int[] valsOnOutputs = ConvertValuesToInt(BlackBoxController.GetCurrentValuesOfOutputsFromBlackBox());

			for (int i = 0; i < valsOnOutputs.Length; i++)
			{
				strBuild.AppendFormat("#{0} = {1}\r\n", 1 + i, valsOnOutputs[i]);
			}

			strBuild.AppendLine();

			strBuild.Append("Output Values\r\n");
			strBuild.AppendLine();

			for (int i = 0; i < outputValues.Length; i++)
			{
				strBuild.AppendFormat("#{0} = {1}\r\n", 1 + i, outputValues[i]);
			}

			strBuild.AppendLine();

			return strBuild.ToString();
		}

		#endregion

		#region Constructors

		public ShellForm()
		{
			InitializeComponent();

			Initialize();
			InitializeDataGridViewManage();
			InitializeDataGridViewInputValues();

			FunctionConfiguration = GetFunctionElementsConfiguration();
			BrokenConfiguration = GetBrokenElementsConfiguration();
			InputValues = GetInitializeInputValues();

			PrintToOutputDictionaryConfiguration<FunctionTypes>(FunctionConfiguration, "Function");
			PrintToOutputDictionaryConfiguration<BrokenTypes>(BrokenConfiguration, "Broken");
			PrintToOutputInputValues(InputValues);

			SetToDataGridViewManage(FunctionConfiguration, BrokenConfiguration);
			SetToDataGridViewInputValues(InputValues);
		}

		#endregion

		#region Form Events Handlers

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
			Dispose();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			BlackBoxController.SetConfigurationToBlackBox(FunctionConfiguration, BrokenConfiguration);

			OutputValues = ConvertValuesToInt(BlackBoxController.GetOutputValuesFromBlackBox(GetInputValuesFromDataGridViewInputValues()));

			string infoMsgOutputVals = GetInformationalMsgWithOutputValues(OutputValues);
			txtOutput.Text += String.Format("\r\n {0} \r\n", infoMsgOutputVals);

			InformationForm infoFrm = new InformationForm();
			infoFrm.ShowInformation(infoMsgOutputVals);
		}

		private void dataGridViewManage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			BlackBoxController.SetConfigurationToBlackBox(GetCurrentFunctionElementsConfiguration(), GetCurrentBrokenElementsConfiguration());

			if (dataGridViewManage.Columns[e.ColumnIndex].Name == BROKEN_TYPE_COLUMN_HEADER_TEXT)
			{
				if ((BrokenTypes)dataGridViewManage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != BrokenTypes.Non)
				{
					dataGridViewManage.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
				}
				else
				{
					dataGridViewManage.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
				}
			}
		}

		private void dataGridViewInputValues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			InputValues = ConvertValuesToInt(GetInputValuesFromDataGridViewInputValues());
		}

		private void inputValuesGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InputValuesGeneratorForm valGeneratorFrm = new InputValuesGeneratorForm(this);
			valGeneratorFrm.Show();
		}

		#endregion
	}
}
