using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoads.WinUI.VehicleCategory;
using OpenRoads.WinUI.VehicleFuelType;
using OpenRoads.WinUI.VehicleManufacturer;
using OpenRoads.WinUI.VehicleTransmissionType;
using OpenRoads.WinUI.VehicleType;
using OpenRoads.WinUI.WFHelpers;


namespace OpenRoads.WinUI
{
    public static class VFormBaseMethods
    {


        //ALL MODEL TYPES IN DB
        private enum ModelTypes
        {
            BranchModel,
            ClientModel,
            CountryModel,
            EmployeeEmployeeRolesModel,
            EmployeeModel,
            EmployeeRolesModel,
            InsuranceModel,
            LoginDataModel,
            PersonModel,
            RatingModel,
            ReservationModel,
            VehicleCategoryModel,
            VehicleFuelTypeModel,
            VehicleManufacturerModel,
            VehicleModel,
            VehicleModelModel,
            VehicleTransmissionTypeModel,
            VehicleTypeModel
        }



        private static readonly APIService _vehicleCategoryService = new APIService("VehicleCategory");
        private static readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private static readonly APIService _vehicleTransmissionService = new APIService("VehicleTransmissionType");
        private static readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private static readonly APIService _vehicleFuelService = new APIService("VehicleFuelType");
        private static readonly APIService _vehicleTypeService = new APIService("VehicleType");
        private static readonly APIService _branchService = new APIService("Branch");
        private static readonly APIService _employeeService = new APIService("Employee");
        private static readonly APIService _vehicleService = new APIService("Vehicle");



        //LOAD DATA TO COMBOBOXES IN FORM DISPLAY

        public static async Task LoadAssetToComboBox(ComboBox cmb, APIService service, string ModelType)
        {
            if (ModelType == ModelTypes.BranchModel.ToString())
            {
                var result = await service.Get<List<BranchModel>>(null);
                result.Insert(0, new BranchModel());
                cmb.DisplayMember = "FullName";
                cmb.ValueMember = "BranchId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.CountryModel.ToString())
            {
                var result = await service.Get<List<CountryModel>>(null);
                result.Insert(0, new CountryModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "CountryId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.EmployeeRolesModel.ToString())
            {
                var result = await service.Get<List<EmployeeRolesModel>>(null);
                result.Insert(0, new EmployeeRolesModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "EmployeeRolesId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleManufacturerModel.ToString())
            {
                var result = await service.Get<List<VehicleManufacturerModel>>(null);
                result.Insert(0, new VehicleManufacturerModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VehicleManufacturerId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleTransmissionTypeModel.ToString())
            {
                var result = await service.Get<List<VehicleTransmissionTypeModel>>(null);
                result.Insert(0, new VehicleTransmissionTypeModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VehicleTransmissionTypeId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleFuelTypeModel.ToString())
            {
                var result = await service.Get<List<VehicleFuelTypeModel>>(null);
                result.Insert(0, new VehicleFuelTypeModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VehicleFuelTypeId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleCategoryModel.ToString())
            {
                var result = await service.Get<List<VehicleCategoryModel>>(null);
                result.Insert(0, new VehicleCategoryModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VehicleCategoryId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleTypeModel.ToString())
            {
                var result = await service.Get<List<VehicleTypeModel>>(null);
                result.Insert(0, new VehicleTypeModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VehicleTypeId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleModelModel.ToString())
            {
                var result = await service.Get<List<VehicleModelModel>>(null);
                result.Insert(0, new VehicleModelModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VehicleModelId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.InsuranceModel.ToString())
            {
                var result = await service.Get<List<InsuranceModel>>(null);
                result.Insert(0, new InsuranceModel());
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "InsuranceId";
                cmb.DataSource = result;
            }

            if (ModelType == ModelTypes.VehicleModel.ToString())
            {
                var vehicles = await service.Get<List<OpenRoads.Model.VehicleModel>>(null);
                //vehicles.Insert(0, new Model.VehicleModel());
                var models = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
                var manufacturers = await _vehicleManufacturerService
                    .Get<System.Collections.Generic.List<VehicleManufacturerModel>>(null);
                List<VehicleForCombo> displayVehicles = new List<VehicleForCombo>();

                foreach (var x in vehicles)
                {
                    foreach (var y in models)
                    {
                        if (x.VehicleModelId == y.VehicleModelId)
                        {
                            foreach (var z in manufacturers)
                            {
                                if (y.VehicleManufacturerId == z.VehicleManufacturerId)
                                {
                                    displayVehicles.Add(new VehicleForCombo
                                    {
                                        VehicleName = z.Name + " " + y.Name,
                                        VehicleId = x.VehicleId
                                    });
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                displayVehicles.Insert(0, new VehicleForCombo());
                cmb.DisplayMember = "VehicleName";
                cmb.ValueMember = "VehicleId";
                cmb.DataSource = displayVehicles;
            }
        }

        private class VehicleForCombo
        {
            public int VehicleId { get; set; }
            public string VehicleName { get; set; }
        }





        //BASE VEHICLE REFERENCE MODELS FORM
        private class ClassToDisplay
        {
            public int TypeId { get; set; }
            public string TypeName { get; set; }
        }


        public static void baseFormForVehicleReferenceModelsLoad(WinFormModelTypesList.ModelTypes typeModel,
            DataGridView dgv, List<VehicleCategoryModel> objectsCategories, List<VehicleFuelTypeModel> objectsFuel,
            List<VehicleTypeModel> objectsType, List<VehicleManufacturerModel> objectsManufacturers,
            List<VehicleTransmissionTypeModel> objectsTransmission)
        {
            if (typeModel.ToString() == ModelTypes.VehicleCategoryModel.ToString())
            {
                List<ClassToDisplay> objectsToDisplay = new List<ClassToDisplay>();

                foreach (var x in objectsCategories)
                {
                    objectsToDisplay.Add(new ClassToDisplay
                    {
                        TypeId = x.VehicleCategoryId,
                        TypeName = x.Name
                    });
                }

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = objectsToDisplay;
            }

            if (typeModel.ToString() == ModelTypes.VehicleFuelTypeModel.ToString())
            {
                List<ClassToDisplay> objectsToDisplay = new List<ClassToDisplay>();

                foreach (var x in objectsFuel)
                {
                    objectsToDisplay.Add(new ClassToDisplay
                    {
                        TypeId = x.VehicleFuelTypeId,
                        TypeName = x.Name
                    });
                }

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = objectsToDisplay;
            }

            if (typeModel.ToString() == ModelTypes.VehicleManufacturerModel.ToString())
            {
                List<ClassToDisplay> objectsToDisplay = new List<ClassToDisplay>();

                foreach (var x in objectsManufacturers)
                {
                    objectsToDisplay.Add(new ClassToDisplay
                    {
                        TypeId = x.VehicleManufacturerId,
                        TypeName = x.Name
                    });
                }

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = objectsToDisplay;
            }

            if (typeModel.ToString() == ModelTypes.VehicleTransmissionTypeModel.ToString())
            {
                List<ClassToDisplay> objectsToDisplay = new List<ClassToDisplay>();

                foreach (var x in objectsTransmission)
                {
                    objectsToDisplay.Add(new ClassToDisplay
                    {
                        TypeId = x.VehicleTransmissionTypeId,
                        TypeName = x.Name
                    });
                }

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = objectsToDisplay;
            }

            if (typeModel.ToString() == ModelTypes.VehicleTypeModel.ToString())
            {
                List<ClassToDisplay> objectsToDisplay = new List<ClassToDisplay>();

                foreach (var x in objectsType)
                {
                    objectsToDisplay.Add(new ClassToDisplay
                    {
                        TypeId = x.VehicleTypeId,
                        TypeName = x.Name
                    });
                }

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = objectsToDisplay;
            }

        }


        public static void MouseDoubleClick(WinFormModelTypesList.ModelTypes typeModel, DataGridView dgv)
        {
            var typeID = dgv.SelectedRows[0].Cells[0].Value;


            if (typeModel.ToString() == ModelTypes.VehicleCategoryModel.ToString())
            {
                frmAddUpdateVehicleCategory frm = new frmAddUpdateVehicleCategory(int.Parse(typeID.ToString()));
                frm.Show();
            }

            if (typeModel.ToString() == ModelTypes.VehicleFuelTypeModel.ToString())
            {
                frmAddUpdateVFuelType frm = new frmAddUpdateVFuelType(int.Parse(typeID.ToString()));
                frm.Show();
            }

            if (typeModel.ToString() == ModelTypes.VehicleManufacturerModel.ToString())
            {
                frmAddUpdateVehicleManufacturer frm = new frmAddUpdateVehicleManufacturer(int.Parse(typeID.ToString()));
                frm.Show();
            }

            if (typeModel.ToString() == ModelTypes.VehicleTransmissionTypeModel.ToString())
            {
                frmAddUpdateVehicleTransmissionType frm = new frmAddUpdateVehicleTransmissionType(int.Parse(typeID.ToString()));
                frm.Show();
            }

            if (typeModel.ToString() == ModelTypes.VehicleTypeModel.ToString())
            {
                frmAddUpdateVehicleType frm = new frmAddUpdateVehicleType(int.Parse(typeID.ToString()));
                frm.Show();
            }
        }




        //ADD || UPDATE REFERENCE VEHICLE TABLES

        public static async void AddOrUpdateModel(int? id, TextBox txtBox, WinFormModelTypesList.ModelTypes typeModel)
        {
            if (id.HasValue)
            {

                if (typeModel.ToString() == ModelTypes.VehicleCategoryModel.ToString())
                {
                    var entity = await _vehicleCategoryService.GetById<VehicleCategoryModel>(int.Parse(id.ToString()));
                    txtBox.Text = entity.Name;
                }
                if (typeModel.ToString() == ModelTypes.VehicleManufacturerModel.ToString())
                {
                    var entity = await _vehicleManufacturerService.GetById<VehicleManufacturerModel>(int.Parse(id.ToString()));
                    txtBox.Text = entity.Name;
                }
                if (typeModel.ToString() == ModelTypes.VehicleFuelTypeModel.ToString())
                {
                    var entity = await _vehicleFuelService.GetById<VehicleFuelTypeModel>(int.Parse(id.ToString()));
                    txtBox.Text = entity.Name;
                }
                if (typeModel.ToString() == ModelTypes.VehicleTransmissionTypeModel.ToString())
                {
                    var entity = await _vehicleTransmissionService.GetById<VehicleTransmissionTypeModel>(int.Parse(id.ToString()));
                    txtBox.Text = entity.Name;
                }
                if (typeModel.ToString() == ModelTypes.VehicleTypeModel.ToString())
                {
                    var entity = await _vehicleTypeService.GetById<VehicleTypeModel>(int.Parse(id.ToString()));
                    txtBox.Text = entity.Name;
                }
            }
        }

        public static async void BtnSubmitModel(int? id, TextBox txtBox, WinFormModelTypesList.ModelTypes typeModel)
        {

            var request = new VehicleReferenceTableAddUpdateRequest
            {
                Name = txtBox.Text
            };


            if (typeModel.ToString() == ModelTypes.VehicleCategoryModel.ToString())
            {
                VehicleCategoryModel entity = null;

                if (id.HasValue)
                {
                    entity = await _vehicleCategoryService.Update<VehicleCategoryModel>(int.Parse(id.ToString()), request);
                }
                else
                {
                    entity = await _vehicleCategoryService.Insert<VehicleCategoryModel>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }

            if (typeModel.ToString() == ModelTypes.VehicleManufacturerModel.ToString())
            {
                VehicleManufacturerModel entity = null;

                if (id.HasValue)
                {
                    entity = await _vehicleManufacturerService.Update<VehicleManufacturerModel>(int.Parse(id.ToString()), request);
                }
                else
                {
                    entity = await _vehicleManufacturerService.Insert<VehicleManufacturerModel>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }

            if (typeModel.ToString() == ModelTypes.VehicleFuelTypeModel.ToString())
            {
                VehicleFuelTypeModel entity = null;

                if (id.HasValue)
                {
                    entity = await _vehicleFuelService.Update<VehicleFuelTypeModel>(int.Parse(id.ToString()), request);
                }
                else
                {
                    entity = await _vehicleFuelService.Insert<VehicleFuelTypeModel>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }

            if (typeModel.ToString() == ModelTypes.VehicleTransmissionTypeModel.ToString())
            {
                VehicleTransmissionTypeModel entity = null;

                if (id.HasValue)
                {
                    entity = await _vehicleTransmissionService.Update<VehicleTransmissionTypeModel>(int.Parse(id.ToString()), request);
                }
                else
                {
                    entity = await _vehicleTransmissionService.Insert<VehicleTransmissionTypeModel>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }

            if (typeModel.ToString() == ModelTypes.VehicleTypeModel.ToString())
            {
                VehicleTypeModel entity = null;

                if (id.HasValue)
                {
                    entity = await _vehicleTypeService.Update<VehicleTypeModel>(int.Parse(id.ToString()), request);
                }
                else
                {
                    entity = await _vehicleTypeService.Insert<VehicleTypeModel>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }
        }




        //DELETE CONTENT ON CELL CLICK
        public static async Task<T> DeleteContentOnCellClick<T>(DataGridView dgv, DataGridViewCellEventArgs e, 
            string deleteType) where T : class
        {
            if (e.ColumnIndex == 8)
            {
                if (MessageBox.Show("This action can't be undone. Are you sure you want to proceed?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var bId = dgv.SelectedRows[0].Cells[0].Value;
                    int.TryParse(bId.ToString(), out int assetID);
                    if (assetID != 0)
                    {
                        if (deleteType == ModelTypes.BranchModel.ToString())
                        {
                            var result = await _branchService.Delete<BranchModel>(assetID);
                            if (result != null)
                            {
                                if (result.Active == false)
                                {
                                    MessageBox.Show("Success!");
                                    return result as T;
                                }
                            }
                        }

                        if (deleteType == ModelTypes.EmployeeModel.ToString())
                        {
                            var result = await _employeeService.Delete<EmployeeModel>(assetID);
                            if (result != null)
                            {
                                if (result.Active == false)
                                {
                                    MessageBox.Show("Success!");
                                    return result as T;
                                }
                            }
                        }
                    }
                }
            }

            if (e.ColumnIndex == 9)
            {
                if (MessageBox.Show("This action can't be undone. Are you sure you want to proceed?", "Warning",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var bId = dgv.SelectedRows[0].Cells[0].Value;
                    int.TryParse(bId.ToString(), out int assetID);
                    if (assetID != 0)
                    {
                        if (deleteType == ModelTypes.VehicleModel.ToString())
                        {
                            var result = await _vehicleService.Delete<OpenRoads.Model.VehicleModel>(assetID);
                            if (result != null)
                            {
                                if (result.Active == false)
                                {
                                    MessageBox.Show("Success!");
                                    return result as T;
                                }
                            }
                        }
                    }
                }
            }

            return default;
        }
    }
}
