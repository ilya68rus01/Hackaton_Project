using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackaton_Project
{
    public class AddressProcessor
    {
        RomanConverter converter = new RomanConverter();
        UselessWordsDeleter deleter = new UselessWordsDeleter();
        public char[] RemoveChars { get; set; } = { '\"', '*' };
        public char[] RemoveCharsString { get; set; } = { ' ', ',', ';' };
        public char[] TrimChar { get; set; } = { ' ', ',', ';' };


        string replaceArrayChar(string s, char[] charArray)
        {
            for (int i = 0; i < charArray.Count(); i++)
            {
                s = s.Replace(charArray[i].ToString(), "");
            }
            return s;
        }

        string replaceArrayString(string s, char[] charArray)
        {
            for (int i = 0; i < charArray.Count(); i++)
            {
                string str = charArray[i].ToString() + charArray[i].ToString();
                s = s.Replace(str, charArray[i].ToString());
                string str2 = charArray[i].ToString() + " " + charArray[i].ToString();
                s = s.Replace(str2, charArray[i].ToString());
              
                s = s.Replace(str, charArray[i].ToString());
                s = s.Replace(str2, charArray[i].ToString());
            }
            return s;
        }

        public IEnumerable<string> processor(IEnumerable<string> inputAddress)
        {
            string[] outList = new string[inputAddress.Count()];
            Parallel.For(0, inputAddress.Count(), i => { outList[i] = processForString(inputAddress.ElementAt(i)); });
            //List<string> outList = new List<string>();
            //foreach (var item in inputAddress)
            //{
            //    outList.Add(processForString(item));
            //}
            return outList;
        }

        string processForString(string inStr)
        {

            string str;
            str = replaceArrayChar(inStr, RemoveChars);
            str = Regex.Replace(str, @"\(.*\)", "");
            str = converter.ConvertString(str);
            str = deleter.deleteUseless(str);
            str = replaceArrayString(str, RemoveCharsString);
            str = str.Trim(TrimChar);
            return str;
        }
    }
}