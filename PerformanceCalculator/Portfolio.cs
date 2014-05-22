using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PerformanceCalculator
{
    // Portfolio model class that encapsulates positions
    // @author : jasti
    public class Portfolio
    {
        public String portfolioName { get; private set; }
        public List<Position> positions { get; set; }
        public decimal portfolioDailyPnL { get; set; }
        public decimal portfolioTotalPnL { get; set; }
        public decimal portfolioTotalPnLPernt { get; set; }
        public decimal portfolioCostBasis { get; set; }
        public decimal portfolioCurrentValue { get; set; }



        public Portfolio ReadPortfolio(string filename)
        {
            if (File.Exists(filename))
            {
                Portfolio portfolio = new Portfolio();

                foreach (XElement transaction in XDocument.Load(filename).Descendants("portfolio"))
                {
                    XElement portfolioName = transaction.Element("portfolioName");
                    portfolio.portfolioName = portfolioName != null ? portfolioName.Value : string.Empty;
                }

                var positionList = new List<Position>();

                foreach (XElement transaction in XDocument.Load(filename).Descendants("position"))
                {
                    XElement positionTicker = transaction.Element("positionTicker");
                    XElement positionOpenDate = transaction.Element("positionOpenDate");
                    XElement positionSize = transaction.Element("positionSize");
                    XElement executionPrice = transaction.Element("executionPrice");


                    positionList.Add(new Position
                        {
                            Ticker = positionTicker != null ? positionTicker.Value : string.Empty,
                            OpenDate = positionOpenDate != null ? Convert.ToDateTime(positionOpenDate.Value) : DateTime.Now,
                            Quantity = positionSize != null ? int.Parse(positionSize.Value) : default(int),
                            ExecPrice = executionPrice != null ? decimal.Parse(executionPrice.Value) : default(decimal)
                        });
                }

                portfolio.positions = positionList;


                // Console.WriteLine(string.Format(" Number of transactions loaded : {0}",positionList.Count));''
                return portfolio;
            }
            else
            {
                Console.WriteLine("Input portfolio file not found. Please make sure you have the Portfolio.xml file in the correct location");
                return null;
            }
        }
/*
  private static void Main(string[] args)
        {
            Portfolio portfolio = new Portfolio();

            // TODO Make this a relative path instead of an absolute path
           portfolio= portfolio.ReadPortfolio("C:\\developer\\code\\c#\\PerformanceCalculator\\PerformanceCalculator\\Portfolio.xml");

           Console.WriteLine("The portfolio", portfolio);
        }
  */

        internal void printToConsole()
        {
            foreach (Position position in this.positions)
            {

            }
        }
    }
        
      
    public class Position
    {

        public String Ticker { get; set; }
        public decimal SecLastPrice { get; set; }
        public String SecName { get; set; }
        public int Quantity { get; set; }
        public decimal ExecPrice { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal DailyPnL { get; set; }
        public decimal TotalPnL { get; set; }
        public decimal SecOpenPrice { get; set; }
        public decimal SecPrevClosePrice { get; set; }

  


    }



}

