// Developer Express Code Central Example:
// Custom GridControl - How  you  can create a vertical embedded Navigator
// 
// This example demonstrates how to create a custom GridControl that supports a
// vertical navigator.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4091

namespace VerticalDataNavigator
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.customGridControl1 = new VerticalDataNavigator.CustomGridControl();
            this.customGridView1 = new VerticalDataNavigator.CustomGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vertical navigation orientation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "Horizontal navigation orientation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // customGridControl1
            // 
            this.customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.customGridControl1.EmbeddedNavigator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.customGridControl1.EmbeddedNavigator.Buttons.First.ImageIndex = 0;
            this.customGridControl1.EmbeddedNavigator.Buttons.Last.ImageIndex = 5;
            this.customGridControl1.EmbeddedNavigator.Buttons.Next.ImageIndex = 3;
            this.customGridControl1.EmbeddedNavigator.Buttons.NextPage.ImageIndex = 4;
            this.customGridControl1.EmbeddedNavigator.Buttons.Prev.ImageIndex = 2;
            this.customGridControl1.EmbeddedNavigator.Buttons.PrevPage.ImageIndex = 1;
            this.customGridControl1.EmbeddedNavigator.Location = new System.Drawing.Point(1, 588);
            this.customGridControl1.EmbeddedNavigator.LookAndFeel.UseDefaultLookAndFeel = false;
            this.customGridControl1.EmbeddedNavigator.Name = "";
            this.customGridControl1.EmbeddedNavigator.NavigatableControl = this.customGridControl1;
            this.customGridControl1.EmbeddedNavigator.Size = new System.Drawing.Size(189, 19);
            this.customGridControl1.EmbeddedNavigator.TabIndex = 0;
            this.customGridControl1.EmbeddedNavigatorOrientation = VerticalDataNavigator.Navigator.NavigatorOrientation.Horizontal;
            this.customGridControl1.Location = new System.Drawing.Point(0, 0);
            this.customGridControl1.MainView = this.customGridView1;
            this.customGridControl1.Name = "customGridControl1";
            this.customGridControl1.Size = new System.Drawing.Size(600, 608);
            this.customGridControl1.TabIndex = 3;
            this.customGridControl1.UseEmbeddedNavigator = true;
            this.customGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView1});
            // 
            // customGridView1
            // 
            this.customGridView1.GridControl = this.customGridControl1;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.OptionsView.ColumnAutoWidth = false;
            this.customGridView1.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 608);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customGridControl1);
            this.Name = "Form1";
            this.Text = "VerticallyDataNavigator";
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CustomGridControl customGridControl1;
        private CustomGridView customGridView1;














    }
}

