using System;
using ExampleUseUnityIOC.Interfaces;

namespace ExampleUseUnityIOC.Entities
{
	public class Driver : IDriver
	{
		public bool IsExistCarDocuments
		{
			get
			{
				return true;
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsExistLicence
		{
			get
			{
				return true;
			}

			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
