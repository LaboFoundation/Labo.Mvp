namespace Labo.Mvp.WinForms
{
    partial class MainScreenForm
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
            this.viewsMenu = new System.Windows.Forms.MenuStrip();
            this.mainLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // viewsMenu
            // 
            this.viewsMenu.Location = new System.Drawing.Point(0, 0);
            this.viewsMenu.Name = "viewsMenu";
            this.viewsMenu.Size = new System.Drawing.Size(784, 24);
            this.viewsMenu.TabIndex = 0;
            this.viewsMenu.Text = "menuStrip1";
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Size = new System.Drawing.Size(784, 538);
            this.mainLayoutPanel.TabIndex = 1;
            // 
            // MainScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainLayoutPanel);
            this.Controls.Add(this.viewsMenu);
            this.MainMenuStrip = this.viewsMenu;
            this.Name = "MainScreenForm";
            this.Text = "MainScreenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip viewsMenu;
        private System.Windows.Forms.FlowLayoutPanel mainLayoutPanel;
    }
}