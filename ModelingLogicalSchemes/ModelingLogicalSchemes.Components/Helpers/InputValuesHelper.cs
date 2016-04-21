using System;
using System.Collections.Generic;
using System.Text;

namespace ModelingLogicalSchemes.Components.Helpers
{
	/// <summary>
	/// Вспомогательный класс для работы с наборами входных значений.
	/// </summary>
	public static class InputValuesHelper
	{
		#region Constants

		private const string SIGNAL_ON = "1";

		private const string SIGNAL_OFF = "0";

		#endregion

		#region Private Members

		private static string GetMaxInputBinValue(int countInputSymbols)
		{
			StringBuilder buildMaxInputValue = new StringBuilder();

			for (int i = 0; i < countInputSymbols; i++)
			{
				buildMaxInputValue.Append(SIGNAL_ON);
			}

			return buildMaxInputValue.ToString();
		}

		private static List<string> GetRawGeneratedInputValues(int maxInputValue, int countInputSymbols)
		{
			List<string> generatedRawValues = new List<string>();

			for (int i = 1; i <= maxInputValue; i++)
			{
				string rawVal = Convert.ToString(i, 2);

				if (rawVal.Length < countInputSymbols)
				{
					int countLostSymbols = countInputSymbols - rawVal.Length;

					StringBuilder buildRawVal = new StringBuilder();

					for (int j = 0; j < countLostSymbols; j++)
					{
						buildRawVal.Append(SIGNAL_OFF);
					}

					buildRawVal.Append(rawVal);

					generatedRawValues.Add(buildRawVal.ToString());
				}
				else
				{
					generatedRawValues.Add(rawVal);
				}
			}

			return generatedRawValues;
		}

		private static List<bool[]> GetInputValuesFromRawGeneratedValues(List<string> rawGeneratedValues)
		{
			List<bool[]> inputValues = new List<bool[]>();

			foreach (string currentRawInputValue in rawGeneratedValues)
			{
				char[] rawInputSymbols = currentRawInputValue.ToCharArray();
				bool[] inputSymbols = new bool[rawInputSymbols.Length];

				for (int i = 0; i < rawInputSymbols.Length; i++)
				{
					if (rawInputSymbols[i] == '0')
					{
						inputSymbols[i] = false;
					}
					else if (rawInputSymbols[i] == '1')
					{
						inputSymbols[i] = true;
					}
				}

				inputValues.Add(inputSymbols);
			}

			return inputValues;
		}

		#endregion

		#region Public Interface

		/// <summary>
		/// Gets the full collection input values.
		/// </summary>
		/// <param name="countInputSymbols">The count input symbols.</param>
		/// <returns>The collection input values.</returns>
		public static IList<bool[]> GetFullCollectionInputValues(int countInputSymbols)
		{
			List<bool[]> inputValuesCollection = new List<bool[]>();

			int maxInputValue = Convert.ToInt32(GetMaxInputBinValue(countInputSymbols).ToString(), 2);

			List<string> rawValues = GetRawGeneratedInputValues(maxInputValue, countInputSymbols);

			return GetInputValuesFromRawGeneratedValues(rawValues);
		}

		#endregion
	}
}
