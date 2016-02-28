using System;

using ExampleUseUnityIOC.Common;
using ExampleUseUnityIOC.Interfaces;

using Microsoft.Practices.Unity;

namespace ExampleUseUnityIOC
{
	class Program
	{
		static bool CheckDriver(IDriver driver)
		{
			if (!driver.IsExistLicence | !driver.IsExistCarDocuments)
			{
				return false;
			}

			return true;
		}

		static bool CheckEngine(IEngine engine)
		{
			if (!engine.IsBroken)
			{
				return false;
			}

			return true;
		}

		static bool CheckFuel(IFuel fuel)
		{
			if (fuel.GetLevelFuel() < 1)
			{
				return false;
			}

			return true;
		}

		static bool CheckCar(ICar car)
		{
			if (!CheckDriver(car.Driver) | CheckEngine(car.Engine) | !CheckFuel(car.Fuel))
			{
				return false;
			}

			return true;
		}

		static void Main(string[] args)
		{
			ICar car = DependencyResolver.GetContainer().Resolve<ICar>();

			Console.WriteLine("Result cheking car: {0}", CheckCar(car));

			Console.ReadLine();
		}
	}
}
