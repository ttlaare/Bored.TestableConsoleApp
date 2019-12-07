using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Tests
{
    public class OrderShouldTestCases
    {
        private static List<string> consoleWrittenLines = new List<string>()
        {   "What would you like to eat?",
            "Press 1 for a hamburger. Price: 2,95.",
            "Press 2 for a grilled sandwich. Price: 2,45.",
            "What would you like to drink?",
            "Press 1 for a Cola. Price: 1,45.",
            "Press 2 for juice. Price: 1,95." 
        };

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<string>() { "1", "1" }, consoleWrittenLines,4.4);
                yield return new TestCaseData(new List<string>() { "1", "2" }, consoleWrittenLines,4.9);
                yield return new TestCaseData(new List<string>() { "2", "1" }, consoleWrittenLines,3.9);
                yield return new TestCaseData(new List<string>() { "2", "2" }, consoleWrittenLines,4.4);
            }
        }
    }
}
