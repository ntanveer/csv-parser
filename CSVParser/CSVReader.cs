using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core;
using TechXplorers.ArgumentValidation;

namespace Service
{
    public interface ICSVReader
    {
        string[] ParseLine(string line);
    }

    public class CSVReader : ICSVReader
    {
        public string[] ParseLine(string line)
        {
            var values = new List<string>();
            var valueBuilder = new List<char>();
            var withinQuote = false;

            foreach (var character in line)
            {
                if (withinQuote)
                {
                    valueBuilder.Add(character);
                }
                else if (character == ',')
                {
                    values.Add(valueBuilder.ToTrimedValue());
                    valueBuilder.Clear();
                }

                if (character == '"')
                {
                    withinQuote = !withinQuote;
                }
            }

            values.Add(valueBuilder.ToTrimedValue());

            return values.ToArray();
        }

        //public string[] ParseLine(string line) //TODO: This may be a better alternate.
        //{
        //    var values = new List<string>();
        //    var regex = new Regex("(?<=^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)");

        //    foreach (Match m in regex.Matches(line))
        //    {
        //        values.Add(m.Value);

        //    }

        //    return values.ToArray();
        //}
    }
}
