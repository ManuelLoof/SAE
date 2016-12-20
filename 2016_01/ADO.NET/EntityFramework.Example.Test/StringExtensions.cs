using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Example.Test
{
    public static class StringExtensions
    {
        public static string AddManu(this string text)
        {
            return text + " Manu ist der coolste! ;-)";
        }
    }
}
