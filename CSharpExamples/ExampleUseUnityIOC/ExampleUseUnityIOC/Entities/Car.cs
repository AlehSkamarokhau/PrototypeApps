using System;
using ExampleUseUnityIOC.Interfaces;

namespace ExampleUseUnityIOC.Entities
{
	public class Car : ICar
	{
		private IDriver _driver;
		private IEngine _engine;
		private IFuel _fuel;

		public IDriver Driver
		{
			get
			{
				return _driver;
			}

			set
			{
				_driver = value;
			}
		}

		public IEngine Engine
		{
			get
			{
				return _engine;
			}

			set
			{
				_engine = value;
			}
		}

		public IFuel Fuel
		{
			get
			{
				return _fuel;
			}

			set
			{
				_fuel = value;
			}
		}

		public Car(IDriver driver, IEngine engine, IFuel fuel)
		{
			if (driver == null)
			{
				throw new ArgumentNullException("driver");
			}

			if (engine == null)
			{
				throw new ArgumentNullException("engine");
			}

			if (fuel == null)
			{
				throw new ArgumentNullException("fuel");
			}

			_driver = driver;
			_engine = engine;
			_fuel = fuel;
		}
	}
}
