using ExampleUseUnityIOC.Interfaces;

namespace ExampleUseUnityIOC.Entities
{
	public class Fuel : IFuel
	{
		public int GetLevelFuel()
		{
			return 100;
		}
	}
}
