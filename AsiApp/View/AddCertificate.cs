using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AsiWindows.View.Edit
{
    public partial class AddCertificate : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        public CertificateControlModel CertificateControl { get; set; }
        private List<PersonModel> _persons;
        private readonly int _lastId;
        private readonly CertificateModel _controlForm;
        private List<DepartmentModel> _departments;
        private List<CertificateTypeModel> _certificateTypes;
        private List<ProvinceModel> _provinces;
        private void SetControlRepeatTime(int controltime)
        {
            string repeatText = "بازرسی اول";
            if (controltime == 2)
                repeatText = "بازرسی دوم";
            else if (controltime == 3)
                repeatText = "بازرسی سوم";
            else if (controltime == 4)
                repeatText = "بازرسی چهارم";
            textBoxControlRepeat.Text = repeatText;
        }
        private int GetControlRepeatTime(string repeatText)
        {
            int repeat = 0;

            if (repeatText == "بازرسی اول")
                repeat = 1;

            else if (repeatText == "بازرسی دوم")
                repeat = 2;

            else if (repeatText == "بازرسی سوم")
                repeat = 3;
            else if (repeatText == "بازرسی چهارم")
                repeat = 4;
            return repeat;
        }
        private void LoadValues()
        {
            LoadDepartments();
            LoadCertificateTypes();
            LoadProvinces();
        }


        private void LoadProvinces()
        {
            _provinces = this._unit.Provinces.GetAll(1, 20).ToList();
            for (int i = 0; i < _provinces.Count; i++)
            {
                this.ComboboxProvince.Properties.Items.Add(_provinces[i].Title);
            }
        }

        private void LoadCertificateTypes()
        {
            _certificateTypes = this._unit.CertificateTypes.GetAll(1, 20).ToList();
            for (int i = 0; i < _certificateTypes.Count; i++)
            {
                this.ComboboxCertificateType.Properties.Items.Add(_certificateTypes[i].Title);
            }
        }

        private void LoadDepartments()
        {
            _departments = this._unit.Departments.GetAll(1, 20).ToList();
            for (int i = 0; i < _departments.Count; i++)
            {
                this.ComboboxDepartment.Properties.Items.Add(_departments[i].Title);
            }
        }

        //public AddCertificate(CertificateModel certificate)
        //{
        //    _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
        //    InitializeComponent();
        //    LoadCertificateData(certificate);
        //    LoadControls(certificate.Id);
        //}

        private void LoadControls(int id)
        {
            List<CertificateControlModel> completed = _unit.Certificates.GetControls(id);
            List<CertificateControlModel> uncompleted = _unit.Certificates.GetQeueControls(id);
            this.gridControl.DataSource = completed;
            this.gridControlUnComplete.DataSource = uncompleted;
        }

        private void LoadCertificateData(CertificateModel certificate)
        {
            this.label3.Text = certificate.RequestTime.ToLongDateString();
            this.ComboboxDepartment.Text = certificate.ServiceType;
            this.TextboxItem.Text = certificate.Item;
            this.ComboboxCertificateType.Text = certificate.CertificateType;
            this.ComboboxProvince.Text = certificate.Province;
            this.TextboxCompanyAddress.Text = certificate.Company.Address;
            this.TextboxCompanyName.Text = certificate.Company.Fullname;
            this.TextboxLinkName.Text = certificate.Company.PhoneNumber;
            LoadCertificateDataList(certificate.Id);
        }

        private void LoadCertificateDataList(int id)
        {
            List<CertificateControlModel> certificateControls = _unit.CertificateControls.GetAll(id);
            List<PaymentModel> payments = _unit.CertificatePayments.GetAll(id);
            this.gridControlUnComplete.DataSource = certificateControls;
            this.GridControlPayments.DataSource = payments;
        }

        public AddCertificate(CertificateModel controlFormSend)
        {

            this._controlForm = controlFormSend;
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
            _lastId = _unit.Certificates.LastId();
            // List<FormDataModel> formDataModels = _unit.Certificates.GetQeueControls(controlFormSend.QeueId.Value);
            InitializeComponent();
            gridView4.RowClick += ControlsSelection;
            //  this.GridControlControls.DataSource = formDataModels;
            //  LoadFormData(controlFormSend);
            LoadCertificateData(controlFormSend);
            this.LoadValues();
            this.ButtonSubmit.Click += ButtonSubmitRequestFirstControl_Click;
            this.LabelFileNumber.Text = string.Format("RS-{0}", _lastId);
            this.LabelCertificateNumber.Text = string.Format("ES-{0}", _lastId);
            //this.SetControlRepeatTime(controlFormSend.);
            this._persons = _unit.Persons.GetAll(1, 20);
            this.gridControl1.DataSource = _persons;

        }

        private void ControlsSelection(object sender, RowClickEventArgs e)
        {
            CertificateControlModel certificateControlModel = this.gridView4.GetFocusedRow() as CertificateControlModel;
            textBoxControlRepeat.Text = certificateControlModel.ControlTime;
            TextboxMainController.Text = certificateControlModel.MainControllerName;
            TextboxLinkName.Text = certificateControlModel.Link.Fullname;
            TextboxLinkPhoneNumber.Text = certificateControlModel.Link.PhoneNumber;
            this.CertificateControl = certificateControlModel;
        }

        private void LoadFormData(CertificateModel controlFormSend)
        {
            this.ComboboxProvince.Text = controlFormSend.Province;
            this.TextboxCompanyAddress.Text = controlFormSend.Company.Address;
            this.TextboxCompanyName.Text = controlFormSend.Company.Fullname;
            this.TextboxLinkName.Text = controlFormSend.Company.PhoneNumber;
            //this.TextboxRequestDate.Text = controlFormSend..ToString("yyyy/MM/dd");
        }

        private void ButtonSubmitRequestFirstControl_Click(object sender, EventArgs e)
        {

            // certificate.QeueId = _controlForm.QeueId;
            // certificate.Id = _controlForm.RefferenceId.Value;
            _controlForm.CertificationDate = this.DatePickerCertificationdate.Value;
            _controlForm.CertificateExpirationDate = this.DatepickerExpireDate.Value;
            //_controlForm.Company = new Company()
            //{
            //    Address = this.TextboxCompanyAddress.Text
            //    ,
            //    Fullname = this.TextboxCompanyName.Text
            //    ,
            //    PhoneNumber = this.TextboxLinkName.Text
            //};
            _controlForm.ProvinceId = this._provinces.Where(x => x.Title == ComboboxProvince.Text).Select(x => x.Id).FirstOrDefault();
           // _controlForm.ServiceTypeId = this._departments.Where(x => x.Title == ComboboxDepartment.Text).Select(x => x.Id).FirstOrDefault();
            //CertificateControlModel controlForm = new CertificateControlModel();
            //controlForm.ControlFormId = this._controlForm.ControlId;
            CertificateControl.Time = _controlForm.RequestTime;
            CertificateControl.ControlTime = this.textBoxControlRepeat.Text;
            CertificateControl.AgancyId = _persons.Where(x => x.Fullname == this.ButtonEditAgancy.Text).Select(x => x.Id).FirstOrDefault();
            CertificateControl.MarketingId = _persons.Where(x => x.Fullname == this.ButtonEditMarketer.Text).Select(x => x.Id).FirstOrDefault();
            CertificateControl.CertificateControllerId = _persons.Where(x => x.Fullname == this.ButtonEditCertificateController.Text).Select(x => x.Id).FirstOrDefault();
            CertificateControl.TechnicalManagerId = _persons.Where(x => x.Fullname == this.ButtonEditTechnicalController.Text).Select(x => x.Id).FirstOrDefault();
            
            CertificateControl.BranchId = _persons.Where(x => x.Fullname == this.ButtonEditBranch.Text).Select(x => x.Id).FirstOrDefault();
            List<CertificateControlModel> controlForms = new List<CertificateControlModel>();
            controlForms.Add(CertificateControl);
            _controlForm.Controls = controlForms;
            _unit.Certificates.SubmitCertificate(_controlForm);
        }

        private void ButtonEditTechnicalController_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.gridView1.RowClick += GridView1_RowClick_Select_Technical;
            this.gridView1.Tag = sender;
        }

        private void GridView1_RowClick_Select_Technical(object sender, RowClickEventArgs e)
        {
            this.gridView1.RowClick -= GridView1_RowClick_Select_Technical;
            PersonModel selectedUser = gridView1.GetFocusedRow() as PersonModel;
            (this.gridView1.Tag as ButtonEdit).Text = selectedUser.Fullname;
            (this.gridView1.Tag as ButtonEdit).Tag = selectedUser;
            this.gridView1.Tag = null;
            this.panel2.Visible = false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = this._persons.Where(x => x.Fullname.Contains((sender as TextBox).Text));
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonEditAgancy_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CertificateControlModel c = (this.gridView4.GetFocusedRow() as CertificateControlModel);
            string cordinate = string.Format("http://www.google.com/maps/place/{0},{1}", c.Location.Latitude, c.Location.Longtitude.ToString());
            Clipboard.SetText(string.Format("http://www.google.com/maps/place/{0},{1}", c.Location.Latitude, c.Location.Longtitude.ToString()));
            ProcessStartInfo sInfo = new ProcessStartInfo(cordinate);
            Process.Start(sInfo);
        }
    }
}