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
        public char[] RemoveChars { get; set; } = { '\"' };
        string replaceArrayChar(string s, char[] charArray)
        {
            for (int i = 0; i < charArray.Count(); i++)
            {
                s = s.Replace(charArray[i].ToString(), "");
            }
            return s;
        }

        public IEnumerable<string> processor(IEnumerable<string> inputAddress)
        {
            string[] outList = new string[inputAddress.Count()];
            //List<string> outList = new List<string>();
            Parallel.For(0, inputAddress.Count(), i => { outList[i] = processForString(inputAddress.ElementAt(i)); });
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
            return str;
        }
    }
}
