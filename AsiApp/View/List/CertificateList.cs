using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiWindows.View.Edit;
using System;
using System.Collections.Generic;

namespace AsiApp.View.List
{
    public partial class CertificateList : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        List<CertificateModel> Certificates { get;  set; }  
        public enum Status
        {
            None,
            UnComplete,
            Expired
        }
        public CertificateList(Status status)
        {
            Certificates = new List<CertificateModel>();
           
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as  IV1BusinessUnit;
            InitializeComponent();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            if (status == Status.UnComplete)
            {
                this.comboBox1.SelectedIndex = 0;
                Certificates = _unit.Certificates.GetUnsubmittedForms(1,20);
                colSubmit.VisibleIndex = 0;
                colSubmit.Caption = string.Empty;
                colSubmit.Visible = true;
            }
            
            this.gridControl1.DataSource = Certificates;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.colSubmit.Visible =(comboBox1.Text == Status.UnComplete.ToString());
               
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            CertificateModel certificate = this.gridView1.GetFocusedRow() as CertificateModel;
            AddCertificate addCertificate = new AddCertificate(certificate);
            addCertificate.Show();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            CertificateModel cert = this.gridView1.GetFocusedRow() as CertificateModel;
            ControlFormReportModel controlFormReport= _unit.Report.CertificateMainReport(cert.Id);
           // ReportDesigner report = new ReportDesigner();
           // report.GenerateReport(controlFormReport);
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            CertificateModel cert = this.gridView1.GetFocusedRow() as CertificateModel;
         //   ReportDesigner reportDesigner = new ReportDesigner();
            MissMatchReportModel missMatchReport = _unit.Report.CertificateMissMatchReport(cert.Id);
           // reportDesigner.GenerateMissMatchReportReport(missMatchReport);
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CertificateModel certificate = (gridView1.GetFocusedRow() as CertificateModel);
            AddCertificate addCertificate = new AddCertificate(certificate);
            addCertificate.Text = "تکمیل اطلاعات گواهینامه";
            Program.Dashboard.AddFormTab(addCertificate);
        }
    }
}