using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceCalculator
{
    public static class YahooFinance
    {
        public static List<Price> Parse(string csvData)
        {
            List<Price> prices = new List<Price>();

            string[] rows = csvData.Replace("\r", "").Split('\n');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;

                string[] cols = row.Split(',');

                Price p = new Price();
                p.Symbol = cols[0];
                p.Name = cols[1];
                p.Open = Convert.ToDecimal(cols[2]);
                p.PreviousClose = Convert.ToDecimal(cols[3]);
                p.Last = Convert.ToDecimal(cols[4]);

                prices.Add(p);
            }

            return prices;
        }
    }

    public class Price
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Open { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Last { get; set; }
    }
}
