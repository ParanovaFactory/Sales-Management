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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SelesManagementEntities entities = new SelesManagementEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var login = from x in entities.TblAdmins where x.adminUserName == txtUserName.Text && x.adminPassword == txtPassword.Text select x;
                if (login.Any())
                {
                    main main = new main();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User name of parrword wrong");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Entered the invalid values");
                throw;
            }
        }
    }
}
