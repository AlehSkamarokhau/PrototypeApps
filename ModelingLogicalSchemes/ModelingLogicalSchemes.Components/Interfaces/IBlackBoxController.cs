using System.Collections.Generic;

using ModelingLogicalSchemes.Components.Common;
using ModelingLogicalSchemes.Components.Entities;
using ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces;

namespace ModelingLogicalSchemes.Components.Interfaces
{
	/// <summary>
	/// Определяет методы для управления чёрным ящиком.
	/// </summary>
	public interface IBlackBoxController
	{
		/// <summary>
		/// Sets the black box.
		/// </summary>
		/// <param name="blackBox">The black box.</param>
		void SetBlackBox(IBlackBox blackBox);

		/// <summary>
		/// Reloads the black box.
		/// </summary>
		void ReloadBlackBox();

		/// <summary>
		/// Sets the configuration to black box.
		/// </summary>
		/// <param name="functionsElements">The functions elements.</param>
		/// <param name="brokenElements">The broken elements.</param>
		void SetConfigurationToBlackBox(IDictionary<int, FunctionTypes> functionsElements, IDictionary<int, BrokenTypes> brokenElements);

		/// <summary>
		/// Gets the output values from black box.
		/// </summary>
		/// <param name="inputValues">The input values.</param>
		/// <returns>The output values.</returns>
		bool[] GetOutputValuesFromBlackBox(params bool[] inputValues);
	}
}
