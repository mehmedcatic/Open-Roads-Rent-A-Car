using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenRoads.WinUi.Analytics;
using OpenRoads.WinUI.Branch;
using OpenRoads.WinUI.Client;
using OpenRoads.WinUI.Country;
using OpenRoads.WinUI.Employee;
using OpenRoads.WinUI.EmployeeRoles;
using OpenRoads.WinUI.Insurance;
using OpenRoads.WinUI.Rating;
using OpenRoads.WinUI.Reservation;
using OpenRoads.WinUI.Vehicle;
using OpenRoads.WinUI.VehicleCategory;
using OpenRoads.WinUI.VehicleFuelType;
using OpenRoads.WinUI.VehicleManufacturer;
using OpenRoads.WinUI.VehicleModel;
using OpenRoads.WinUI.VehicleTransmissionType;
using OpenRoads.WinUI.VehicleType;


namespace OpenRoads.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }



        private const string Branches = "Branches",
            Clients = "Clients",
            Countries = "Countries",
            EmployeeRoles = "EmployeeRoles",
            Employees = "Employees",
            Insurance = "Insurance",
            Ratings = "Ratings",
            Reservations = "Reservations",
            VehicleCategories = "VehicleCategories",
            VehicleFuelTypes = "VehicleFuelTypes",
            VehicleManufacturers = "VehicleManufacturers",
            VehicleModels = "VehicleModels",
            Vehicles = "Vehicles",
            VehicleTransmissionTypes = "VehicleTransmissionTypes",
            VehicleTypes = "VehicleTypes",
            VehicleReports = "VehicleReports";


        private void GenerateContentForClickItems(string formName, bool clickForSearch)
        {
            if (formName == VehicleReports)
            {
                frmVehiclesReport frm = new frmVehiclesReport();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

            if (formName == Branches)
            {
                if (clickForSearch)
                {
                    frmBranch frm = new frmBranch();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateBranch frm = new frmAddUpdateBranch();
                    frm.Show();
                }
            }

            if (formName == Clients)
            {
                if (clickForSearch)
                {
                    frmClient frm = new frmClient();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateClient frm = new frmAddUpdateClient();
                    frm.Show();
                }
            }

            if (formName == Countries)
            {
                if (clickForSearch)
                {
                    frmCountries frm = new frmCountries();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddCountry frm = new frmAddCountry();
                    frm.Show();
                }
            }

            if (formName == Employees)
            {
                if (clickForSearch)
                {
                    frmEmployees frm = new frmEmployees();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
                    frm.Show();
                }
            }

            if (formName == EmployeeRoles)
            {
                if (clickForSearch)
                {
                    frmEmployeeRoles frm = new frmEmployeeRoles();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateEmployeeRoles frm = new frmAddUpdateEmployeeRoles();
                    frm.Show();
                }
            }

            if (formName == Insurance)
            {
                if (clickForSearch)
                {
                    frmInsurance frm = new frmInsurance();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateInsurance frm = new frmAddUpdateInsurance();
                    frm.Show();
                }
            }

            if (formName == Ratings)
            {
                if (clickForSearch)
                {
                    frmRating frm = new frmRating();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
            }

            if (formName == Reservations)
            {
                if (clickForSearch)
                {
                    frmReservation frm = new frmReservation();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
            }

            if (formName == VehicleCategories)
            {
                if (clickForSearch)
                {
                    frmVehicleCategory frm = new frmVehicleCategory();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVehicleCategory frm = new frmAddUpdateVehicleCategory();
                    frm.Show();
                }
            }

            if (formName == Vehicles)
            {
                if (clickForSearch)
                {
                    frmVehicle frm = new frmVehicle();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
                    frm.Show();
                }
            }

            if (formName == VehicleFuelTypes)
            {
                if (clickForSearch)
                {
                    frmVehicleFuelType frm = new frmVehicleFuelType();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVFuelType frm = new frmAddUpdateVFuelType();
                    frm.Show();
                }
            }

            if (formName == VehicleManufacturers)
            {
                if (clickForSearch)
                {
                    frmVehicleManufacturer frm = new frmVehicleManufacturer();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVehicleManufacturer frm = new frmAddUpdateVehicleManufacturer();
                    frm.Show();
                }
            }

            if (formName == VehicleModels)
            {
                if (clickForSearch)
                {
                    frmVehicleModel frm = new frmVehicleModel();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVehicleModel frm = new frmAddUpdateVehicleModel();
                    frm.Show();
                }
            }

            if (formName == VehicleTransmissionTypes)
            {
                if (clickForSearch)
                {
                    frmVehicleTransmissionType frm = new frmVehicleTransmissionType();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVehicleTransmissionType frm = new frmAddUpdateVehicleTransmissionType();
                    frm.Show();
                }
            }

            if (formName == VehicleTypes)
            {
                if (clickForSearch)
                {
                    frmVehicleType frm = new frmVehicleType();

                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    frmAddUpdateVehicleType frm = new frmAddUpdateVehicleType();
                    frm.Show();
                }
            }
        }


        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Employees, true);
        }

        private void newEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Employees, false);
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Countries, true);
        }

        private void newCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Countries, false);
        }

        private void searchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Insurance, true);
        }

        private void newInsuranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Insurance, false);
        }

        private void searchToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Ratings, true);
        }

        private void searchToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Branches, true);
        }

        private void newBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Branches, false);
        }

        private void searchToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Clients, true);
        }

        private void searchToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(EmployeeRoles, true);
        }

        private void newRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(EmployeeRoles, false);
        }

        private void searchToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Reservations, true);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleReports, false);
        }

        private void searchToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleCategories, true);
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleCategories, false);
        }

        private void searchToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleTransmissionTypes, true);
        }

        private void newTransmissionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleTransmissionTypes, false);

        }

        private void searchToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleManufacturers, true);
        }

        private void newManufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleManufacturers, false);
        }

        private void searchToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleFuelTypes, true);
        }

        private void newTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleFuelTypes, false);

        }

        private void searchToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleTypes, true);
        }

        private void newTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleTypes, false);
        }

        private void searchToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleModels, true);
        }

        private void newModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(VehicleModels, false);
        }

        private void searchToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Vehicles, true);
        }

        private void newVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateContentForClickItems(Vehicles, false);
        }
    }
}
