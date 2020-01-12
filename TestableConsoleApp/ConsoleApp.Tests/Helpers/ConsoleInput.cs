using System;
using System.IO;

namespace ConsoleApp.Tests
{
    //http://www.vtrifonov.com/2012/11/getting-console-output-within-unit-test.html
    //https://app.pluralsight.com/player?course=building-dotnet-console-applications-csharp&author=jason-roberts&name=building-dotnet-console-applications-csharp-m1&clip=6&mode=live
    class ConsoleInput : IDisposable
    {
        private readonly StringReader stringReader;
        private readonly TextReader originalInput;
        private bool disposed;


        public ConsoleInput(string input)
        {
            stringReader = new StringReader(input);
            originalInput = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(stringReader);
        }

        public string GetOuput()
        {
            return stringReader.ToString();
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
                Console.SetIn(originalInput);
                stringReader?.Dispose();
                originalInput?.Dispose();
                disposed = true;
            }
        }
    }
}
