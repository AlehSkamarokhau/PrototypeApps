using Ninject.Modules;

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
		}
	}
}
