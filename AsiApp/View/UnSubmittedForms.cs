using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using AsiWindows.View.Edit;
using System.Windows.Forms;

namespace AsiWindows.View.List
{
    public partial class UnSubmittedForms : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;

        public UnSubmittedForms()
        {
            _unit =(IV1BusinessUnit) Program.ServiceProvider.GetService(typeof(IV1BusinessUnit));
            InitializeComponent();
            this.gridControl1.DataSource = _unit.Certificates.GetUnsubmittedForms(1, 20);
        }

        

        private void ButtonCertificateSubmit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          //  ControlFormSendModel certificate = gridView1.GetFocusedRow() as ControlFormSendModel;
         //   AddCertificate addCertificate = new AddCertificate(certificate);
          //  addCertificate.Show();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          //  ControlFormSendModel c = (this.gridView1.GetFocusedRow() as ControlFormSendModel);
          //  Clipboard.SetText(string.Format("http://www.google.com/maps/place/{0},{1}", c.LocationLatitude, c.LocationLongtitude.ToString()));
        }
    }
}