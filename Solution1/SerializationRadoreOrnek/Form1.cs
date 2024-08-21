using Newtonsoft.Json;
using System.Xml.Serialization;

namespace SerializationRadoreOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                name = txtAd.Text,
                phone = txtTelefon.Text,
                birthday = dateTimePicker1.Value,
                department = txtDepartman.Text,
                salary = Convert.ToInt32(txtMaas.Text),
                additionalInfo = "Serile�tirme olmayacak"
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            FileStream fsout = new FileStream("employee.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    serializer.Serialize(fsout, emp);
                    MessageBox.Show("Veriler serile�tirildi");
                    txtAd.Text = "";
                    txtTelefon.Text = "";
                    txtDepartman.Text = "";
                    txtMaas.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata olu�tu: " + ex.Message.ToString());
            }
            finally { fsout.Close(); }
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            FileStream fsin = new FileStream("employee.xml", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    emp = (Employee)serializer.Deserialize(fsin);
                    txtAd.Text = emp.name;
                    txtTelefon.Text = emp.phone;
                    txtDepartman.Text = emp.department;
                    txtMaas.Text = emp.salary.ToString();
                    dateTimePicker1.Value = emp.birthday;
                    MessageBox.Show("Veriler deserile�tirildi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata olu�tu: " + ex.Message.ToString());
            }
            finally { fsin.Close(); }
        }

        private void btnJsonSerialize_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.name = "Product 1";
            product.expireDate = DateTime.Now;
            product.price = 3.14;

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"C:\Users\musta\source\repos\RadoreBootcamp_.Net-React\SerializationRadoreOrnek\product.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, product);
                    MessageBox.Show("Serile�tirildi");
                }
            }
        }

        private void btnJsonDeserialize_Click(object sender, EventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader file = File.OpenText(@"C:\Users\musta\source\repos\RadoreBootcamp_.Net-React\SerializationRadoreOrnek\product.json"))
            {
                using (JsonReader reader = new JsonTextReader(file))
                {
                    Product readProduct = (Product)serializer.Deserialize(reader, typeof(Product));
                    MessageBox.Show($"�r�n Ad�: {readProduct.name} fiyat�: {readProduct.price.ToString()}");
                }
            }
        }
    }
}