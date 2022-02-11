using System;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensionMethods
    { 
       
        public static string RemoveDigits(this String input)
        {
          return Regex.Replace(input, @"\d", "");
        }
    }
}