using System;
using System.Collections.Generic;

using ModelingLogicalSchemes.Components.Common.DI;
using ModelingLogicalSchemes.Components.Interfaces;
using ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces;

namespace ModelingLogicalSchemes.Components.Controllers
{
	/// <summary>
	/// Класс управляющий чёрным ящиком.
	/// </summary>
	/// <seealso cref="ModelingLogicalSchemes.Components.Interfaces.IBlackBoxController" />
	public class BlackBoxController : IBlackBoxController
	{
		#region Private Fields

		private IBlackBox _blackBox;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the black box.
		/// </summary>
		/// <value>
		/// The black box.
		/// </value>
		public IBlackBox BlackBox
		{
			get
			{
				return _blackBox;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BlackBoxController"/> class.
		/// </summary>
		/// <param name="blackBox">The black box.</param>
		/// <exception cref="System.ArgumentNullException">blackBox</exception>
		public BlackBoxController(IBlackBox blackBox)
		{
			if (blackBox == null)
			{
				throw new ArgumentNullException("blackBox");
			}

			_blackBox = blackBox;
		}

		#endregion

		#region Public Interface

		#region IBlackBoxController

		/// <summary>
		/// Sets the black box.
		/// </summary>
		/// <param name="blackBox">The black box.</param>
		/// <exception cref="System.ArgumentNullException">blackBox</exception>
		public void SetBlackBox(IBlackBox blackBox)
		{
			if (blackBox == null)
			{
				throw new ArgumentNullException("blackBox");
			}

			_blackBox = blackBox;
		}

		/// <summary>
		/// Reloads the black box.
		/// </summary>
		public void ReloadBlackBox()
		{
			_blackBox = DependencyResolver.Resolve<IBlackBox>();
		}

		/// <summary>
		/// Sets the configuration to black box.
		/// </summary>
		/// <param name="functionsElements">The functions elements.</param>
		/// <param name="brokenElements">The broken elements.</param>
		/// <exception cref="System.ArgumentNullException">
		/// functionsElements
		/// or
		/// brokenElements
		/// </exception>
		public void SetConfigurationToBlackBox(IDictionary<int, Common.FunctionTypes> functionsElements, IDictionary<int, Entities.BrokenTypes> brokenElements)
		{
			if (functionsElements == null)
			{
				throw new ArgumentNullException("functionsElements");
			}

			if (brokenElements == null)
			{
				throw new ArgumentNullException("brokenElements");
			}

			_blackBox.SetConfiguration(functionsElements, brokenElements);
		}

		/// <summary>
		/// Gets the output values from black box.
		/// </summary>
		/// <param name="inputValues">The input values.</param>
		/// <returns>The output values.</returns>
		/// <exception cref="System.ArgumentNullException">inputValues</exception>
		public bool[] GetOutputValuesFromBlackBox(params bool[] inputValues)
		{
			if (inputValues == null)
			{
				throw new ArgumentNullException("inputValues");
			}

			return _blackBox.GetOutputValue(inputValues);
		}

		#endregion

		#endregion
	}
}
