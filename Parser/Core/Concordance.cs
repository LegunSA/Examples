using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Concordance
    {
        public static string ResultToString(this Dictionary<string, List<int>> parse)
        {
            StringBuilder resultstring = new StringBuilder();

            var cc2 = parse.OrderBy(x => x.Key).GroupBy(x => new { letter = x.Key.Substring(0, 1) }).Select(c => new { letter = c.Key.letter, item = c.Select(t => t) });

            foreach (var item in cc2)
            {
                resultstring.Append(item.letter + " Letter \n\r");
                foreach (var word in item.item)
                {
                    string positionstring = "";
                    foreach (var position in word.Value.Distinct())
                    {
                        positionstring = positionstring + " " + position;
                    }
                    resultstring.Append(word.Key + "\t" + word.Value.Count + ":  " + positionstring + "\n\r");

                }
            }

            return resultstring.ToString();
        }
    }
}
