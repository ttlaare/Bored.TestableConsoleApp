using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Tests.ConsoleApp.Helpers
{
    static class ConsoleInputBuilder
    {
        public static string Build(string input)
        {
            var inputList = input?.Split(',').ToList();
            var sb = new StringBuilder();
            foreach (var line in inputList)
                sb.AppendLine(line);
            return sb.ToString();
        }
    }
}
