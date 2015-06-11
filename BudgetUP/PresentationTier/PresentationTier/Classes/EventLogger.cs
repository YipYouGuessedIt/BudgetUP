using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace PresentationTier.Views
{
    public class EventLogger
    {

        public void LogFile( string sFunctionName, string sEventName, string sExceptionDetails, string nErrorLineNo)
        {
            StreamWriter log;
            if (!File.Exists("BudgetUPErrorLog.txt"))
            {
                log = new StreamWriter("BudgetUPErrorLog.txt");
            }
            else
            {
                log = File.AppendText("BudgetUPErrorLog.txt");
            }

            // Write to the file:
            log.WriteLine("Data Time:" + DateTime.Now);            
            log.WriteLine("Function Name:" + sFunctionName);
            log.WriteLine("Event Name:" + sEventName);
            log.WriteLine("Exception Details:" + sExceptionDetails);            
            log.WriteLine("Error on:" + nErrorLineNo);
            log.WriteLine("=====================================================================================================================");
            // Close the stream:
            log.Close();

        }
    }
}