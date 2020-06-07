using System.Text.RegularExpressions;

namespace Hackaton_Project
{
    public class UselessWordsDeleter
    {
        public string deleteUseless(string str)
        {
            str = deleteFloorWords(str);
            str = deleteRoomWords(str);
            str = renameRoom(str);
            return str;
        }

        private string deleteFloorWords(string badString)
        {
            Regex regex = new Regex(@"эт[аж]*[.]?[ [0-9]+]?", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(badString);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    badString = badString.Replace(match.ToString(), ",");
                }
            }
            return badString;
        }

        private string deleteRoomWords(string str)
        {
            Regex regex = new Regex(@"пом[ещени[е]*[я]*]*[.]?[ [0-9]+]?", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    str = str.Replace(match.ToString(), ",");
                }
            }
            return str;
        }

        private string renameRoom(string str)
        {
            Regex regex = new Regex(@"ком[[ната]*[.]*[ ]?]?", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    str = str.Replace(match.ToString(), "кв. ");
                }
            }
            return str;
        }

    }
}