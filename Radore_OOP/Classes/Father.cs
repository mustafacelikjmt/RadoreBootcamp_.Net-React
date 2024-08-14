using Radore_OOP.Interfaces;

namespace Radore_OOP.Classes
{
    public class Father : Human, IRead, IListen
    {
        public void listen(string name)
        {
            Console.WriteLine($"{name} listening...");
        }

        public void read(string name)
        {
            Console.WriteLine($"{name} reading...");
        }
    }
}