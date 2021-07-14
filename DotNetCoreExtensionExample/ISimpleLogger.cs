using System;

namespace DotNetCoreExtensionExample
{
    public interface ISimpleLogger
    {
        void Log(string message);
        void Log(string message, string messageType);
    }
}
