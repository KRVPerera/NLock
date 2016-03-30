using System;
using log4net;

namespace NLock.NLockFile.ContextMenus
{
	internal static class ArgumentParser
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof (ArgumentParser));

		public static int Parse(String[] args)
		{
			Logger.Debug(String.Join(" : ", args));
			if (args.Length > 2)
			{
				return -1;
			}
			if (args.Length == 1 || args[0] == "-o")
			{
				return 0;
			}
			if (args[0] == "-ut")
			{
				return 1;
			}
			if (args[0] == "-uh")
			{
				return 2;
			}
			if (args[0] == "-a")
			{
				return 3;
			}
			if (args[0] == "-D")
			{
				return 4;
			}
			return -1;
		}
	}
}