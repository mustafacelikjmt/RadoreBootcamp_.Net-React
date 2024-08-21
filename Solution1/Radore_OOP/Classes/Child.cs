namespace Radore_OOP.Classes
{
    public class Child : Human
    {
        public string attribute { get; set; }

        public void fullNameAttributeWrite(string name, string surName, string attributes)
        {
            Console.WriteLine($"{name} {surName} {attributes}");
        }
    }
}