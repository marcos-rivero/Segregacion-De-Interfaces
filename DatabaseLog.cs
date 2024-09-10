using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    public interface ILogging
    {
        void Info(string message);
        void Error(string message, Exception e);
        void Fatal(string message, Exception e);

    }

    // Por Herencia
    //public class DatabaseLog : Logging, ILogging
    //{
    //    public LogRepositorio _logRepo;
    //    //public DatabaseLog(LogRepositorio logRepo)
    //    public DatabaseLog()
    //    {
    //        //_logRepo = logRepo;
    //        _logRepo = new LogRepositorio();
    //    }
    //    public override void Fatal(string message, Exception e)
    //    {
    //        _logRepo.AlmacenarError(message, e);
    //        base.Fatal(message, e);
    //    }
    //}

    // Por Composicion
    public class DatabaseLog : ILogging
    {
        public readonly LogRepositorio _logRepo;
        public readonly Logging _logging;
        //public DatabaseLog(LogRepositorio logRepo)
        public DatabaseLog()
        {
            //_logRepo = logRepo;
            _logRepo = new LogRepositorio();
            _logging = new Logging();
        }

        public void Error(string message, Exception e)
        {
            _logging.Error(message, e);
        }

        public void Fatal(string message, Exception e)
        {
            _logRepo.AlmacenarError(message, e);
            _logging.Fatal(message, e);
        }

        public void Info(string message)
        {
            _logging.Info(message);
        }
    }
}
