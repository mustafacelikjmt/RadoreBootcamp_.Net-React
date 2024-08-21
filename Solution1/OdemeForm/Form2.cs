using RadoreClassLibrary;
using RadoreClassLibrary.Data;

namespace OdemeForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Mathematics mathematics = new Mathematics();
            SqlClient sqlClient = new SqlClient();
            int getResult = mathematics.total(Convert.ToInt32(txtSayi1.Text), Convert.ToInt32(txtSayi2.Text));
            MessageBox.Show("Toplam: " + getResult);
        }
    }
}