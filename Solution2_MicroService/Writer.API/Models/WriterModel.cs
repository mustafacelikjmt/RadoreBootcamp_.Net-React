namespace Writer.API.Models
{
    public class WriterModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WriterModel()
        {
        }

        public WriterModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}