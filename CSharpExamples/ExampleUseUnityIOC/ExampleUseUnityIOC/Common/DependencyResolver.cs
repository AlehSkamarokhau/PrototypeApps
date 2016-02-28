using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ExampleUseUnityIOC.Common
{
	public static class DependencyResolver
	{
		public static IUnityContainer GetContainer()
		{
			IUnityContainer container = new UnityContainer();
			container.LoadConfiguration();
			return container;
		}
	}
}
