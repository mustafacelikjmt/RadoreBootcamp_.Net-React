namespace Radore_OOP.Constructors2
{
    public class Chassis
    {
        public Brand brand;
        public Model model;
        public Door door;
        public Window window;
        public string chasisType;

        public Chassis(Brand brand, Model model, Door door, Window window, string chasisType)
        {
            this.brand = brand;
            this.model = model;
            this.door = door;
            this.window = window;
            this.chasisType = chasisType;
        }
    }
}