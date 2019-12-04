using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public interface IConsole
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine();
    }
}
