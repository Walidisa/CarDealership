using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Vendor currentVendor { get; set; }


        public RibbonForm1()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 365";
            ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowToolbarCustomizeItem = false;
            ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            ribbon.SelectedPageChanged += Ribbon_SelectedPageChanged;
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            HomePage home = new HomePage();
            home.MdiParent = this;
           
            home.Show();
            dashboard.Visible = false;
            Inbox.Visible = false;
            searchItem.EditValueChanged += SearchItem_EditValueChanged;

        }
        private void Ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbon.SelectedPage == homePage)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is HomePage)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                HomePage home = new HomePage();
                home.MdiParent = this;
                home.Show();
            }
            if (ribbon.SelectedPage == logIn)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is LogIn)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                LogIn lg = new LogIn();
                lg.MdiParent = this;
                lg.Show();
            }
            if (ribbon.SelectedPage == signUp)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is SignUp)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                SignUp sg = new SignUp();
                sg.MdiParent = this;
                sg.Show();
            }
            if (ribbon.SelectedPage == dashboard)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is VendorDashboard)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                VendorDashboard vd = new VendorDashboard(currentVendor);
                vd.MdiParent = this;
                vd.Show();
            }
            if (ribbon.SelectedPage == contactUs)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is ContactUs)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                ContactUs cu = new ContactUs();
                cu.MdiParent = this;
                cu.Show();
            }
            if (ribbon.SelectedPage == Inbox)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is InboxForm)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                InboxForm inf = new InboxForm(currentVendor);
                inf.MdiParent = this;
                inf.Show();
            }
        }
        public void UpdateUIAfterLogin()
        {
            logIn.Visible = false;
            signUp.Visible = false;
            dashboard.Visible = true;
            Inbox.Visible = true; 
        }
        public void UpdateUIAfterLogout()
        {
            logIn.Visible = true;
            signUp.Visible = true;
            dashboard.Visible = false;
            Inbox.Visible = false;
            ribbon.SelectedPage = homePage; // Reset to HomePage after logout
        }


        private void SearchItem_EditValueChanged(object sender, EventArgs e)
        {
            var editItem = sender as DevExpress.XtraBars.BarEditItem;
            string searchText = editItem?.EditValue?.ToString() ?? "";

            foreach (Form f in this.MdiChildren)
            {
                if (f is HomePage homePage)
                {
                    homePage.PerformSearch(searchText);
                }
            }
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}