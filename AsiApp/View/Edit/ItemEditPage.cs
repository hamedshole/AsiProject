using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AsiWindows.View.Edit
{
    public partial class ItemEditPage : DevExpress.XtraEditors.XtraForm
    {
        private readonly IV1BusinessUnit _unit;
        private ItemModel _item;
        private List<FormTemplateModel> FormTemplates;
        private readonly List<ServiceTypeModel> serviceTypes;
        FormEditPage addFormPage;
        public ItemEditPage()
        {
            FormTemplates = new List<FormTemplateModel>();
            _item = new ItemModel();
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
            InitializeComponent();
            this.Text = "افزودن آیتم";
            this.gridControl1.DataSource = FormTemplates;
            this.ButtonSubmit.Click += ButtonSubmit_Click;
            serviceTypes = _unit.ServiceTypes.GetAll(0);
            serviceTypes.ForEach(x => this.ComboBoxDepartments.Properties.Items.Add(x.Title));
        }
        public ItemEditPage(ItemModel item)
        {
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
            InitializeComponent();
            this.Text = "ویرایش آیتم";
            this.ButtonSubmit.Click += ButtonSubmit_ClickUpdate;
            serviceTypes = _unit.ServiceTypes.GetAll(1, 20);
            serviceTypes.ForEach(x => this.ComboBoxDepartments.Properties.Items.Add(x.Title));
            this._item = item;
            FillBoxes(item);
        }

        private void ButtonSubmit_ClickUpdate(object sender, EventArgs e)
        {
            _item.ServiceTypeId = serviceTypes.Where(x => x.Title == ComboBoxDepartments.Text).FirstOrDefault().Id;
            _item.Title = this.TextboxTitle.Text;
            _unit.Items.Update(_item);
        }


        private void ButtonAddForm_Click(object sender, EventArgs e)
        {

            addFormPage = new FormEditPage();
            addFormPage.ButtonSubmit.Click += SimpleButton2Edit_Click;
            Program.Dashboard.AddFormTab(addFormPage);

        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            FormTemplateModel formTemplate = addFormPage.GetForm();
            this.FormTemplates.Add(formTemplate);
            addFormPage.Close();
        }
        private void SimpleButton2Edit_Click(object sender, EventArgs e)
        {
            FormTemplateModel formTemplate = addFormPage.GetForm();
            this.FormTemplates.Add(formTemplate);
            this.gridControl1.RefreshDataSource();
            addFormPage.Close();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                  _item.ServiceTypeId = serviceTypes.Where(x => x.Title == ComboBoxDepartments.Text).FirstOrDefault().Id;
                  _item.Title = this.TextboxTitle.Text;
                  _item.FormTemplates = this.FormTemplates;
                 File.WriteAllText(string.Format("{0}.txt",_item.Title), JsonConvert.SerializeObject(_item));
                _unit.Items.Create(_item);
                //ItemModel itemModel = JsonConvert.DeserializeObject<ItemModel>(File.ReadAllText(@"لودر.txt"));
                //_unit.Items.Create(itemModel);
            }
            catch (Exception ee)
            {
                System.Windows.Forms.MessageBox.Show(ee.Message);
                // throw;
            }

        }
        void FillBoxes(ItemModel item)
        {
            this.TextboxTitle.Text = item.Title;
            this.ComboBoxDepartments.Text = item.ServiceType;
        }


        private void repositoryItemButtonEdit1_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormTemplateModel formTemplate = this.gridView1.GetFocusedRow() as FormTemplateModel;
            addFormPage = new FormEditPage(formTemplate);
            Program.Dashboard.AddFormTab(addFormPage);
        }
    }
}