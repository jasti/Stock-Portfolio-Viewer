using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerformanceCalculator
{
    // Calculator class performs all the math functions on portfolios and positions
    // @author : jasti
    public class Calculator
    {
        // Calculates the Daily PnL
        public Position calculateDailyPnL(Position position)
        {
            // Daily PnL = Yesterday's Close price - current price
            decimal yestClosePrice = position.SecPrevClosePrice;
            decimal latestPrice = position.SecLastPrice;
            position.DailyPnL = latestPrice - yestClosePrice;
            return position;
        }
        // Calculates the Total PnL since purchase of the position
        public Position calculateTotalPnL(Position position)
        {
            decimal executionPrice = position.ExecPrice;
            int positionSize = position.Quantity;
            decimal positionLast = position.SecLastPrice;

            position.TotalPnL = (positionLast * positionSize) - (executionPrice * positionSize);
            return position;
        }
        // Calculates the Total PnL of the portfolios since purchase of the positions
        public Portfolio calculatePortfolioTotals(Portfolio portfolio) 
        {
            decimal portfolioTotalPnL=0;
            decimal portfolioDailyPnL = 0;
            foreach (Position position in portfolio.positions) {
                portfolioTotalPnL = portfolioTotalPnL + position.TotalPnL;
                portfolioDailyPnL = portfolioDailyPnL + position.DailyPnL;
            }

            portfolio.portfolioTotalPnL = portfolioTotalPnL;
            portfolio.portfolioDailyPnL = portfolioDailyPnL;
            return portfolio;
        }

        // Calculates the Total PnL of the portfolios since purchase of the positions in % terms
        public Portfolio calculatePortfolioTotalPercent(Portfolio portfolio)
        {
            decimal costbasis = 0;
            decimal currentValue = 0;
           
            foreach (Position position in portfolio.positions)
            {
                costbasis = costbasis + (position.ExecPrice * position.Quantity);
                currentValue = currentValue + (position.SecLastPrice * position.Quantity);

            }

            portfolio.portfolioCostBasis = costbasis;
            portfolio.portfolioCurrentValue = currentValue;

            portfolio.portfolioTotalPnLPernt = (currentValue - costbasis) / costbasis;
            

            return portfolio;
        }

    }
}
