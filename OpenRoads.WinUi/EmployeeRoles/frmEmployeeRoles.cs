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

namespace OpenRoads.WinUI.EmployeeRoles
{
    public partial class frmEmployeeRoles : Form
    {
        private readonly APIService _employeeRolesService = new APIService("EmployeeRoles");

        public frmEmployeeRoles()
        {
            InitializeComponent();
        }




        private class EmployeeRolesToDisplay
        {
            public int EmployeeRolesId { get; set; }
            public string RolesName { get; set; }
            public string Description { get; set; }
        }

        private async void frmEmployeeRoles_Load(object sender, EventArgs e)
        {
            List<EmployeeRolesToDisplay> roles = new List<EmployeeRolesToDisplay>();

            var emplRoles = await _employeeRolesService.Get<List<EmployeeRolesModel>>(null);

            foreach (var x in emplRoles)
            {
                roles.Add(new EmployeeRolesToDisplay
                {
                    EmployeeRolesId = x.EmployeeRolesId,
                    Description = x.Description,
                    RolesName = x.Name
                });
            }

            dgvEmployeeRoles.AutoGenerateColumns = false;
            dgvEmployeeRoles.DataSource = roles;
        }

        private void dgvEmployeeRoles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var employeRolesID = dgvEmployeeRoles.SelectedRows[0].Cells[0].Value;
            frmAddUpdateEmployeeRoles frm = new frmAddUpdateEmployeeRoles(int.Parse(employeRolesID.ToString()));
            frm.Show();
        }
    }
}
