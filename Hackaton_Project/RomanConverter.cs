using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hackaton_Project
{ 
    class RomanConverter
       {
           static Dictionary<int, string> ra = new Dictionary<int, string>
           { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
               { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
               { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };
       
           private static int ToArabic(string number) => number.Length == 0 ? 0 : ra
               .Where(d => number.StartsWith(d.Value))
               .Select(d => d.Key + ToArabic(number.Substring(d.Value.Length)))
               .First();

           public string ConvertString(string badString)
           {
               Regex regex = new Regex( @"[IVXCDM]+");
               MatchCollection matches = regex.Matches(badString);
               if (matches.Count > 0)
               {
                   foreach (Match match in matches)
                   {
                       badString = badString.Replace(match.ToString(), ToArabic(match.ToString()).ToString());
                   }
               }
               return badString;
           }
       }
    
}