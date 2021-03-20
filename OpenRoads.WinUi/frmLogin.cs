using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoads.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _service = new APIService("Employee");

        public frmLogin()
        {
            InitializeComponent();
        }

       

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;

                try
                {
                    EmployeeSearchRequest request = new EmployeeSearchRequest
                    {
                        Username = APIService.Username
                    };

                    var obj = await _service.Get<List<EmployeeModel>>(request);
                    if(obj == null)
                        MessageBox.Show("Invalid username or password!", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        frmIndex frm = new frmIndex();
                        frm.Show();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Invalid username or password!", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtUsername, e, errorProvider1);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtPassword, e, errorProvider1);
        }
    }
}
