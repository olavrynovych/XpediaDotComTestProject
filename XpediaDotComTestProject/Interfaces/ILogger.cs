using System;

namespace XpediaDotComTestProject.Interfaces
{
    public interface ILogger
    {
        void Log(Exception ex, string byLocator);
    }
}
