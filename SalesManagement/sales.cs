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
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
        }

        SelesManagementEntities entities = new SelesManagementEntities();

        void list()
        {
            var sale = (from x in entities.TblSales select new
            {
                x.saleId,
                x.TblCustomer.customerName,
                x.TblCustomer.customerSurname,
                x.TblProduct.productName,
                x.salePreis,
                x.saleDate
            }).ToList();
            dataGridView1.DataSource = sale;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblSale tblSale = new TblSale();
                tblSale.saleCustomer = int.Parse(cmbCustomer.SelectedValue.ToString());
                tblSale.saleProduct = int.Parse(cmbProduct.SelectedValue.ToString());
                tblSale.salePreis = decimal.Parse(txtPreis.Text);
                tblSale.salePreis = decimal.Parse(txtDate.Text);
                entities.TblSales.Add(tblSale);
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid value");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                var sale = entities.TblSales.Find(id);
                entities.TblSales.Remove(sale);
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid value");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                var sale = entities.TblSales.Find(id);
                sale.saleCustomer = int.Parse(cmbCustomer.SelectedValue.ToString());
                sale.saleProduct = int.Parse(cmbProduct.SelectedValue.ToString());
                sale.salePreis = decimal.Parse(txtPreis.Text);
                sale.salePreis = decimal.Parse(txtDate.Text);
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid value");
            }
        }

        private void sales_Load(object sender, EventArgs e)
        {
            var customer = (from x in entities.TblCustomers
                             select new
                             {
                                 x.customerId,
                                 x.customerName
                             }
                             ).ToList();
            cmbCustomer.ValueMember = "customerId";
            cmbCustomer.DisplayMember = "customerName";
            cmbCustomer.DataSource = customer;

            var product = (from x in entities.TblProducts
                            select new
                            {
                                x.productId,
                                x.productName
                            }
                             ).ToList();
            cmbProduct.ValueMember = "productId";
            cmbProduct.DisplayMember = "productName";
            cmbProduct.DataSource = product;

            cmbCustomer.Text = " ";
            cmbProduct.Text = " ";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbCustomer.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbProduct.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPreis.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            cmbCustomer.Text = " ";
            cmbProduct.Text = " ";
            txtPreis.Clear();
            txtDate.Clear();
        }
    }
}
