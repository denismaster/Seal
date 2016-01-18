namespace TestApp
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
            this.sealControl1 = new TestApp.SealControl();
            this.SuspendLayout();
            // 
            // sealControl1
            // 
            this.sealControl1.AutoSize = true;
            this.sealControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sealControl1.Location = new System.Drawing.Point(0, 0);
            this.sealControl1.Name = "sealControl1";
            this.sealControl1.Size = new System.Drawing.Size(495, 371);
            this.sealControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 371);
            this.Controls.Add(this.sealControl1);
            this.Name = "Form1";
            this.Text = "The future of Seal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SealControl sealControl1;
    }
}

