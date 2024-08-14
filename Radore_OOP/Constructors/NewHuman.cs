namespace Radore_OOP.Constructors
{
    public class NewHuman
    {
        public string name;
        public string surName;
        public Head head;

        public NewHuman(string name, string surName, Head head)
        {
            this.head = head;
            this.surName = surName;
            this.name = name;
        }

        public void appointmentSave()
        {
            Console.WriteLine($"Randevu alan kişinin adı {name} soyadı {surName} göz rengi {head.eye.color} burnu {head.nose.type} kulağı {head.ear.shape}");
        }
    }
}