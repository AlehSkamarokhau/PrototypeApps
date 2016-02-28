using System.Collections.Generic;

using ModelingLogicalSchemes.Components.Entities;

namespace ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces
{
	/// <summary>
	/// Интерфейс взаимодействия с чёрным ящиком.
	/// </summary>
	public interface IBlackBox
	{
		/// <summary>
		/// Sets the configuration.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		void SetConfiguration(IDictionary<int, BrokenTypes> configuration);

		/// <summary>
		/// Gets the output value.
		/// </summary>
		/// <param name="inputValues">The input values.</param>
		/// <returns>The output values.</returns>
		bool[] GetOutputValue(params bool[] inputValues);
	}
}
