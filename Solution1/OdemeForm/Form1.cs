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
            GetPaymentType();
        }

        public void GetPaymentType()
        {
            string connectionString = @"Data Source=MUSTA\SQLEXPRESS;Initial Catalog=RadoreDB;Integrated Security=SSPI;";
            List<PaymentType> paymentType = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    paymentType = new List<PaymentType>();
                    paymentType.Add(new PaymentType
                    {
                        id = -1,
                        displayName = "�deme Tipi Se�iniz",
                        className = "�deme Tipi Se�iniz"
                    });

                    SqlCommand sqlCommand = new SqlCommand("Select * from PaymentType", conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        paymentType.Add(new PaymentType
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            className = reader["CLASS_NAME"].ToString(),
                            displayName = reader["DISPLAY_NAME"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.ToString());
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                cmbOdemeTipi.DataSource = paymentType;
                cmbOdemeTipi.DisplayMember = "displayName";
                cmbOdemeTipi.ValueMember = "className";
            }
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (cmbOdemeTipi.SelectedItem == null || cmbOdemeTipi.SelectedItem.ToString() == "Se�iniz")
            {
                MessageBox.Show("L�tfen �deme y�ntemi se�iniz.");
            }
            else if (Convert.ToDouble(txtTutar.Text) < 1)
            {
                MessageBox.Show("L�tfen ge�erli bir tutar giriniz.");
            }
            else
            {
                string selectedPaymentType = Convert.ToString(cmbOdemeTipi.SelectedValue);
                double amount = Convert.ToDouble(txtTutar.Text);
                // lblSonuc.Text = $"Sonu�: {selectedPaymentType} ile {amount.ToString()} TL tutar�nda �deme al�nm��t�r";

                PaymentFactory factory = new();
                IPaymentType paymentType = factory.InstanceCreate(selectedPaymentType);
                Payment payment = new Payment(paymentType);
                lblSonuc.Text = payment.MakePayment(amount);
            }
        }
    }
}