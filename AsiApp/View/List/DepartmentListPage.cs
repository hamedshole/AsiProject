using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using AsiWindows.View.Edit;
using System;

namespace AsiWindows.View.List
{
    public partial class DepartmentListPage : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        public DepartmentListPage()
        {
            InitializeComponent();
            this.Text = "دپارتمان ها";
            _unit = (IV1BusinessUnit)Program.ServiceProvider.GetService(typeof(IV1BusinessUnit));
            LoadGridData();
        }

        private void LoadGridData()
        {
            this.gridControl1.DataSource = _unit.Departments.GetAll(1,20);
        }


        private void GridviewDeleteButton_Click(object sender, System.EventArgs e)
        {
            DepartmentModel departmentModel = gridView1.GetFocusedRow() as DepartmentModel;
            _unit.Departments.Delete(departmentModel.Id);
            LoadGridData();
        }

        private void ButtonRefresh_Click(object sender, System.EventArgs e)
        {
            LoadGridData();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DepartmentModel departmentModel = gridView1.GetFocusedRow() as DepartmentModel;
            this.SetValue(departmentModel);
            this.simpleButton2.Enabled = true;
        }
        private void SetValue(DepartmentModel department)
        {
            this.TextboxId.Text = department.Id.ToString();
            this.TextboxTitle.Text = department.Title;
        }
        private DepartmentModel GetValue()
        {
            return new DepartmentModel
            {
                Id = Convert.ToInt32(TextboxId.Text),
                Title = TextboxTitle.Text
            };
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this._unit.Departments.Create(GetValue());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this._unit.Departments.Update(GetValue());
            this.simpleButton2.Enabled = false;
        }
    }
}