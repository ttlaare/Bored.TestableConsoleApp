using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Tests
{
    public class ConsoleWrapper : IConsole, IDisposable
    {
        bool _disposed;
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public List<string> LinesToRead = new List<string>(); //Dispose 

        public string WrittenLines
        {
            get { return stringBuilder.ToString(); }
        }

        public void Write(string message)
        {
            stringBuilder.Append(message);
        }

        public void WriteLine(string message)
        {
            stringBuilder.AppendLine(message);
        }

        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                stringBuilder.Remove(0, stringBuilder.Length);
                LinesToRead.RemoveAll(_ => true);
            }
            _disposed = true;
        }
    }
}
