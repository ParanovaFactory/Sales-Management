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
    public partial class statistics : Form
    {
        public statistics()
        {
            InitializeComponent();
        }

        SelesManagementEntities entities = new SelesManagementEntities();

        private void statistics_Load(object sender, EventArgs e)
        {
            totalCat.Text = entities.TblCategories.Count().ToString();
            totalProdc.Text = entities.TblProducts.Count().ToString();
            activeCst.Text = entities.TblCustomers.Count(x => x.customerStatus == true).ToString();
            pasiveCst.Text = entities.TblCustomers.Count(x => x.customerStatus == false).ToString();
            totatWhiteApp.Text = entities.TblProducts.Count(x => x.productCathegory == 1).ToString();
            totalStock.Text = entities.TblProducts.Sum(x => x.productStock).ToString();
            highestPrice.Text = (from x in entities.TblProducts orderby x.productPreis descending select x.productName).FirstOrDefault();
            lowestPrice.Text = (from x in entities.TblProducts orderby x.productPreis ascending select x.productName).FirstOrDefault();
            totalCash.Text = entities.TblSales.Sum(x => x.salePreis).ToString();
            totalLaptop.Text = entities.TblProducts.Count(x => x.productName == "Laptop").ToString();
            totalCity.Text = (from x in entities.TblCustomers select x.customerCity).Distinct().Count().ToString();
            brand.Text = entities.brand().FirstOrDefault().ToString();
        }
    }
}
