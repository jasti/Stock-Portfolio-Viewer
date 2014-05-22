using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;

namespace PerformanceCalculator
{
    // The main class that orchestrates all the components
    // @author : jasti
    static class Engine
    {
        private static String baseYahooUrl = "http://finance.yahoo.com/d/quotes.csv?s=";
        private static String baseYahooelements = "&f=snopl1";
        public static String yahooConcatenator = "+";

      /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.WriteLine("Portfolio Viewer is launching, please wait...");
            Console.WriteLine("Approximate wait time of 8 seconds.");
            // Load data from the XML datastore

            Portfolio portfolio = new Portfolio();
            Calculator calculator = new Calculator();

            String startupPath = Application.StartupPath + "\\Portfolio.xml";
            // TODO Make this a relative path instead of an absolute path
            //C:\\developer\\code\\c#\\PerformanceCalculator\\PerformanceCalculator\\Portfolio.xml
            portfolio = portfolio.ReadPortfolio(startupPath);

            // Iterate over the tickers to construct the URL 

            List<Position> positions = portfolio.positions;

            String concatenatedTicker = "";

            if (positions != null)
            {
                foreach (Position position in positions)
                {
                    concatenatedTicker = concatenatedTicker + position.Ticker + yahooConcatenator;
                }
                // Removing the last "+" sign
                concatenatedTicker = concatenatedTicker.Substring(0, concatenatedTicker.LastIndexOf(yahooConcatenator));
            }
            // Construct final URL

            String yahooURL = baseYahooUrl + concatenatedTicker + baseYahooelements;

            // Call Yahoo 

            string csvData;

            using (WebClient web = new WebClient())
            {
                csvData = web.DownloadString(yahooURL);
            }

            // Parse prices coming back

            List<Price> prices = YahooFinance.Parse(csvData);

            // Map prices to portfolios

            foreach (Price price in prices)
            {

                if (positions != null)
                {
                    foreach (Position position in positions)

                        
                    {
                        String simpleSymbol = price.Symbol.Replace("\"", "");

                        if (position.Ticker.Equals(simpleSymbol))
                        {

                            position.SecName = price.Name.Replace("\"", "");
                            position.SecLastPrice = price.Last;
                            position.SecOpenPrice = price.Open;
                            position.SecPrevClosePrice = price.PreviousClose;

                            // Also calculate PnLs

                            calculator.calculateDailyPnL(position);
                            calculator.calculateTotalPnL(position);

                        }

                        //   Console.WriteLine(string.Format("{0} ({1}) Last:{2} Open: {3} PreviousClose:{4}", price.Name, price.Symbol, price.Last, price.Open, price.PreviousClose));
                    }

                  


                }
            }

            // Calculate absolute values PnL values at the portfolio level

            portfolio = calculator.calculatePortfolioTotals(portfolio);
            portfolio = calculator.calculatePortfolioTotalPercent(portfolio);

            portfolio.printToConsole();

            // Add to the final list for display

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(portfolio));
            
        }
    }
}

