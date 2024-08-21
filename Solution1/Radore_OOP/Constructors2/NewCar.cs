namespace Radore_OOP.Constructors2
{
    public class NewCar
    {
        public Chassis chassis;
        public double price;

        public NewCar(Chassis chassis, double price)
        {
            this.chassis = chassis;
            this.price = price;
        }

        public void placeOrder()
        {
            Console.WriteLine($"Sipariş verilen arabanın markası {chassis.brand.brandName} modeli {chassis.model.modelName} kapı sayısı {chassis.door.numberOfDoors} pencere sayısı {chassis.window.numberOfWindows} kasası {chassis.chasisType} fiyatı {price}");
        }
    }
}