
namespace AsiApp
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            DevExpress.XtraBars.Navigation.AccordionContextButton accordionContextButton1 = new DevExpress.XtraBars.Navigation.AccordionContextButton();
            DevExpress.XtraBars.Navigation.AccordionContextButton accordionContextButton2 = new DevExpress.XtraBars.Navigation.AccordionContextButton();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.DepartmentElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ServiceTypeElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.DashboardElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ArchiveElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ItemElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.CertificateTypeElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement9 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.UserElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.UserRoleElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.InfoElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ExitElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TimeLabel = new DevExpress.XtraEditors.LabelControl();
            this.DateLabel = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.userrolelabel = new DevExpress.XtraEditors.LabelControl();
            this.userlabel = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.adornerUIManager1 = new DevExpress.Utils.VisualEffects.AdornerUIManager(this.components);
            this.badge1 = new DevExpress.Utils.VisualEffects.Badge();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.DepartmentElement,
            this.ServiceTypeElement});
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement4.ImageOptions.SvgImage")));
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "مدیریت دپارتمان ها";
            // 
            // DepartmentElement
            // 
            this.DepartmentElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("DepartmentElement.ImageOptions.SvgImage")));
            this.DepartmentElement.Name = "DepartmentElement";
            this.DepartmentElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.DepartmentElement.Text = "دپارتمان ها";
            this.DepartmentElement.Click += new System.EventHandler(this.DepartmentElement_Click);
            // 
            // ServiceTypeElement
            // 
            this.ServiceTypeElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ServiceTypeElement.ImageOptions.SvgImage")));
            this.ServiceTypeElement.Name = "ServiceTypeElement";
            this.ServiceTypeElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ServiceTypeElement.Text = "نوع خدمات";
            this.ServiceTypeElement.Click += new System.EventHandler(this.ServiceTypeElement_Click);
            // 
            // DashboardElement
            // 
            this.DashboardElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("DashboardElement.ImageOptions.SvgImage")));
            this.DashboardElement.Name = "DashboardElement";
            this.DashboardElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.DashboardElement.Text = "داشبورد";
            // 
            // ArchiveElement
            // 
            this.ArchiveElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ArchiveElement.ImageOptions.SvgImage")));
            this.ArchiveElement.Name = "ArchiveElement";
            this.ArchiveElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ArchiveElement.Text = "آرشیو";
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ArchiveElement,
            this.DashboardElement,
            this.accordionControlElement2,
            this.accordionControlElement4,
            this.accordionControlElement1,
            this.accordionControlElement9,
            this.accordionControlSeparator1,
            this.InfoElement,
            this.ExitElement});
            this.accordionControl1.Location = new System.Drawing.Point(796, 0);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(9);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(460, 646);
            this.accordionControl1.TabIndex = 0;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement2
            // 
            accordionContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            accordionContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            accordionContextButton1.Caption = "منقضی شده";
            accordionContextButton1.Id = new System.Guid("3a0ccf2a-9b2f-4777-9398-953e9b85777d");
            accordionContextButton1.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            accordionContextButton1.Name = "accordionContextButton1";
            accordionContextButton2.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            accordionContextButton2.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            accordionContextButton2.Caption = "درحال انقضا";
            accordionContextButton2.Id = new System.Guid("61309bb2-4ef6-40e7-9260-3942da0c837e");
            accordionContextButton2.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            accordionContextButton2.Name = "accordionContextButton2";
            this.accordionControlElement2.ContextButtons.Add(accordionContextButton1);
            this.accordionControlElement2.ContextButtons.Add(accordionContextButton2);
            this.accordionControlElement2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement2.ImageOptions.SvgImage")));
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "گواهینامه ها";
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ItemElement,
            this.CertificateTypeElement});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement1.ImageOptions.SvgImage")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "مدیریت آیتم ها";
            // 
            // ItemElement
            // 
            this.ItemElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ItemElement.ImageOptions.SvgImage")));
            this.ItemElement.Name = "ItemElement";
            this.ItemElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ItemElement.Text = "آیتم ها";
            this.ItemElement.Click += new System.EventHandler(this.ItemElement_Click);
            // 
            // CertificateTypeElement
            // 
            this.CertificateTypeElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CertificateTypeElement.ImageOptions.SvgImage")));
            this.CertificateTypeElement.Name = "CertificateTypeElement";
            this.CertificateTypeElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.CertificateTypeElement.Text = "نوع گواهینامه";
            this.CertificateTypeElement.Click += new System.EventHandler(this.CertificateTypeElement_Click);
            // 
            // accordionControlElement9
            // 
            this.accordionControlElement9.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.UserElement,
            this.UserRoleElement});
            this.accordionControlElement9.Expanded = true;
            this.accordionControlElement9.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement9.ImageOptions.SvgImage")));
            this.accordionControlElement9.Name = "accordionControlElement9";
            this.accordionControlElement9.Text = "مدیریت کاربران";
            // 
            // UserElement
            // 
            this.UserElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UserElement.ImageOptions.SvgImage")));
            this.UserElement.Name = "UserElement";
            this.UserElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.UserElement.Text = "کاربران";
            // 
            // UserRoleElement
            // 
            this.UserRoleElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UserRoleElement.ImageOptions.SvgImage")));
            this.UserRoleElement.Name = "UserRoleElement";
            this.UserRoleElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.UserRoleElement.Text = "نقش ها";
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // InfoElement
            // 
            this.InfoElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("InfoElement.ImageOptions.SvgImage")));
            this.InfoElement.Name = "InfoElement";
            this.InfoElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.InfoElement.Text = "اطلاعات";
            // 
            // ExitElement
            // 
            this.ExitElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ExitElement.ImageOptions.SvgImage")));
            this.ExitElement.Name = "ExitElement";
            this.ExitElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ExitElement.Text = "خروج";
            this.ExitElement.Click += new System.EventHandler(this.accordionControlElement13_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.userrolelabel);
            this.panel1.Controls.Add(this.userlabel);
            this.panel1.Controls.Add(this.pictureEdit1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 646);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TimeLabel);
            this.panel2.Controls.Add(this.DateLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 566);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 80);
            this.panel2.TabIndex = 3;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Location = new System.Drawing.Point(26, 18);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(94, 19);
            this.TimeLabel.TabIndex = 1;
            this.TimeLabel.Text = "labelControl1";
            // 
            // DateLabel
            // 
            this.DateLabel.Location = new System.Drawing.Point(26, 48);
            this.DateLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(94, 19);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "labelControl1";
            this.DateLabel.Click += new System.EventHandler(this.DateLabel_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(18, 380);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(214, 54);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "گواهینامه درحال انقضا";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(18, 317);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(174, 54);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "درخواست ها";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // userrolelabel
            // 
            this.userrolelabel.Location = new System.Drawing.Point(138, 71);
            this.userrolelabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userrolelabel.Name = "userrolelabel";
            this.userrolelabel.Size = new System.Drawing.Size(94, 19);
            this.userrolelabel.TabIndex = 1;
            this.userrolelabel.Text = "labelControl1";
            // 
            // userlabel
            // 
            this.userlabel.LineVisible = true;
            this.userlabel.Location = new System.Drawing.Point(138, 42);
            this.userlabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(94, 19);
            this.userlabel.TabIndex = 1;
            this.userlabel.Text = "labelControl1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(-9, 18);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(148, 142);
            this.pictureEdit1.TabIndex = 0;
            // 
            // adornerUIManager1
            // 
            this.adornerUIManager1.Elements.Add(this.badge1);
            this.adornerUIManager1.Owner = this;
            // 
            // badge1
            // 
            this.badge1.Properties.Location = System.Drawing.ContentAlignment.TopRight;
            this.badge1.TargetElement = this.simpleButton1;
            this.badge1.TargetElementRegion = DevExpress.Utils.VisualEffects.TargetElementRegion.Control;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.accordionControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement DepartmentElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ServiceTypeElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement DashboardElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ArchiveElement;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ItemElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement CertificateTypeElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement9;
        private DevExpress.XtraBars.Navigation.AccordionControlElement UserElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement UserRoleElement;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement InfoElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ExitElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl userrolelabel;
        private DevExpress.XtraEditors.LabelControl userlabel;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl TimeLabel;
        private DevExpress.XtraEditors.LabelControl DateLabel;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.Utils.VisualEffects.AdornerUIManager adornerUIManager1;
        private DevExpress.Utils.VisualEffects.Badge badge1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}