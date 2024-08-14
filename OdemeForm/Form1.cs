using System.Data.SqlClient;

namespace OdemeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection();
            //SqlCommand command = new SqlCommand();
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (cmbOdemeTipi.SelectedItem == null || cmbOdemeTipi.SelectedItem.ToString() == "Seçiniz")
            {
                MessageBox.Show("Lütfen ödeme yöntemi seçiniz.");
            }
            else if (Convert.ToDouble(txtTutar.Text) < 1)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.");
            }
            else
            {
                string selectedPaymentType = cmbOdemeTipi.SelectedItem.ToString();
                double amount = Convert.ToDouble(txtTutar.Text);
                // lblSonuc.Text = $"Sonuç: {selectedPaymentType} ile {amount.ToString()} TL tutarýnda ödeme alýnmýþtýr";

                PaymentFactory factory = new();
                IPaymentType paymentType = factory.InstanceCreate(selectedPaymentType);
                Payment payment = new Payment(paymentType);
                lblSonuc.Text = payment.MakePayment(amount);
            }
        }
    }
}