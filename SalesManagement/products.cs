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
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
        }

        SelesManagementEntities entities = new SelesManagementEntities();

        void list()
        {
            var products = (from x in entities.TblProducts
                            select new
                            {
                                x.productId,
                                x.productName,
                                x.productBrand,
                                x.productStock,
                                x.productPreis,
                                x.productStatus,
                                x.TblCategory.cathegoryName,
                            }).ToList();
            dataGridView1.DataSource = products;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblProduct tblProduct = new TblProduct();
                tblProduct.productName = txtName.Text;
                tblProduct.productBrand = txtBrand.Text;
                tblProduct.productStock = Convert.ToInt16(txtStock.Text);
                tblProduct.productPreis = Convert.ToDecimal(txtPreis.Text);
                tblProduct.productCathegory = int.Parse(cmbCathegory.SelectedValue.ToString());
                tblProduct.productStatus = true;
                entities.TblProducts.Add(tblProduct);
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid values");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                var prf = entities.TblProducts.Find(id);
                entities.TblProducts.Remove(prf);
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid values");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                var prf = entities.TblProducts.Find(id);
                prf.productName = txtName.Text;
                prf.productBrand = txtBrand.Text;
                prf.productStock = Convert.ToInt16(txtStock.Text);
                prf.productPreis = Convert.ToDecimal(txtPreis.Text);
                prf.productCathegory = int.Parse(cmbCathegory.SelectedValue.ToString());
                prf.productStatus = true;
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid values");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtStock.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPreis.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbCathegory.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            list();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtBrand.Clear();
            txtStock.Clear();
            txtPreis.Clear();
            txtStatus.Clear();
            cmbCathegory.Text = " ";
            list();
        }

        private void products_Load(object sender, EventArgs e)
        {
            var cathegory = (from x in entities.TblCategories
                             select new
                             {
                                 x.cathegoryId,
                                 x.cathegoryName
                             }
                             ).ToList();
            cmbCathegory.ValueMember = "cathegoryId";
            cmbCathegory.DisplayMember = "cathegoryName";
            cmbCathegory.DataSource = cathegory;
        }
    }
}
