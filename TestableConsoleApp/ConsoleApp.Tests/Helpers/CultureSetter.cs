using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ConsoleApp.Tests.ConsoleApp.Helpers
{
    public static class CultureSetter
    {
        public static void SetCulture(string cultureInput)
        {
            var culture = new CultureInfo(cultureInput);
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }
    }
}
