using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Tests
{
    //http://www.vtrifonov.com/2012/11/getting-console-output-within-unit-test.html
    //TODO: Implement IDispossable best practices
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

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
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
