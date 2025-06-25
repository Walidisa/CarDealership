using System.Windows.Forms;

namespace CarDealership
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel carFlowPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.carFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // carFlowPanel
            // 
            this.carFlowPanel.AutoScroll = true;
            this.carFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.carFlowPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.carFlowPanel.Name = "carFlowPanel";
            this.carFlowPanel.Size = new System.Drawing.Size(1200, 703);
            this.carFlowPanel.TabIndex = 0;
            this.carFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.carFlowPanel_Paint);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.carFlowPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HomePage";
            this.Text = "Car Dealership Inventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }
    }
}
