using Radore_OOP.Interfaces;

namespace Radore_OOP.Classes
{
    public class Mother : Human, IRead, IWrite
    {
        public void read(string name)
        {
            Console.WriteLine($"{name} reading...");
        }

        public void write(string name)
        {
            Console.WriteLine($"{name} writing...");
        }
    }
}