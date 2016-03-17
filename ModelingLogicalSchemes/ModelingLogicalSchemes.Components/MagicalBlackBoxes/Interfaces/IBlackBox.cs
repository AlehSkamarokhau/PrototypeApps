using System.Collections.Generic;

using ModelingLogicalSchemes.Components.Common;
using ModelingLogicalSchemes.Components.Entities;

namespace ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces
{
	/// <summary>
	/// Интерфейс взаимодействия с чёрным ящиком.
	/// </summary>
	public interface IBlackBox
	{
		/// <summary>
		/// Gets the current values of inputs.
		/// </summary>
		/// <returns>The current values of the inputs.</returns>
		bool[] GetCurrentValuesOfInputs();

		/// <summary>
		/// Gets the current values of outputs.
		/// </summary>
		/// <returns>The current values of the outputs.</returns>
		bool[] GetCurrentValuesOfOutputs();

		/// <summary>
		/// Sets the configuration.
		/// </summary>
		/// <param name="configurationFunctions">The configuration functions.</param>
		/// <param name="configurationBrokenTypes">The configuration broken types.</param>
		void SetConfiguration(IDictionary<int, FunctionTypes> configurationFunctions, IDictionary<int, BrokenTypes> configurationBrokenTypes);

		/// <summary>
		/// Gets the output value.
		/// </summary>
		/// <param name="inputValues">The input values.</param>
		/// <returns>The output values.</returns>
		bool[] GetOutputValue(params bool[] inputValues);
	}
}
