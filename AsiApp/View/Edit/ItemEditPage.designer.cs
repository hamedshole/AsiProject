
namespace AsiWindows.View.Edit
{
    partial class ItemEditPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditPage));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.formTemplateModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonAddForm = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextboxTitle = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxDepartments = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCertificateType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardRefference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReviewDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToolCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.formTemplateModelBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextboxTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxDepartments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // formTemplateModelBindingSource
            // 
            this.formTemplateModelBindingSource.DataSource = typeof(Asi.Model.FormTemplateModel);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ButtonAddForm);
            this.flowLayoutPanel1.Controls.Add(this.ButtonSubmit);
            this.flowLayoutPanel1.Controls.Add(this.ButtonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 333);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(884, 113);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // ButtonAddForm
            // 
            this.ButtonAddForm.ImageOptions.Image = global::AsiApp.Properties.Resources.addnewdatasource_32x32;
            this.ButtonAddForm.Location = new System.Drawing.Point(709, 22);
            this.ButtonAddForm.Margin = new System.Windows.Forms.Padding(22);
            this.ButtonAddForm.Name = "ButtonAddForm";
            this.ButtonAddForm.Size = new System.Drawing.Size(153, 69);
            this.ButtonAddForm.TabIndex = 0;
            this.ButtonAddForm.Text = "افزودن فرم";
            this.ButtonAddForm.Click += new System.EventHandler(this.ButtonAddForm_Click);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.ImageOptions.Image = global::AsiApp.Properties.Resources.apply_32x32;
            this.ButtonSubmit.Location = new System.Drawing.Point(512, 22);
            this.ButtonSubmit.Margin = new System.Windows.Forms.Padding(22);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(153, 69);
            this.ButtonSubmit.TabIndex = 1;
            this.ButtonSubmit.Text = "تایید";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ImageOptions.Image = global::AsiApp.Properties.Resources.cancel_32x32;
            this.ButtonCancel.Location = new System.Drawing.Point(315, 22);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(22);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(153, 69);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "لغو";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextboxTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ComboBoxDepartments);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 60);
            this.panel1.TabIndex = 9;
            // 
            // TextboxTitle
            // 
            this.TextboxTitle.Location = new System.Drawing.Point(515, 9);
            this.TextboxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.TextboxTitle.Name = "TextboxTitle";
            this.TextboxTitle.Size = new System.Drawing.Size(291, 26);
            this.TextboxTitle.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(806, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "عنوان :";
            // 
            // ComboBoxDepartments
            // 
            this.ComboBoxDepartments.Location = new System.Drawing.Point(103, 9);
            this.ComboBoxDepartments.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxDepartments.Name = "ComboBoxDepartments";
            this.ComboBoxDepartments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxDepartments.Size = new System.Drawing.Size(291, 26);
            this.ComboBoxDepartments.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "نوع خدمات :";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.formTemplateModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gridControl1.Size = new System.Drawing.Size(884, 273);
            this.gridControl1.TabIndex = 18;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCertificateType,
            this.colStandardRefference,
            this.colFormCode,
            this.colReviewDate,
            this.colToolCode,
            this.gridColumnEdit,
            this.gridColumnDelete});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCertificateType
            // 
            this.colCertificateType.Caption = "نوع گواهینامه";
            this.colCertificateType.FieldName = "CertificateType";
            this.colCertificateType.MinWidth = 30;
            this.colCertificateType.Name = "colCertificateType";
            this.colCertificateType.Visible = true;
            this.colCertificateType.VisibleIndex = 0;
            this.colCertificateType.Width = 112;
            // 
            // colStandardRefference
            // 
            this.colStandardRefference.Caption = "مرجع بازرسی";
            this.colStandardRefference.FieldName = "StandardRefference";
            this.colStandardRefference.MinWidth = 30;
            this.colStandardRefference.Name = "colStandardRefference";
            this.colStandardRefference.Visible = true;
            this.colStandardRefference.VisibleIndex = 1;
            this.colStandardRefference.Width = 112;
            // 
            // colFormCode
            // 
            this.colFormCode.Caption = "کد فرم";
            this.colFormCode.FieldName = "FormCode";
            this.colFormCode.MinWidth = 30;
            this.colFormCode.Name = "colFormCode";
            this.colFormCode.Visible = true;
            this.colFormCode.VisibleIndex = 2;
            this.colFormCode.Width = 112;
            // 
            // colReviewDate
            // 
            this.colReviewDate.Caption = "تاریخ بازبینی";
            this.colReviewDate.FieldName = "ReviewDate";
            this.colReviewDate.MinWidth = 30;
            this.colReviewDate.Name = "colReviewDate";
            this.colReviewDate.Visible = true;
            this.colReviewDate.VisibleIndex = 3;
            this.colReviewDate.Width = 112;
            // 
            // colToolCode
            // 
            this.colToolCode.Caption = "کد ابزار";
            this.colToolCode.FieldName = "ToolCode";
            this.colToolCode.MinWidth = 30;
            this.colToolCode.Name = "colToolCode";
            this.colToolCode.Visible = true;
            this.colToolCode.VisibleIndex = 4;
            this.colToolCode.Width = 112;
            // 
            // gridColumnEdit
            // 
            this.gridColumnEdit.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumnEdit.MinWidth = 30;
            this.gridColumnEdit.Name = "gridColumnEdit";
            this.gridColumnEdit.Visible = true;
            this.gridColumnEdit.VisibleIndex = 5;
            this.gridColumnEdit.Width = 112;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick_1);
            // 
            // gridColumnDelete
            // 
            this.gridColumnDelete.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumnDelete.MinWidth = 30;
            this.gridColumnDelete.Name = "gridColumnDelete";
            this.gridColumnDelete.Visible = true;
            this.gridColumnDelete.VisibleIndex = 6;
            this.gridColumnDelete.Width = 112;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // ItemEditPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 446);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemEditPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "AddItemPage";
            ((System.ComponentModel.ISupportInitialize)(this.formTemplateModelBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextboxTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxDepartments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton ButtonAddForm;
        private DevExpress.XtraEditors.SimpleButton ButtonSubmit;
        private DevExpress.XtraEditors.SimpleButton ButtonCancel;
        private System.Windows.Forms.BindingSource formTemplateModelBindingSource;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit TextboxTitle;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxDepartments;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCertificateType;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardRefference;
        private DevExpress.XtraGrid.Columns.GridColumn colFormCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReviewDate;
        private DevExpress.XtraGrid.Columns.GridColumn colToolCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
    }
}