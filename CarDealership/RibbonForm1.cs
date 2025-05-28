using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
            ribbon.SelectedPageChanged += Ribbon_SelectedPageChanged;
            this.IsMdiContainer = true;
            HomePage home = new HomePage();
            home.MdiParent = this;
            // Optional: if you want it as an MDI child
            home.Show();
        }
        private void Ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbon.SelectedPage == homePage)
            {
                // Show the HomePage form only if it's not already open
                foreach (Form f in Application.OpenForms)
                {
                    if (f is HomePage)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                HomePage home = new HomePage();
                home.MdiParent = this; // Optional: if you want it as an MDI child
                home.Show();
            }
            if (ribbon.SelectedPage == logIn)
            {
                // Show the HomePage form only if it's not already open
                foreach (Form f in Application.OpenForms)
                {
                    if (f is LogIn)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                LogIn lg = new LogIn();
                lg.MdiParent = this; // Optional: if you want it as an MDI child
                lg.Show();
            }
            if (ribbon.SelectedPage == signUp)
            {
                // Show the HomePage form only if it's not already open
                foreach (Form f in Application.OpenForms)
                {
                    if (f is SignUp)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                SignUp sg = new SignUp();
                sg.MdiParent = this; // Optional: if you want it as an MDI child
                sg.Show();
            }
            //if (ribbon.SelectedPage == aboutUs)
            //{
            //    // Show the HomePage form only if it's not already open
            //    foreach (Form f in Application.OpenForms)
            //    {
            //        if (f is AboutUs)
            //        {
            //            f.BringToFront();
            //            return;
            //        }
            //    }
            //    AboutUs au = new AboutUs();
            //    au.MdiParent = this; // Optional: if you want it as an MDI child
            //    au.Show();
            //}
            if (ribbon.SelectedPage == contactUs)
            {
                // Show the HomePage form only if it's not already open
                foreach (Form f in Application.OpenForms)
                {
                    if (f is ContactUs)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                ContactUs cu = new ContactUs();
                cu.MdiParent = this; // Optional: if you want it as an MDI child
                cu.Show();
            }

        }


        private void RibbonForm1_Load(object sender, EventArgs e)
        {

        }
    }
}