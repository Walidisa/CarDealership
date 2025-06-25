namespace CarDealership
{
    partial class RibbonForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonForm1));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.searchItem = new DevExpress.XtraBars.BarEditItem();
            this.searchEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.homePage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dashboard = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Inbox = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.logIn = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.signUp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.contactUs = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.DrawGroupsBorderMode = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(110, 115, 110, 115);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Font = new System.Drawing.Font("Tahoma", 25F);
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.searchItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(12);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 1210;
            this.ribbon.PageHeaderItemLinks.Add(this.searchItem);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.homePage,
            this.dashboard,
            this.Inbox,
            this.logIn,
            this.signUp,
            this.contactUs});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office365;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(2906, 287);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // searchItem
            // 
            this.searchItem.Caption = "Search";
            this.searchItem.Edit = this.searchEdit;
            this.searchItem.EditWidth = 200;
            this.searchItem.Id = 2;
            this.searchItem.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 15F);
            this.searchItem.ItemAppearance.Disabled.Options.UseFont = true;
            this.searchItem.Name = "searchItem";
            // 
            // searchEdit
            // 
            this.searchEdit.Name = "searchEdit";
            // 
            // homePage
            // 
            this.homePage.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.homePage.Appearance.Options.UseFont = true;
            this.homePage.Name = "homePage";
            this.homePage.Text = "HomePage";
            // 
            // dashboard
            // 
            this.dashboard.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.dashboard.Appearance.Options.UseFont = true;
            this.dashboard.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.dashboard.Name = "dashboard";
            this.dashboard.Text = "Dashboard";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // Inbox
            // 
            this.Inbox.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.Inbox.Appearance.Options.UseFont = true;
            this.Inbox.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.Inbox.Name = "Inbox";
            this.Inbox.Text = "Inbox";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // logIn
            // 
            this.logIn.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.logIn.Appearance.Options.UseFont = true;
            this.logIn.Name = "logIn";
            this.logIn.Text = "Log In";
            // 
            // signUp
            // 
            this.signUp.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.signUp.Appearance.Options.UseFont = true;
            this.signUp.Name = "signUp";
            this.signUp.Text = "Sign Up";
            // 
            // contactUs
            // 
            this.contactUs.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.contactUs.Appearance.Options.UseFont = true;
            this.contactUs.Name = "contactUs";
            this.contactUs.Text = "Contact Us";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 1436);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(12);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(2906, 48);
            // 
            // RibbonForm1
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2906, 1484);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Tahoma", 15F);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("RibbonForm1.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "RibbonForm1";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Car Dealership";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RibbonForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage homePage;
        private DevExpress.XtraBars.Ribbon.RibbonPage logIn;
        private DevExpress.XtraBars.Ribbon.RibbonPage contactUs;
        private DevExpress.XtraBars.Ribbon.RibbonPage signUp;
        private DevExpress.XtraBars.Ribbon.RibbonPage dashboard;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem searchItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit searchEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPage Inbox;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}