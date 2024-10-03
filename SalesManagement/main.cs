using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnCathergories_Click(object sender, EventArgs e)
        {
            cathegories cathegories = new cathegories();
            cathegories.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            products products = new products();
            products.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            sales sales = new sales();
            sales.Show();
        }

        private void tbnCustomers_Click(object sender, EventArgs e)
        {
            customers customers = new customers();
            customers.Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            statistics statistics = new statistics();
            statistics.Show();
        }
    }
}
