using Radore_OOP.Interfaces;

namespace Radore_OOP.Classes
{
    public class SmartChild : Child, IRead, IListen, IWrite
    {
        public void listen(string name)
        {
            Console.WriteLine($"{name} listening...");
        }

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