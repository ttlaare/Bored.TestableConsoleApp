using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Tests
{
    public class ConsoleWrapper : IConsole
    {
        public List<string> LinesToRead = new List<string>();

        public List<string> WrittenLines { get; private set; } = new List<string> ();

        private int writtenlinesIndex = 0;

        public void Write(string message)
        {
            if (WrittenLines.Any())
            {
                WrittenLines.Add(message);
                writtenlinesIndex++;
                return;
            }
            WrittenLines[writtenlinesIndex] = message;
        }

        public void WriteLine(string message)
        {
            WrittenLines.Add(message);
            writtenlinesIndex++;
        }

        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }
    }
}
