using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using System;

namespace AsiWindows.View.List
{
    public partial class CertificateTypeListPage : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        public CertificateTypeListPage()
        {
            InitializeComponent();
            this.Text = "انواع گواهینامه";
            _unit = (IV1BusinessUnit)Program.ServiceProvider.GetService(typeof(IV1BusinessUnit));
            LoadGridData();
        }

        private void LoadGridData()
        {
            this.gridControl1.DataSource = _unit.CertificateTypes.GetAll(1,20);
        }


        private void GridviewDeleteButton_Click(object sender, System.EventArgs e)
        {
            CertificateTypeModel departmentModel = gridView1.GetFocusedRow() as CertificateTypeModel;
            _unit.CertificateTypes.Delete(departmentModel.Id);
            LoadGridData();
        }

        private void ButtonRefresh_Click(object sender, System.EventArgs e)
        {
            LoadGridData();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CertificateTypeModel certificateTypeModel = this.gridView1.GetFocusedRow() as CertificateTypeModel;
            this.TextboxId.Text = certificateTypeModel.Id.ToString();
            this.TextboxTitle.Text = certificateTypeModel.Title;
            this.simpleButton2.Enabled = true;
        }

        private CertificateTypeModel GetValue()
        {
            return new CertificateTypeModel
            {
                Id = Convert.ToInt32(this.TextboxId.Text),
                Title = this.TextboxTitle.Text
            };
        }
        private void SetValue(CertificateTypeModel certificateType)
        {
            this.TextboxId.Text = certificateType.Id.ToString();
            this.TextboxTitle.Text = certificateType.Title;
        }
        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            this._unit.CertificateTypes.Update(GetValue());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this._unit.CertificateTypes.Create(GetValue());
        }
    }
}