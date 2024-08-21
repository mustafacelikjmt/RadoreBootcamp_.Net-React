namespace Radore_OOP.HomeWork.Week_1.InterfaceAndAbstract
{
    public class Mercedes : Cars, IFly, ISwim
    {
        public ISwim Fly()
        {
            Console.WriteLine($"{GetType().Name} flying in the air");
            return this;
        }

        public override double gasolineLiter()
        {
            return 70.0;
        }

        public void Swim()
        {
            Console.WriteLine($"{GetType().Name} swimming in the sea");
        }
    }
}