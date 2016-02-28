using System;

using Ninject;

using ModelingLogicalSchemes.Components.Helpers;

namespace ModelingLogicalSchemes.Components.Common.DI
{
	/// <summary>
	/// Вспомогательный класс для разрешения зависимостей.
	/// </summary>
	public static class DependencyResolver
	{
		#region Private Fields

		private static IKernel _kernel;

		#endregion

		#region Private Members

		private static IKernel Kernel
		{
			get
			{
				if (_kernel == null)
				{
					Initialize();
				}

				return _kernel;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_kernel = value;
			}
		}

		private static void Initialize()
		{
			_kernel = new StandardKernel();
			_kernel.Load(ConfigurationHelper.GetMaskForLoadNinjectKernelModulesDlls());
		}

		#endregion

		#region Static Constructor

		static DependencyResolver()
		{
			Initialize();
		}

		#endregion

		#region Public Interface

		/// <summary>
		/// Resolves this instance.
		/// </summary>
		/// <typeparam name="T">Type of service instance.</typeparam>
		/// <returns>The instance.</returns>
		public static T Resolve<T>()
		{
			try
			{
				T instance = Kernel.Get<T>();
				return instance;
			}
			catch (ActivationException ex)
			{
				//TODO: Add logging.
			}

			return default(T);
		}

		#endregion
	}
}
