using AsiApp.View.List;
using AsiWindows.View.Edit;
using AsiWindows.View.List;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UnSubmittedForms unSubmittedForms = new UnSubmittedForms();
            unSubmittedForms.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CertificateList certificateList = new CertificateList(CertificateList.Status.None);
            certificateList.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ItemEditPage itemEditPage = new ItemEditPage();
            itemEditPage.Show();
        }
    }
}
