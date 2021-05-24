namespace AgileCoding.Extentions.Exceptions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    //using AgileCoding.Extentions.Activators;

    public static class ExceptionExtentions
    {
        public static string ToStringAll(this Exception ex)
        {
            if (ex != null)
            {
                StringBuilder sb = new StringBuilder();
                WriteExectionToStringBuilder(ex, sb, "-----Top Exception Details -----", "----- End of Top Exception Details ----");
                CheckInnerException(ex.InnerException, sb);

                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private static Exception AddReflectionTypeLoadException<IExceptionType>(this Exception exception)
            where IExceptionType : Exception
        {
            var exceptionString = GetReflectionTypeLoadException(exception);
            if (string.IsNullOrEmpty(exceptionString))
            {
                //return typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(exceptionString);
                return null;
            }

            return exception;
        }

        private static string GetReflectionTypeLoadException(Exception exception)
        {
            StringBuilder allLoaderExceptions = new StringBuilder();
            if (exception is System.Reflection.ReflectionTypeLoadException)
            {
                allLoaderExceptions.AppendLine($"Main Exception {Environment.NewLine}{ToStringAll(exception)}{Environment.NewLine}LoaderException(s) : {Environment.NewLine}");

                var typeLoadException = exception as ReflectionTypeLoadException;
                var loaderExceptions = typeLoadException.LoaderExceptions.ToList();

                loaderExceptions.ForEach((loaderException) =>
                {
                    allLoaderExceptions.AppendLine($"{ToStringAll(loaderException)}");

                    if (loaderException is FileNotFoundException)
                    {
                        allLoaderExceptions.AppendLine($"FusionLog : {((FileNotFoundException)loaderException).FusionLog}");
                    }
                    else if (loaderException is FileLoadException)
                    {
                        allLoaderExceptions.AppendLine($"FusionLog : {((FileLoadException)loaderException).FusionLog}");
                    }

                    allLoaderExceptions.Append("----End Of Loader Exception-----");
                });

            }

            return allLoaderExceptions.ToString();
        }

        private static void CheckInnerException(Exception ex, StringBuilder sb)
        {
            if (ex != null)
            {
                WriteExectionToStringBuilder(ex, sb, "----- Inner Exception Details -----", "----- End of Inner Exception Details -----");
                CheckInnerException(ex.InnerException, sb);
            }
        }

        private static void WriteExectionToStringBuilder(Exception ex, StringBuilder sb, string introString, string endString)
        {
            sb.AppendLine(introString);
            if (ex is System.Reflection.ReflectionTypeLoadException)
            {
                sb.AppendLine(GetReflectionTypeLoadException(ex));
            }
            else
            {
                sb.AppendLine(ex.ToString());
            }

            sb.AppendLine(endString);
        }
    }
}
