namespace Radore_OOP.Reflections
{
    public class MyClass
    {
        public int x;
        public int y;

        public MyClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void MessageShow()
        {
            Console.WriteLine($"x in değeri: {x} y nin değeri: {y}");
        }

        public string ReturnMessage()
        {
            return "bir mesaj";
        }

        public bool IsBetweeb(int i)
        {
            if (i > 0) return true;
            return false;
        }
    }
}