using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Tests
{
    public class ConsoleWrapper : IConsole
    {
        public List<string> LinesToRead = new List<string>();

        public string WrittenLines
        {
            get { return stringBuilder.ToString(); }
        }

        private readonly StringBuilder stringBuilder = new StringBuilder();

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
    }
}
