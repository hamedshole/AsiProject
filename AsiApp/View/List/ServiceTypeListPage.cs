using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsiWindows.View.List
{
    public partial class ServiceTypeListPage : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        private readonly List<DepartmentModel> _departments;
        public ServiceTypeListPage()
        {
            _unit = (IV1BusinessUnit)Program.ServiceProvider.GetService(typeof(IV1BusinessUnit));

            _departments = _unit.Departments.GetAll(0);

            InitializeComponent();
            _departments.ForEach(x => comboBoxEdit1.Properties.Items.Add(x.Title));
            this.Text = "نوع خدمات";
            LoadGridData();
        }

        private void LoadGridData()
        {

            this.gridControl1.DataSource = _unit.ServiceTypes.GetAll(1, 20);
        }


        private void GridviewDeleteButton_Click(object sender, System.EventArgs e)
        {
            ServiceTypeModel serviceType = gridView1.GetFocusedRow() as ServiceTypeModel;
            _unit.ServiceTypes.Delete(serviceType.Id);
            LoadGridData();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ServiceTypeModel serviceTypeModel = this.gridView1.GetFocusedRow() as ServiceTypeModel;
            simpleButton1.Enabled = true;
            SetValue(serviceTypeModel);

        }
        private void SetValue(ServiceTypeModel serviceTypeModel)
        {
            TextboxId.Text = serviceTypeModel.Id.ToString();
            TextboxTitle.Text = serviceTypeModel.Title;
            comboBoxEdit1.Text = serviceTypeModel.Department;
        }
        private ServiceTypeModel GetValue()
        {
            return new ServiceTypeModel
            {
                Id = Convert.ToInt32(TextboxId.Text),
                Title = TextboxTitle.Text,
                DepartmentId = _departments.Where(x => x.Title == comboBoxEdit1.Text).Select(x => x.Id).FirstOrDefault()
            };
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _unit.ServiceTypes.Update(GetValue());
            simpleButton1.Enabled = false;
        }

        private void ButtonNewDepartment_Click(object sender, EventArgs e)
        {
            _unit.ServiceTypes.Create(GetValue());
        }
    }

}