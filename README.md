Stock-Portfolio-Viewer
======================

**A C# Windows thick client that is useful for monitoring your own portfolio holdings. Simply edit the portfolio.xml file with you stocks you hold and the initial price you bought them at and the run the solution.
Real time equity data price feed from Yahoo has been implemented and also other performance ( Daily and Cost Basis) oriented metrics associated with your portfolio.**

Instruction to run: 
-------------------

1. Checkout the project to any location. Main class is PerformanceCalculator\Engine.cs

2. Open the ‘PerformanceCalculator.sln’ in visual studio. You can either run or debug the solution directly from Visual Studio.

3. If you would like to change any of the positions in a portfolio, please modify the Portfolio.xml file under ‘PerformanceCalculator\bin\Debug’ and/ or ‘PerformanceCalculator\bin\Release’. 

4. The approximate wait time before the screen appears is about 5 seconds for the first time. This is mainly due to the lag in calling the Yahoo Finance API. Engine.cs is the main class.

5. When loaded, you should see the screen below : 

![alt tag](https://raw.githubusercontent.com/jasti/Stock-Portfolio-Viewer/master/assets/screenshot.png)


Possible Enhancements: 
----------------------

1. Since this is a simple application, there is not a lot of abstraction of interfaces. The Yahoo API and the calculations could be abstracted into a separate layer and dependency injected.

2. The process can handle only a single portfolio with any number of positions in the xml file. Could be enhanced to handle multiple portfolios. 

3. Some model classes’ variables are not camel cased, that’s because I am displaying the column names directly in the data grid. These could be changed to camel case. 

4. Does not handle the scenario where if a company name from Yahoo has a ‘comma’ in the name. e.g. Telsa, Inc 

5. Instead of changing the portfolio.xml in both locations( Debug & Release), a pre-build step can automate the copying of files 

6. The only class that is heavily tested is Calculator.cs file because of the math involved. The rest of the classes are very straightforward and hence not tested. Could increase test coverage. 

![alt tag](https://raw.githubusercontent.com/jasti/Stock-Portfolio-Viewer/master/assets/tests.png)
