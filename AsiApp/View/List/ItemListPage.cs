using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using AsiWindows.View.Edit;
using System;

namespace AsiWindows.View.List
{
    public partial class ItemListPage : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        public ItemListPage()
        {
            InitializeComponent();
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
            this.gridControl1.DataSource = _unit.Items.GetAll(1,20);
        }

       

        

        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            ItemModel item = gridView1.GetFocusedRow() as ItemModel;
            _unit.Items.Delete(item.Id);
        }

        private void ButtonNewItem_Click(object sender, EventArgs e)
        {
            ItemEditPage addItemPage = new ItemEditPage();
            Program.Dashboard.AddFormTab(addItemPage);
        }

        private void GridviewButtonEdit_Click(object sender, EventArgs e)
        {
            ItemModel _item = gridView1.GetRow(gridView1.FocusedRowHandle) as ItemModel;
           // _item.FormTemplates = _unit.ControlForms.Get(_item.FormId.ToString());
            ItemEditPage addItem = new ItemEditPage(_item);
            addItem.Show();
        }

        private void GridviewButtonDelete_Click(object sender, EventArgs e)
        {
            ItemModel _item = gridView1.GetRow(gridView1.FocusedRowHandle) as ItemModel;
          //  _item.Form = _unit.ControlForms.Get(_item.FormId.ToString());
            ItemEditPage addItem = new ItemEditPage(_item);
            addItem.Show();
        }
    }
}