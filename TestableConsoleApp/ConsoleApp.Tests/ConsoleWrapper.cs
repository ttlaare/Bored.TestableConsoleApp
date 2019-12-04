using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp;

namespace ConsoleApp.Tests
{
    public class ConsoleWrapper : IConsole
    {
        public List<string> LinesToRead = new List<string>();

        public void Write(string message)
        {
        }

        public void WriteLine(string message)
        {
        }

        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }
    }
}
