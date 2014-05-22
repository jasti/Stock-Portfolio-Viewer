using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerformanceCalculator
{
    // @author : jasti
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void calculateDailyPnLTest()
        {
            Calculator calculator = new Calculator();
            Position position  = new Position();
            position.SecLastPrice = 102;
            position.SecPrevClosePrice = 100;

           position=  calculator.calculateDailyPnL(position);
            Assert.AreEqual(position.DailyPnL ,2);

        }

        [TestMethod]
        public void calculateTotalPnLTest()
        {
            Calculator calculator = new Calculator();
            
            Position position = new Position();
            position.SecLastPrice = 102;
            position.SecPrevClosePrice = 100;
       
            position.ExecPrice = 100;
            position.Quantity = 10;
            position.SecLastPrice = 120;

            position = calculator.calculateTotalPnL(position);
            Assert.AreEqual(position.TotalPnL, 200);

        }

        [TestMethod]
        public void calculatePortfolioTotalsTest()
        {
            Calculator calculator = new Calculator();
            Portfolio portfolio = new Portfolio();
            List<Position> positions = new List<Position>();
            Position position1 = new Position();

            position1.SecLastPrice = 102;
            position1.SecPrevClosePrice = 100;
            position1.ExecPrice = 100;
            position1.Quantity = 10;
            position1.DailyPnL = 20;
            position1.TotalPnL = 120;
         
            Position position2 = new Position();

            position2.SecLastPrice = 102;
            position2.SecPrevClosePrice = 100;
            position2.ExecPrice = 100;
            position2.Quantity = 10;
            position2.DailyPnL = 10;
            position2.TotalPnL = 240;

            positions.Add(position1);
            positions.Add(position2);

            portfolio.positions = positions;


            portfolio = calculator.calculatePortfolioTotals(portfolio);
            Assert.AreEqual(portfolio.portfolioTotalPnL, 360);
            Assert.AreEqual(portfolio.portfolioDailyPnL, 30);

        }


    }
}
   