using System;
using System.IO;

namespace ConsoleApp.Tests
{
    //http://www.vtrifonov.com/2012/11/getting-console-output-within-unit-test.html
    class ConsoleOutput : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;
        private bool disposed;


        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                Console.SetOut(originalOutput);
                stringWriter?.Dispose();
                originalOutput?.Dispose();
                disposed = true;
            }
        }
    }
}
