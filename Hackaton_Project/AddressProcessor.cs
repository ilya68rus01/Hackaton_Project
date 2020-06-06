using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hackaton_Project
{
    class AddressProcessor
    {
        public char[] RemoveChars { get; set; }
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
            List<string> outList = new List<string>();

            foreach (var item in inputAddress)
            {
                outList.Add(processForString(item));
            }
            return outList;
        }

        string processForString(string inStr)
        {
            string str;
            str = replaceArrayChar(inStr, RemoveChars);
            str = Regex.Replace(str, @"\(.*\)", "");
           
            return str;
        }
    }
}
