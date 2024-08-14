namespace Radore_OOP.AbstractClasses
{
    public abstract class Employe
    {
        public abstract double salary();

        public void startWorking()
        {
            Console.WriteLine("Started to work");
        }
    }
}