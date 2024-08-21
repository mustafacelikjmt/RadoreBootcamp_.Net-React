namespace SerializationRadoreOrnek
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSerialize = new Button();
            txtAd = new TextBox();
            txtTelefon = new TextBox();
            txtDepartman = new TextBox();
            txtMaas = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnDeserialize = new Button();
            btnJsonSerialize = new Button();
            btnJsonDeserialize = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 53);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 108);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 1;
            label2.Text = "Telefon:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 159);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 2;
            label3.Text = "Doğum Tarihi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(148, 217);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 3;
            label4.Text = "Departman:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(148, 269);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 4;
            label5.Text = "Maaş:";
            // 
            // btnSerialize
            // 
            btnSerialize.Location = new Point(148, 323);
            btnSerialize.Name = "btnSerialize";
            btnSerialize.Size = new Size(125, 29);
            btnSerialize.TabIndex = 5;
            btnSerialize.Text = "Serialize";
            btnSerialize.UseVisualStyleBackColor = true;
            btnSerialize.Click += btnSerialize_Click;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(346, 50);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(125, 27);
            txtAd.TabIndex = 6;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(346, 105);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(125, 27);
            txtTelefon.TabIndex = 7;
            // 
            // txtDepartman
            // 
            txtDepartman.Location = new Point(346, 214);
            txtDepartman.Name = "txtDepartman";
            txtDepartman.Size = new Size(125, 27);
            txtDepartman.TabIndex = 8;
            // 
            // txtMaas
            // 
            txtMaas.Location = new Point(346, 266);
            txtMaas.Name = "txtMaas";
            txtMaas.Size = new Size(125, 27);
            txtMaas.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(346, 154);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 10;
            // 
            // btnDeserialize
            // 
            btnDeserialize.Location = new Point(346, 323);
            btnDeserialize.Name = "btnDeserialize";
            btnDeserialize.Size = new Size(125, 29);
            btnDeserialize.TabIndex = 11;
            btnDeserialize.Text = "Deserialize";
            btnDeserialize.UseVisualStyleBackColor = true;
            btnDeserialize.Click += btnDeserialize_Click;
            // 
            // btnJsonSerialize
            // 
            btnJsonSerialize.Location = new Point(148, 395);
            btnJsonSerialize.Name = "btnJsonSerialize";
            btnJsonSerialize.Size = new Size(125, 29);
            btnJsonSerialize.TabIndex = 12;
            btnJsonSerialize.Text = "Json Serialize";
            btnJsonSerialize.UseVisualStyleBackColor = true;
            btnJsonSerialize.Click += btnJsonSerialize_Click;
            // 
            // btnJsonDeserialize
            // 
            btnJsonDeserialize.Location = new Point(346, 395);
            btnJsonDeserialize.Name = "btnJsonDeserialize";
            btnJsonDeserialize.Size = new Size(125, 29);
            btnJsonDeserialize.TabIndex = 13;
            btnJsonDeserialize.Text = "Json Deserialize";
            btnJsonDeserialize.UseVisualStyleBackColor = true;
            btnJsonDeserialize.Click += btnJsonDeserialize_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 533);
            Controls.Add(btnJsonDeserialize);
            Controls.Add(btnJsonSerialize);
            Controls.Add(btnDeserialize);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtMaas);
            Controls.Add(txtDepartman);
            Controls.Add(txtTelefon);
            Controls.Add(txtAd);
            Controls.Add(btnSerialize);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSerialize;
        private TextBox txtAd;
        private TextBox txtTelefon;
        private TextBox txtDepartman;
        private TextBox txtMaas;
        private DateTimePicker dateTimePicker1;
        private Button btnDeserialize;
        private Button btnJsonSerialize;
        private Button btnJsonDeserialize;
    }
}
