using Radore_OOP.Interfaces;

namespace Radore_OOP.Classes
{
    public class GoodChild : Child, IListen, IWrite
    {
        public void listen(string name)
        {
            Console.WriteLine($"{name} listening...");
        }

        public void write(string name)
        {
            Console.WriteLine($"{name} writing...");
        }
    }
}