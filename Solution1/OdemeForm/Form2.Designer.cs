namespace OdemeForm
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            txtSayi1 = new TextBox();
            txtSayi2 = new TextBox();
            btnHesapla = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 140);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 0;
            label1.Text = "Sayı1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 211);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 1;
            label2.Text = "Sayı2:";
            // 
            // txtSayi1
            // 
            txtSayi1.Location = new Point(305, 137);
            txtSayi1.Name = "txtSayi1";
            txtSayi1.Size = new Size(125, 27);
            txtSayi1.TabIndex = 2;
            // 
            // txtSayi2
            // 
            txtSayi2.Location = new Point(305, 208);
            txtSayi2.Name = "txtSayi2";
            txtSayi2.Size = new Size(125, 27);
            txtSayi2.TabIndex = 3;
            // 
            // btnHesapla
            // 
            btnHesapla.Location = new Point(305, 278);
            btnHesapla.Name = "btnHesapla";
            btnHesapla.Size = new Size(125, 29);
            btnHesapla.TabIndex = 4;
            btnHesapla.Text = "Hesapla";
            btnHesapla.UseVisualStyleBackColor = true;
            btnHesapla.Click += btnHesapla_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHesapla);
            Controls.Add(txtSayi2);
            Controls.Add(txtSayi1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSayi1;
        private TextBox txtSayi2;
        private Button btnHesapla;
    }
}