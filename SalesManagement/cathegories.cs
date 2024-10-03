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
    public partial class cathegories : Form
    {
        public cathegories()
        {
            InitializeComponent();
        }

        SelesManagementEntities entities = new SelesManagementEntities();

        void list()
        {
            var categories = (from x in entities.TblCategories
                              select new
                              {
                                  x.cathegoryId,
                                  x.cathegoryName
                              }).ToList();
            dataGridView1.DataSource = categories;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblCategory category = new TblCategory();
                category.cathegoryName = txtName.Text;
                entities.TblCategories.Add(category);
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid values");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                var cat = entities.TblCategories.Find(id);
                cat.cathegoryName = txtName.Text;
                entities.SaveChanges();
                list();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the invalid values");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                var cat = entities.TblCategories.Find(id);
                entities.TblCategories.Remove(cat);
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
        }
    }
}
