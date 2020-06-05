using System.Collections.Generic;
using System.Linq;

namespace Hackaton_Project
{
   static class RomanConverter
       {
           static Dictionary<int, string> ra = new Dictionary<int, string>
           { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
               { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
               { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };
       
           public static int ToArabic(string number) => number.Length == 0 ? 0 : ra
               .Where(d => number.StartsWith(d.Value))
               .Select(d => d.Key + ToArabic(number.Substring(d.Value.Length)))
               .First();
       }
    
}