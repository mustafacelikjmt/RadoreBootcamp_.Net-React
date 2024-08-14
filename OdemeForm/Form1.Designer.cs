namespace OdemeForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnOdemeYap = new Button();
            cmbOdemeTipi = new ComboBox();
            label2 = new Label();
            txtTutar = new TextBox();
            lblSonuc = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 90);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 0;
            label1.Text = "Ödeme Tipi:";
            // 
            // btnOdemeYap
            // 
            btnOdemeYap.Location = new Point(324, 199);
            btnOdemeYap.Name = "btnOdemeYap";
            btnOdemeYap.Size = new Size(151, 36);
            btnOdemeYap.TabIndex = 1;
            btnOdemeYap.Text = "Ödeme Yap";
            btnOdemeYap.UseVisualStyleBackColor = true;
            btnOdemeYap.Click += btnOdemeYap_Click;
            // 
            // cmbOdemeTipi
            // 
            cmbOdemeTipi.FormattingEnabled = true;
            cmbOdemeTipi.Items.AddRange(new object[] { "Seçiniz", "CreditCard", "MailOrder", "ApplePay", "GooglePay" });
            cmbOdemeTipi.Location = new Point(324, 87);
            cmbOdemeTipi.Name = "cmbOdemeTipi";
            cmbOdemeTipi.Size = new Size(151, 28);
            cmbOdemeTipi.TabIndex = 2;
            cmbOdemeTipi.Tag = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 146);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 3;
            label2.Text = "Tutar:";
            // 
            // txtTutar
            // 
            txtTutar.Location = new Point(324, 143);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(151, 27);
            txtTutar.TabIndex = 4;
            // 
            // lblSonuc
            // 
            lblSonuc.AutoSize = true;
            lblSonuc.Location = new Point(188, 263);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(52, 20);
            lblSonuc.TabIndex = 5;
            lblSonuc.Text = "Sonuç:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSonuc);
            Controls.Add(txtTutar);
            Controls.Add(label2);
            Controls.Add(cmbOdemeTipi);
            Controls.Add(btnOdemeYap);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnOdemeYap;
        private ComboBox cmbOdemeTipi;
        private Label label2;
        private TextBox txtTutar;
        private Label lblSonuc;
    }
}
