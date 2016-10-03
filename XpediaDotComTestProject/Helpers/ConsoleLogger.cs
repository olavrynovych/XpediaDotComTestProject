using System;
using System.Text;
using XpediaDotComTestProject.Interfaces;

namespace XpediaDotComTestProject.Helpers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(Exception ex, string byLocator=null)
        {
            var errorLog = new StringBuilder();
            errorLog.AppendLine($"ERROR. Message: '{ex.Message}', Source: '{ex.Source}', toString: '{byLocator.ToString()}' ");
            Console.WriteLine(errorLog);
        }
    }
}
