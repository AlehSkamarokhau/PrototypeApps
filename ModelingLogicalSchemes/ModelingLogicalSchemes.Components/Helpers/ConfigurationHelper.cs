using System;
using System.Configuration;

namespace ModelingLogicalSchemes.Components.Helpers
{
	/// <summary>
	/// Вспомогательный класс для чтения данных из конфигурационного файла.
	/// </summary>
	public static class ConfigurationHelper
	{
		//TODO: Добавить ключ MaskForLoadNinjectKernelModulesDlls в конфигурационный файл.
		private const string KEY_MASK_FOR_LOAD_NINJECT_KERNEL_MODULES_DLLS = "MaskForLoadNinjectKernelModulesDlls";

		private const string DEFAULT_MASK_FOR_LOAD_NINJECT_KERNEL_MODULES_DLLS = "ModelingLogicalSchemes.Components*.dll";

		/// <summary>
		/// Gets the mask for load ninject kernel modules DLLS.
		/// </summary>
		/// <returns>The file name mask.</returns>
		public static string GetMaskForLoadNinjectKernelModulesDlls()
		{
			string maskForLoadNinjectKernelModules = null;

			try
			{
				maskForLoadNinjectKernelModules = ConfigurationManager.AppSettings[KEY_MASK_FOR_LOAD_NINJECT_KERNEL_MODULES_DLLS];
			}
			catch (ConfigurationErrorsException ex)
			{
				//TODO: Add loging exception.
			}

			if (String.IsNullOrWhiteSpace(maskForLoadNinjectKernelModules))
			{
				return DEFAULT_MASK_FOR_LOAD_NINJECT_KERNEL_MODULES_DLLS;
			}

			return maskForLoadNinjectKernelModules;
		}
	}
}
