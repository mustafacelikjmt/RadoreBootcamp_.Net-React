namespace Radore_OOP.HomeWork.Week_1.InterfaceAndAbstract
{
    public class Porche : Cars, ISpeed
    {
        public override double gasolineLiter()
        {
            return 80.0;
        }

        public void Speed()
        {
            Console.WriteLine($"{GetType().Name} is going too fast");
        }
    }
}