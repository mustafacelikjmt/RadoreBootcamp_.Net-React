namespace SerializationRadoreOrnek
{
    [Serializable]
    public class Product
    {
        public string name { get; set; }
        public DateTime expireDate { get; set; }
        public double price { get; set; }
    }
}