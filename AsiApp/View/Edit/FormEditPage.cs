using Asi.Client.V1.Interfaces;
using Asi.Model;
using AsiApp;
using AsiApp.View.Edit;
using AsiWindows.Control;
using System;
using System.Collections.Generic;
using Windows.AsiWindows.Interface;

namespace AsiWindows.View.Edit
{
    public partial class FormEditPage : DevExpress.XtraEditors.XtraForm
    {
        FormTemplateModel form;
        List<CertificateTypeModel> CertificateTypes;
        AddGroup addGroup;
        private readonly IV1BusinessUnit _unit;
        public FormEditPage()
        {
            _unit = Program.ServiceProvider.GetService(typeof(IV1BusinessUnit)) as IV1BusinessUnit;
            CertificateTypes = _unit.CertificateTypes.GetAll(0);
            form = new FormTemplateModel();
            InitializeComponent();
            int w = this.flowLayoutPanel3.Width;
            this.flowLayoutPanel3.Width = this.Width;
            this.Text = "افزودن گروه";
            CertificateTypes.ForEach(x => this.comboBoxCertificateType.Properties.Items.Add(x.Title));
            this.textBox1.Text = DateTime.Now.ToLongDateString();
        }
        public FormEditPage(FormTemplateModel controlForm)
        {
          
            form = controlForm;
            InitializeComponent();
            this.Resize += FormEditPage_Resize;
           int w= this.FlowLayoutPanelItemGroups.Width;
            this.Text = "ویرایش گروه";
            this.textBox1.Text = DateTime.Now.ToLongDateString();
             fillPanel(controlForm);
        }

        private void FormEditPage_Resize(object sender, EventArgs e)
        {
            this.FlowLayoutPanelItemGroups.Width = this.Width;
            for (int i = 0; i < this.FlowLayoutPanelItemGroups.Controls.Count; i++)
            {
                this.FlowLayoutPanelItemGroups.Controls[i].Width = this.Width;
            }
        }

        private void ButtonAddQuestionGroup_Click(object sender, EventArgs e)
        {
            addGroup = new AddGroup();
            addGroup.ButtonSubmit.Click += ButtonSubmit_Click;
            Program.Dashboard.AddFormTab(addGroup);

        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            FormTemplateGroupModel controlItemGroup = addGroup.GetGroup();
            AddGroupToPanel(controlItemGroup);
            addGroup.Close();
        }

        private void AddGroupToPanel(FormTemplateGroupModel controlItemGroup)
        {
            GroupControl questionItem = new GroupControl(controlItemGroup)
            {
                Width = this.FlowLayoutPanelItemGroups.Width,
                Dock = System.Windows.Forms.DockStyle.Top
            };
            
            this.FlowLayoutPanelItemGroups.Controls.Add(questionItem);
        }


        public FormTemplateModel GetForm()
        {
            if (this.form == null)
            {
                form = new FormTemplateModel();
            }
            form.StandardRefference = this.textBox2.Text;
            form.CertificateType = this.comboBoxCertificateType.Text;
            form.CertificateTypeId = this.CertificateTypes.Find(x => x.Title == this.comboBoxCertificateType.Text).Id;
            form.ToolCode = this.TextboxToolCode.Text;
            form.FormCode = this.TextboxTitle.Text;
            form.ReviewDate = DateTime.Now;
            List<FormTemplateGroupModel> controlItemGroups = new List<FormTemplateGroupModel>();
            foreach (IGroup item in this.FlowLayoutPanelItemGroups.Controls)
            {
                controlItemGroups.Add(item.GetGroup());
            }
            form.Groups = controlItemGroups;
            return form;
        }
        public void fillPanel(FormTemplateModel controlForm)
        {
            this.textBox1.Text = controlForm.ReviewDate.ToLongDateString();
            this.TextboxTitle.Text = controlForm.FormCode;
            this.TextboxToolCode.Text = controlForm.ToolCode;
            this.Refresh();
            int d = this.Width;
            for (int i = 0; i < controlForm.Groups.Count; i++)
            {
                    this.AddGroupToPanel(controlForm.Groups[i]);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}