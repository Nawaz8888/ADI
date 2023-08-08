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
    public partial class frmCustomer : Form
    {
        Database1Entities db = new Database1Entities();
         
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            var data = db.tblCustomers.OrderBy(x => x.Name).ToList();
            dgv.DataSource = data;
        }
    }
}
