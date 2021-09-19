
namespace AsiWindows.View.List
{
    partial class UnSubmittedForms
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnSubmittedForms));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.controlFormSendModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainControllerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colControlDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCertificateType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colControlTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubmit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonCertificateSubmit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlFormSendModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonCertificateSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.controlFormSendModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonCertificateSubmit,
            this.repositoryItemButtonEdit1});
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1029, 350);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // controlFormSendModelBindingSource
            // 
           // this.controlFormSendModelBindingSource.DataSource = typeof(Asi.Shared.Model.ControlFormSendModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colMainControllerName,
            this.colControlDate,
            this.colDepartment,
            this.colCertificateType,
            this.colProvinence,
            this.colCompanyName,
            this.colLinkName,
            this.colControlTime,
            this.colSubmit,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 30;
            this.colId.Name = "colId";
            this.colId.Width = 112;
            // 
            // colMainControllerName
            // 
            this.colMainControllerName.Caption = "بازرس اصلی";
            this.colMainControllerName.FieldName = "MainControllerName";
            this.colMainControllerName.MinWidth = 30;
            this.colMainControllerName.Name = "colMainControllerName";
            this.colMainControllerName.Visible = true;
            this.colMainControllerName.VisibleIndex = 5;
            this.colMainControllerName.Width = 112;
            // 
            // colControlDate
            // 
            this.colControlDate.Caption = "تاریخ";
            this.colControlDate.FieldName = "ControlDate";
            this.colControlDate.MinWidth = 30;
            this.colControlDate.Name = "colControlDate";
            this.colControlDate.Visible = true;
            this.colControlDate.VisibleIndex = 0;
            this.colControlDate.Width = 112;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "نوع خدمات";
            this.colDepartment.FieldName = "ServiceType";
            this.colDepartment.MinWidth = 30;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 2;
            this.colDepartment.Width = 112;
            // 
            // colCertificateType
            // 
            this.colCertificateType.Caption = "نوع گواهینامه";
            this.colCertificateType.FieldName = "CertificateType";
            this.colCertificateType.MinWidth = 30;
            this.colCertificateType.Name = "colCertificateType";
            this.colCertificateType.Visible = true;
            this.colCertificateType.VisibleIndex = 3;
            this.colCertificateType.Width = 112;
            // 
            // colProvinence
            // 
            this.colProvinence.Caption = "استان";
            this.colProvinence.FieldName = "Provinence";
            this.colProvinence.MinWidth = 30;
            this.colProvinence.Name = "colProvinence";
            this.colProvinence.Visible = true;
            this.colProvinence.VisibleIndex = 4;
            this.colProvinence.Width = 112;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "شرکت";
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 6;
            this.colCompanyName.Width = 112;
            // 
            // colLinkName
            // 
            this.colLinkName.Caption = "رابط";
            this.colLinkName.FieldName = "LinkName";
            this.colLinkName.MinWidth = 30;
            this.colLinkName.Name = "colLinkName";
            this.colLinkName.Visible = true;
            this.colLinkName.VisibleIndex = 7;
            this.colLinkName.Width = 112;
            // 
            // colControlTime
            // 
            this.colControlTime.Caption = "نوبت بازرسی";
            this.colControlTime.FieldName = "ControlTimeText";
            this.colControlTime.MinWidth = 30;
            this.colControlTime.Name = "colControlTime";
            this.colControlTime.Visible = true;
            this.colControlTime.VisibleIndex = 1;
            this.colControlTime.Width = 112;
            // 
            // colSubmit
            // 
            this.colSubmit.ColumnEdit = this.ButtonCertificateSubmit;
            this.colSubmit.MinWidth = 30;
            this.colSubmit.Name = "colSubmit";
            this.colSubmit.Visible = true;
            this.colSubmit.VisibleIndex = 8;
            this.colSubmit.Width = 112;
            // 
            // ButtonCertificateSubmit
            // 
            this.ButtonCertificateSubmit.AutoHeight = false;
            editorButtonImageOptions1.Image = global::AsiApp.Properties.Resources.addchartpane_32x32;
            this.ButtonCertificateSubmit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.ButtonCertificateSubmit.Name = "ButtonCertificateSubmit";
            this.ButtonCertificateSubmit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ButtonCertificateSubmit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonCertificateSubmit_ButtonClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.MinWidth = 30;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 112;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // UnSubmittedForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 350);
            this.Controls.Add(this.gridControl1);
            this.Name = "UnSubmittedForms";
            this.Text = "UnSubmittedForms";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlFormSendModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonCertificateSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource controlFormSendModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMainControllerName;
        private DevExpress.XtraGrid.Columns.GridColumn colControlDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colCertificateType;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinence;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colLinkName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colControlTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSubmit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonCertificateSubmit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}