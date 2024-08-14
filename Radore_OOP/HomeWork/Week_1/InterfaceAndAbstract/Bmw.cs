namespace Radore_OOP.HomeWork.Week_1.InterfaceAndAbstract
{
    public class Bmw : Cars, IFly, ISwim, ISpeed
    {
        public ISwim Fly()
        {
            Console.WriteLine($"{GetType().Name} flying in the air");
            return this;
        }

        public override double gasolineLiter()
        {
            return 60.0;
        }

        public void Speed()
        {
            Console.WriteLine($"{GetType().Name} is going too fast");
        }

        public void Swim()
        {
            Console.WriteLine($"{GetType().Name} swimming in the sea");
        }
    }
}