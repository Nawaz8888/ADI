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
    public partial class frmUserRegister : Form
    {
        //List<userInfo> userlist = new List<userInfo>();

        Database1Entities db= new Database1Entities();
        public frmUserRegister()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var data = db.tblUsers.OrderBy(x=>x.UserName).ToList();
            dataGridView1.DataSource = data;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmUserRegister_Load(object sender, EventArgs e)
        {
            //userList = new List<userInfo>();
            LoadData();
        }

        private void btnSingUp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            string password= txtPass.Text;
            bool validPassword = password.Length >= 8
             && password.Any(char.IsLower)
             && password.Any(char.IsUpper);

            if (!validPassword && password!="")
            {
                sb.AppendLine("Password is not valid");
            }

            if (txtFullName.Text.Trim().Length==0)
            {
                sb.AppendLine("Please enter user's ful name");
            }

            if (txtUserName.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter user name");
            }

            if (txtPass.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter Password");
            }
            // confirm pass 

            if (txtConPass.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter confirm Password");
            }

            if (txtPass.Text.Trim() != txtConPass.Text.Trim())
            {
                sb.AppendLine("Sorry, Password and confirm Password does not mached!!  ");
            }

            if (sb.ToString() != String.Empty)
            {
                MessageBox.Show(sb.ToString(),"Error</>", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

           var dupliData= db.tblUsers.Where(u=>u.UserName == txtFullName.Text).FirstOrDefault();    
            if (dupliData!=null)
            {
                MessageBox.Show("User Name already Exist!!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // classname obj new constructor  
            tblUser user = new tblUser();

            user.FullName = txtFullName.Text;
            user.UserName = txtUserName.Text;
            user.UserName=txtUserName.Text;
            user.Password= txtPass.Text;
            user.UserType = "Customer";

            db.tblUsers.Add(user);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Data saved Successfully ...");

        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked == false)
            {
                txtPass.UseSystemPasswordChar = true;   
                txtConPass.UseSystemPasswordChar = true;
            }

            else
            {
                txtPass.UseSystemPasswordChar = false;
                txtConPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtUserName.Clear();
            txtPass.Clear();
            txtConPass.Clear();
        }


        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login frm=new Login();
            frm.ShowDialog();
        }
    }
}
