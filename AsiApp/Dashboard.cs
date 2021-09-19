using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp.View.List;
using AsiWindows.View.List;
using DevExpress.XtraTabbedMdi;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AsiApp
{
    public partial class Dashboard : Form
    {
        IV1BusinessUnit _unit;
        public Dashboard()
        {
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
            InitializeComponent();
            SetTime();
            SetNotificationsBadge();
            UserModel user = new UserModel { Name = "حامد", Role = "مدیرکل" };
            this.SetUser(user);
        }

        private void SetNotificationsBadge()
        {
            int count = _unit.Certificates.UnCompleteCount();
            badge1.Properties.Text = count.ToString();
            badge1.Visible = true;
        }

        public void SetUser(UserModel user)
        {
            this.userlabel.Text = user.Name;
            this.userrolelabel.Text = user.Role;
        }
        private void SetTime()
        {
            DateLabel.Text = DateTime.Now.Date.ToLongDateString();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.TimeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DateLabel_Click(object sender, EventArgs e)
        {

        }

        public  void AddFormTab( Form form)
        {
            XtraMdiTabPage selectedform = xtraTabbedMdiManager1.Pages.Where(x => x.Text == form.Text).FirstOrDefault();
            if (selectedform == null)
            {
                form.TopLevel = false;
                form.MdiParent = this;
                form.Show();
                form.Focus();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = selectedform;
            }
        }
        private void DepartmentElement_Click(object sender, EventArgs e)
        {
            DepartmentListPage departmentListPage = new DepartmentListPage();
            this.AddFormTab(departmentListPage);
           
        }

        private void ServiceTypeElement_Click(object sender, EventArgs e)
        {
            ServiceTypeListPage serviceTypeListPage = new ServiceTypeListPage();
            this.AddFormTab(serviceTypeListPage);
        }

        private void CertificateTypeElement_Click(object sender, EventArgs e)
        {
            CertificateTypeListPage certificateTypeListPage = new CertificateTypeListPage();
            this.AddFormTab(certificateTypeListPage);
        }

        private void ItemElement_Click(object sender, EventArgs e)
        {
            ItemListPage itemListPage = new ItemListPage();
            this.AddFormTab(itemListPage);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CertificateList certificateList = new CertificateList(CertificateList.Status.UnComplete);
            certificateList.Text = "صف تایید";
            this.AddFormTab(certificateList);
        }
    }
}
