using System;
using System.Collections.Generic;

using ModelingLogicalSchemes.Components.Common;
using ModelingLogicalSchemes.Components.Entities;

using ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces;

namespace ModelingLogicalSchemes.Components.MagicalBlackBoxes
{
	/// <summary>
	/// Реализует работу схемы для первого варианта.
	/// </summary>
	/// <seealso cref="ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces.IBlackBox" />
	public sealed class FirstBlackBox : IBlackBox
	{
		#region Constants

		private const int COUNT_INPUT_VALUES = 5;

		private const int COUNT_OUTPUT_VALUES = 8;

		private const int COUNT_ELEMENTS = 8;

		#endregion

		#region Private Fields

		private bool[] _inputValues;

		private bool[] _outputValues;

		private IDictionary<int, FunctionTypes> _configurationFunctions;

		private IDictionary<int, BrokenTypes> _configurationBrokenTypes;

		private LogicalElement[] _elements;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the count input values.
		/// </summary>
		/// <value>
		/// The count input values.
		/// </value>
		public int CountInputValues
		{
			get
			{
				return COUNT_INPUT_VALUES;
			}
		}

		/// <summary>
		/// Gets the count output values.
		/// </summary>
		/// <value>
		/// The count output values.
		/// </value>
		public int CountOutputValues
		{
			get
			{
				return COUNT_OUTPUT_VALUES;
			}
		}

		/// <summary>
		/// Gets the count elements.
		/// </summary>
		/// <value>
		/// The count elements.
		/// </value>
		public int CountElements
		{
			get
			{
				return COUNT_ELEMENTS;
			}
		}

		/// <summary>
		/// Gets the configuration functions.
		/// </summary>
		/// <value>
		/// The configuration functions.
		/// </value>
		/// <exception cref="ArgumentNullException">value</exception>
		public IDictionary<int, FunctionTypes> ConfigurationFunctions
		{
			get
			{
				return _configurationFunctions;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_configurationFunctions = value;
			}
		}

		/// <summary>
		/// Gets the configuration broken types.
		/// </summary>
		/// <value>
		/// The configuration broken types.
		/// </value>
		/// <exception cref="ArgumentNullException">value</exception>
		public IDictionary<int, BrokenTypes> ConfigurationBrokenTypes
		{
			get
			{
				return _configurationBrokenTypes;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_configurationBrokenTypes = value;
			}
		}

		#endregion

		#region Private Members

		private void Initialize()
		{
			_inputValues = new bool[COUNT_INPUT_VALUES];
			_outputValues = new bool[COUNT_OUTPUT_VALUES];
			_elements = new LogicalElement[COUNT_ELEMENTS];
		}

		private LogicalElement[] GetConfiguredLogicalElements(IDictionary<int, FunctionTypes> configurationFunctions,
															  IDictionary<int, BrokenTypes> configurationBrokenTypes)
		{
			if (configurationFunctions.Count == 0)
			{
				throw new ArgumentException("configurationFunctions is empty");
			}

			if (configurationBrokenTypes.Count == 0)
			{
				throw new ArgumentException("configurationBrokenTypes is empty");
			}

			LogicalElement[] elements = new LogicalElement[COUNT_ELEMENTS];

			for (int i = 0; i < elements.Length; i++)
			{
				elements[i] = LogicalElementBuilder.Build(1 + i, configurationFunctions[1 + i], configurationBrokenTypes[1 + i]);
			}

			_elements = elements;

			return elements;
		}

		#endregion

		#region Constructors

		public FirstBlackBox()
		{
			Initialize();
		}

		#endregion

		#region Public Interface

		#region IBlackBox Members

		/// <summary>
		/// Gets the current values of inputs.
		/// </summary>
		/// <returns>
		/// The current values of the inputs.
		/// </returns>
		public bool[] GetCurrentValuesOfInputs()
		{
			return _inputValues;
		}

		/// <summary>
		/// Gets the current values of outputs.
		/// </summary>
		/// <returns>
		/// The current values of the outputs.
		/// </returns>
		public bool[] GetCurrentValuesOfOutputs()
		{
			return _outputValues;
		}

		/// <summary>
		/// Sets the configuration.
		/// </summary>
		/// <param name="configurationFunctions">The configuration functions.</param>
		/// <param name="configurationBrokenTypes">The configuration broken types.</param>
		public void SetConfiguration(IDictionary<int, FunctionTypes> configurationFunctions, IDictionary<int, BrokenTypes> configurationBrokenTypes)
		{
			ConfigurationFunctions = configurationFunctions;
			ConfigurationBrokenTypes = configurationBrokenTypes;
		}

		/// <summary>
		/// Gets the output value.
		/// </summary>
		/// <param name="inputValues">The input values.</param>
		/// <returns>
		/// The output values.
		/// </returns>
		/// <exception cref="ArgumentNullException">inputValues</exception>
		/// <exception cref="ArgumentException">length inputValues is not equal COUNT_INPUT_VALUES</exception>
		public bool[] GetOutputValue(params bool[] inputValues)
		{
			if (inputValues == null)
			{
				throw new ArgumentNullException("inputValues");
			}

			if (inputValues.Length != COUNT_INPUT_VALUES)
			{
				throw new ArgumentException("length inputValues is not equal COUNT_INPUT_VALUES");
			}

			_elements = GetConfiguredLogicalElements(_configurationFunctions, _configurationBrokenTypes);

			_inputValues = inputValues;

			//TODO: Убрать китайский код.
			_outputValues[0] = _elements[0].GetOutputValue(inputValues[1], inputValues[2], inputValues[3]);
			_outputValues[1] = _elements[1].GetOutputValue(inputValues[3], inputValues[4]);
			_outputValues[2] = _elements[2].GetOutputValue(_outputValues[1]);
			_outputValues[3] = _elements[3].GetOutputValue(_outputValues[0], _outputValues[1]);
			_outputValues[4] = _elements[4].GetOutputValue(inputValues[0], _outputValues[3]);
			_outputValues[5] = _elements[5].GetOutputValue(inputValues[0], _outputValues[3]);
			_outputValues[6] = _elements[6].GetOutputValue(_outputValues[5], _outputValues[2]);
			_outputValues[7] = _elements[7].GetOutputValue(_outputValues[4], _outputValues[6]);

			return new bool[] { _outputValues[COUNT_ELEMENTS] };
		}

		#endregion

		#endregion
	}
}
