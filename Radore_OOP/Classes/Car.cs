namespace Radore_OOP.Classes
{
    public class Car
    {
        public string brand;
        public string model;
        public string type;
        public int vehicleDoor;
        public int vehicleGlass;

        public void isMoving(string m)
        {
            Console.WriteLine($"{brand} {m} Is going..");
        }
    }
}