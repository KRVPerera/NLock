using log4net;
using System;

namespace NLock.NLockFile.ContextMenus
{
    internal static class ArgumentParser
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ArgumentParser));

        public static int Parse(String[] args)
        {
            logger.Debug(String.Join(" : ", args));
            if (args.Length > 2)
            {
                return -1;
            }
            else if (args.Length == 1 || args[0] == "-o")
            {
                return 0;
            }
            else if (args[0] == "-ut")
            {
                return 1;
            }
            else if (args[0] == "-uh")
            {
                return 2;
            }
            else if (args[0] == "-a")
            {
                return 3;
            }
            else if (args[0] == "-D")
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }
    }
}