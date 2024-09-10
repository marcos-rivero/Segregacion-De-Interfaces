using Serilog;

namespace Liskov
{
    public class Logging : ILogging
    {
        //private readonly LogRepository _logRepository
        //public Logging()
        //{

        //}
        public void Info(string message)
        {
            Log.Information(message);
        }
        public void Error(string message, Exception e)
        {
            Log.Error(e, message);
        }
        // Por Herencia public virtual void Fatal(string message, Exception e)
        public void Fatal(string message, Exception e)
        {
            Log.Fatal(e, message);
        }
    }
}
