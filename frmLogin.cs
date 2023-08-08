using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADI_Class_one
{
    public partial class Login : Form
    {
        Database1Entities db= new Database1Entities();
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmUserRegister frm = new frmUserRegister();
            frm.ShowDialog();   
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var data = db.tblUsers.Where(u => u.UserName == txtUserName.Text && u.Password == txtPass.Text).FirstOrDefault();

            if (data !=null)
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.ShowDialog();

                userInfo.Id=data.Id;
                userInfo.Fullname = data.FullName;
                userInfo.username = data.UserName;
                userInfo.password = data.Password;  
            }

            else
            {
                MessageBox.Show("Invalid User!!"," Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
