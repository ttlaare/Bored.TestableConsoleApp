using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Tests
{
    //http://www.vtrifonov.com/2012/11/getting-console-output-within-unit-test.html
    //https://app.pluralsight.com/player?course=building-dotnet-console-applications-csharp&author=jason-roberts&name=building-dotnet-console-applications-csharp-m1&clip=6&mode=live
    //TODO: Implement IDispossable best practices
    public class ConsoleInput : IDisposable
    {
        private StringReader stringReader;
        private TextReader originalInput;

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
            Console.SetIn(originalInput);
            stringReader.Dispose();
        }

    }
}
