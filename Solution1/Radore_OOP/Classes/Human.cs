namespace Radore_OOP.Classes
{
    public class Human
    {
        public string name = "Mustafa";
        public string surName = "Celik";
        public int age = 0;
        public double salary = 0.0;
        public bool gender = false;

        public void sleep(string nam, string surNam)
        {
            Console.WriteLine($"{nam} {surNam} Sleeping..");
        }

        public void fullName(string nam, string surNam)
        {
            Console.WriteLine($"Person Name: {nam}'s last name is {surNam}");
        }

        public Human()
        {
        }

        public Human(string name, string surName)
        {
            this.name = name;
            this.surName = surName;
        }

        public Human(string name, string surName, int age, double salary, bool gender)
        {
            this.name = name;
            this.surName = surName;
            this.age = age;
            this.salary = salary;
            this.gender = gender;
        }
    }
}