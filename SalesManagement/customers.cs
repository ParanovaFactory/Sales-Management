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
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
        }

        SelesManagementEntities entities = new SelesManagementEntities();

        void list()
        {
            var cust = (from x in entities.TblCustomers select new
            {
                x.customerId,
                x.customerName,
                x.customerSurname,
                x.customerCity
            }).ToList();
            dataGridView1.DataSource = cust;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblCustomer customer = new TblCustomer();
                customer.customerName = txtName.Text;
                customer.customerSurname = txtSurname.Text;
                customer.customerCity = cmbCity.Text;
                entities.TblCustomers.Add(customer);
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
                int id = Convert.ToInt32(txtId.Text);
                var cus = entities.TblCustomers.Find(id);
                entities.TblCustomers.Remove(cus);
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
                int id = Convert.ToInt32(txtId.Text);
                var cus = entities.TblCustomers.Find(id);
                cus.customerName = txtName.Text;
                cus.customerSurname = txtSurname.Text;
                cus.customerCity = cmbCity.Text;
                entities.SaveChanges();
                list();

            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid value");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbCity.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            cmbCity.Text = " ";
        }
    }
}
