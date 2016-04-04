using System;

namespace NLock.NLockFile.Exceptions
{
    internal static class ExceptionHelper
    {
        public static Exception GetInnerException(Exception ex)
        {            
            while ((ex is AggregateException) && (ex.InnerException != null))
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}