using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PerformanceCalculator
{
    // The main form that displays the Portfolio positions and appropriate calculations
    // @author : jasti
    public partial class Form1 : Form
    {
        private Portfolio portfolio;

        public Form1()
        {
     
        }

        public Form1(Portfolio portfolio)
        {
            InitializeComponent();
            this.portfolio = portfolio;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.textBox1.Text = this.portfolio.portfolioDailyPnL.ToString();
            this.textBox2.Text = this.portfolio.portfolioTotalPnL.ToString();
            this.label3.Text = this.portfolio.portfolioName.ToString();
            this.textBox4.Text = this.portfolio.portfolioCostBasis.ToString();
            this.textBox5.Text = this.portfolio.portfolioCurrentValue.ToString();
            this.textBox3.Text = Math.Round(( this.portfolio.portfolioTotalPnLPernt * 100),2).ToString() + " %";
            this.dataGridView1.DataSource = this.portfolio.positions;
        }




      
     

      
    }
}
