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
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.Employee
{
    public partial class frmEmployees : Form
    {
        private readonly APIService _employeeService = new APIService("Employee");
        private readonly APIService _branchService = new APIService("Branch");
        private readonly APIService _employeeRolesService = new APIService("EmployeeRoles");
        private readonly APIService _personService = new APIService("Person");


        public frmEmployees()
        {
            InitializeComponent();
        }




        private async void frmEmployees_Load(object sender, EventArgs e)
        {
            await LoadBranch();
            await LoadEmployeeRoles();
            await LoadEmployees();
        }

        private async Task LoadBranch()
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbBranch, _branchService, "BranchModel");
        }

        private async Task LoadEmployeeRoles()
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbEmployeeRoles, _employeeRolesService, "EmployeeRolesModel");
        }

        private class EmployeeToDisplay
        {
            public string FullName { get; set; }
            public int EmployeeId { get; set; }
            public int PersonId { get; set; }
            public int BranchId { get; set; }
            public string BranchName { get; set; }
            public string JobDescription { get; set; }
            public DateTime HireDate { get; set; }
            public string EmployeeCode { get; set; }
            //public int EmployeeRolesId { get; set; }
        }

        private List<EmployeeToDisplay> GenerateResult(List<EmployeeModel> employeeList, 
            List<BranchModel> branchList, List<PersonModel> personList)
        {
            List<EmployeeToDisplay> result = new List<EmployeeToDisplay>();
            foreach (var y in employeeList)
            {
                foreach (var x in personList)
                {
                    if (x.PersonId == y.PersonId)
                    {
                        result.Add(new EmployeeToDisplay
                        {
                            BranchId = y.BranchId,
                            EmployeeCode = y.EmployeeCode,
                            EmployeeId = y.EmployeeId,
                            FullName = x.FirstName + " " + x.LastName,
                            HireDate = y.HireDate,
                            JobDescription = y.JobDescription,
                            PersonId = y.PersonId 
                        });
                    }
                }
            }

            foreach (var z in result)
            {
                foreach (var b in branchList)
                {
                    if (z.BranchId == b.BranchId)
                        z.BranchName = b.FullName;
                }
            }

            return result;
        }

        private async Task LoadEmployees(int branchId = 0, int rolesId = 0)
        {
            var personList = await _personService.Get<List<PersonModel>>(null);
            var branchList = await _branchService.Get<List<BranchModel>>(null);

            if (branchId != 0 || rolesId != 0)
            {
                var request = new EmployeeSearchRequest();
                if (branchId != 0)
                    request.BranchId = branchId;
                if (rolesId != 0)
                    request.EmployeeRolesId = rolesId;

                var employeeList = await _employeeService.Get<List<EmployeeModel>>(request);

                var result = GenerateResult(employeeList, branchList, personList);

                dgvEmployees.AutoGenerateColumns = false;
                dgvEmployees.DataSource = result;
            }
            else
            {
                var employeeList = await _employeeService.Get<List<EmployeeModel>>(null);

                var result = GenerateResult(employeeList, branchList, personList);

                dgvEmployees.AutoGenerateColumns = false;
                dgvEmployees.DataSource = result;
            }

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var branchId = cmbBranch.SelectedValue;
            if (int.TryParse(branchId.ToString(), out int Bid))
            {
                var rolesId = cmbEmployeeRoles.SelectedValue;
                if (int.TryParse(rolesId.ToString(), out int Rid))
                {
                    await LoadEmployees(Bid, Rid);
                }
                else
                {
                    await LoadEmployees(Bid, 0);
                }
            }
            else
            {
                var rolesId = cmbEmployeeRoles.SelectedValue;
                if (int.TryParse(rolesId.ToString(), out int Rid))
                {
                    await LoadEmployees(0, Rid);
                }
                else
                {
                    await LoadEmployees();
                }
            }
        }

        private void dgvEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var employeeID = dgvEmployees.SelectedRows[0].Cells[0].Value;
            var branchID = dgvEmployees.SelectedRows[0].Cells[1].Value;
            var personID = dgvEmployees.SelectedRows[0].Cells[2].Value;

            frmAddUpdateEmployee frm = new frmAddUpdateEmployee(int.Parse(employeeID.ToString()), int.Parse(branchID.ToString()),
                int.Parse(personID.ToString()));
            frm.Show();
        }

        private async void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = await VFormBaseMethods.DeleteContentOnCellClick<EmployeeModel>(dgvEmployees, e, 
                WinFormModelTypesList.ModelTypes.EmployeeModel.ToString());
            if (result != null)
                await LoadEmployees();
        }
    }
}
