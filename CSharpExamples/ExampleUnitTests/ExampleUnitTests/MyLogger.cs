using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace ExampleUnitTests
{
	public class MyLogger
	{
		private static Logger _logger = LogManager.GetCurrentClassLogger();

		public static void WriteTraceMessage(string msg)
		{
			_logger.Trace(msg);
		}

		public static void WriteErrorMessage(string msg)
		{
			_logger.Error(msg);
		}
	}
}
