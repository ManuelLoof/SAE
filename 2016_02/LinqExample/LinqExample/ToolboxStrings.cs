using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToolbox
{
    public static class ToolboxStrings
    {
        /// <summary>
        /// Liefert den hinteren Teil eines Strings zurück.
        /// </summary>
        /// <param name="value">Der zu bearbeitende String.</param>
        /// <param name="length">Die Länge des Strings,</param>
        /// <returns>Der rechte Teil des Strings in der gewünschten Länge.</returns>
        public static string Right(this string value, int length)
        {
            return value.Substring(value.Length - length, length);
        }

        public static string RightPlayerName(this Player p, int length)
        {
            return p.Name.Right(length);
        }


    }
}
