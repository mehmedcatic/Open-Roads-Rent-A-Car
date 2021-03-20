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

namespace OpenRoads.WinUI.Insurance
{
    public partial class frmInsurance : Form
    {
        private readonly APIService _insuranceService = new APIService("Insurance");


        public frmInsurance()
        {
            InitializeComponent();
        }



        private async void frmInsurance_Load(object sender, EventArgs e)
        {
            var result = await _insuranceService.Get<List<InsuranceModel>>(null);

            dgvInsurance.AutoGenerateColumns = false;
            dgvInsurance.DataSource = result;
        }

        private void dgvInsurance_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var insuranceID = dgvInsurance.SelectedRows[0].Cells[0].Value;
           
            frmAddUpdateInsurance frm = new frmAddUpdateInsurance(int.Parse(insuranceID.ToString()));
            frm.Show();
        }
    }
}
