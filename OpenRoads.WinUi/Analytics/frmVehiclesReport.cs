using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoads.WinUI;
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUi.Analytics
{
    public partial class frmVehiclesReport : Form
    {
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _reservationService = new APIService("Reservation");

        public frmVehiclesReport()
        {
            InitializeComponent();
        }

        private void LoadYears()
        {
            var currentYear = DateTime.Now.Year;
            var startingYear = 2019;
            for (int i = startingYear; i <= currentYear; i++)
            {
                cmbYear.Items.Add(i);
            }
            cmbYear.Items.Insert(0, "");
        }

        private class ReservationToDisplay
        {
            public int ReservationId { get; set; }
            public int VehicleId { get; set; }

            public string VehicleManufacturer { get; set; }
            public float ReservationPrice { get; set; }
            public int ReservationYear { get; set; }
            public float TotalPrice { get; set; }
        }

        private List<ReservationToDisplay> GenerateResult(List<ReservationModel> reservationsList, List<Model.VehicleModel> vehiclesList,
            List<VehicleManufacturerModel> vehicleManufacturerList, List<Model.VehicleModelModel> vehicleModelList)
        {
            List<ReservationToDisplay> result = new List<ReservationToDisplay>();

            foreach (var x in reservationsList)
            {
                ReservationToDisplay newReservation = new ReservationToDisplay();
                newReservation.VehicleId = x.VehicleId;
                newReservation.ReservationId = x.ReservationId;
                newReservation.ReservationPrice = x.Price;
                newReservation.ReservationYear = x.DateFrom.Year;
                newReservation.TotalPrice = 0;

                foreach (var vehicle in vehiclesList)
                {
                    if (vehicle.VehicleId == x.VehicleId)
                    {
                        foreach (var model in vehicleModelList)
                        {
                            if (vehicle.VehicleModelId == model.VehicleModelId)
                            {
                                foreach (var manufacturer in vehicleManufacturerList)
                                {
                                    if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                                    {
                                        newReservation.VehicleManufacturer = manufacturer.Name;
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        break;
                    }
                }
                result.Add(newReservation);
            }

            return result;
        }

        private async Task LoadReservations(int vehicleManufacturerId = 0, int year = 0)
        {
            var vehicleList = await _vehicleService.Get<List<Model.VehicleModel>>(null);
            var vehicleManufacturerList = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);
            var vehicleModelList = await _vehicleModelService.Get<List<Model.VehicleModelModel>>(null);

            if (vehicleManufacturerId != 0 || year != 0)
            {
                var request = new ReservationSearchRequest();
                if (vehicleManufacturerId != 0)
                    request.VehicleManufacturerId = vehicleManufacturerId;
                if (year != 0)
                    request.ReservationYear = year;

                var reservationsList = await _reservationService.Get<List<ReservationModel>>(request);

                var result = GenerateResult(reservationsList, vehicleList, vehicleManufacturerList, vehicleModelList);

                foreach (var x in result)
                {
                    foreach (var y in result)
                    {
                        if (x.ReservationYear == y.ReservationYear)
                            x.TotalPrice += y.ReservationPrice;
                    }
                }

                dgvDisplay.AutoGenerateColumns = false;
                dgvDisplay.DataSource = result;
            }
            else
            {
                var reservationsList = await _reservationService.Get<List<ReservationModel>>(null);

                var result = GenerateResult(reservationsList, vehicleList, vehicleManufacturerList, vehicleModelList);

                foreach (var x in result)
                {
                    foreach (var y in result)
                    {
                        if (x.ReservationYear == y.ReservationYear)
                            x.TotalPrice += y.ReservationPrice;
                    }
                }

                dgvDisplay.AutoGenerateColumns = false;
                dgvDisplay.DataSource = result;
            }
        }

        private async void frmVehiclesReport_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbVehicleManufacturer, _vehicleManufacturerService,
                WinFormModelTypesList.ModelTypes.VehicleManufacturerModel.ToString());
            LoadYears();

            //await LoadReservations();
        }

        private void setCharVals()
        {
            chart1.DataSource = dgvDisplay.DataSource;
            chart1.Series["ReservationYear"].XValueMember = "ReservationYear";
            chart1.Series["ReservationYear"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

            chart1.Series["ReservationYear"].YValueMembers = "TotalPrice";
            chart1.Series["ReservationYear"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var vmId = cmbVehicleManufacturer.SelectedValue;
            var yId = cmbYear.SelectedItem;

            if (yId == null)
                yId = 0;
            if (vmId == null)
                vmId = 0;

            int.TryParse(vmId.ToString(), out int vehicleManufacturerId);
            int.TryParse(yId.ToString(), out int year);

            if (vehicleManufacturerId != 0 && year != 0)
                await LoadReservations(vehicleManufacturerId, year);
            if (vehicleManufacturerId != 0 && year == 0)
                await LoadReservations(vehicleManufacturerId, 0);
            if (vehicleManufacturerId == 0 && year != 0)
                await LoadReservations(0, year);
            if (vehicleManufacturerId == 0 && year == 0)
                await LoadReservations();

            setCharVals();
        }


        public void exportGridToPdf(DataGridView dgw, string fileName)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfptable = new PdfPTable(dgw.Columns.Count);

            pdfptable.DefaultCell.Padding = 3;
            pdfptable.WidthPercentage = 100;
            pdfptable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfptable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            //header
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfptable.AddCell(cell);
            }


            //datarow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfptable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = fileName;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfptable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportGridToPdf(dgvDisplay, "VehiclesReport" + DateTime.Now.ToString());
        }
    }
}
