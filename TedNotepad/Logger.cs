using System;
using System.Text;
using System.IO;

namespace SofTest402.TeamTiga.FinalProject
{
    class Logger
    {
        public string logname;

        public Logger(string fname)
        {
            File.Delete(fname);
            logname = fname;
        }

        public void AddTextToLog(string info)
        {
            try
            {
                File.AppendAllText(logname, info + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}
