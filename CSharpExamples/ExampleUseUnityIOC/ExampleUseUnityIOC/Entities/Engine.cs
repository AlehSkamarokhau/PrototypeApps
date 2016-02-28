using System;
using ExampleUseUnityIOC.Interfaces;

namespace ExampleUseUnityIOC.Entities
{
	public class Engine : IEngine
	{
		public bool IsBroken
		{
			get
			{
				return false;
			}

			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
