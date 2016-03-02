using Ninject.Modules;

using ModelingLogicalSchemes.Components.Controllers;
using ModelingLogicalSchemes.Components.Interfaces;

using ModelingLogicalSchemes.Components.MagicalBlackBoxes;
using ModelingLogicalSchemes.Components.MagicalBlackBoxes.Interfaces;

namespace ModelingLogicalSchemes.Components.Common.DI.Modules
{
	public class DefaultModule : NinjectModule
	{
		public override void Load()
		{
			//Empty

			//Example
			//	Bind<IApple>().To<Apple>();
			//	Bind<Tree>().ToSelf().InSingletonScope();

			Bind<IBlackBox>().To<FirstBlackBox>().InTransientScope();
			Bind<IBlackBoxController>().To<BlackBoxController>().InTransientScope();
		}
	}
}
