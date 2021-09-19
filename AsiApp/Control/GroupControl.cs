using Asi.Model;
using AsiApp;
using AsiApp.View.Edit;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using Windows.AsiWindows.Interface;

namespace AsiWindows.Control
{
    public partial class GroupControl : DevExpress.XtraEditors.XtraUserControl, IGroup
    {
        private  FormTemplateGroupModel _itemGroup;
        AddGroup addGroup;
        public GroupControl(FormTemplateGroupModel controlItemGroup)
        {
            InitializeComponent();
            FillData(controlItemGroup);
        }

        private void FillData(FormTemplateGroupModel controlItemGroup)
        {
            this.gridView1.Columns.Capacity = 10;
            this._itemGroup = controlItemGroup;
            this.labelControl1.Text = controlItemGroup.Title;
            this.gridControl1.DataSource = controlItemGroup.Questions;
            for (int i = 0; i < this._itemGroup.QuestionHeaders.Count; i++)
            {
                GridColumn column = this.gridView1.Columns.ElementAt(i);
                column.VisibleIndex = i + 1;
                column.Caption = this._itemGroup.QuestionHeaders[i];
                column.Visible = true;
            }
            int questioncount = this._itemGroup.QuestionHeaders.Count;
            for (int i = 0; i < this._itemGroup.AnswerColumns.Count; i++)
            {
                GridColumn column = new GridColumn();
                column.Caption = _itemGroup.AnswerColumns[i];
                column.VisibleIndex = questioncount + i;
                column.Visible = true;
                gridView1.Columns.Add(column);
            }
            this.gridControl1.DataSource = _itemGroup.Questions;
        }

        public FormTemplateGroupModel GetGroup()
        {
            return _itemGroup;
        }

        private void EditButton_Click(object sender, System.EventArgs e)
        {
            addGroup = new AddGroup(this._itemGroup);
            addGroup.ButtonSubmit.Click += ButtonSubmit_Click;
            Program.Dashboard.AddFormTab(addGroup);
            
        }

        private void ButtonSubmit_Click(object sender, System.EventArgs e)
        {
            this.FillData(addGroup.GetGroup());
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
    }
}
