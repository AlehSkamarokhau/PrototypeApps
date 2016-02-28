namespace ExampleUseUnityIOC.Interfaces
{
	public interface ICar
	{
		IEngine Engine { get; set; }

		IFuel Fuel { get; set; }

		IDriver Driver { get; set; }
	}
}
