using Radore_OOP.AbstractClasses;
using Radore_OOP.Classes;
using Radore_OOP.Constructors;
using Radore_OOP.Constructors2;
using Radore_OOP.HomeWork.Week_1.InterfaceAndAbstract;
using Radore_OOP.Overrides;
using Radore_OOP.Reflections;
using Radore_OOP.Solid.Good;
using System.Reflection; //using Radore_OOP.Solid.Bad;

Human human = new Human();
human.name = "Ibrahim";
human.surName = "Gokyar";
human.age = 44;
human.salary = 0.0;
human.gender = true;
human.sleep(human.name, human.surName);
Human human2 = new Human("Hakan", "Yilmaz");
new Human("Hakan", "Yilmaz", 44, 3.14, true);

Car car = new Car();
car.brand = "Jeep";
car.model = "Renegade";
car.type = "Suv";
car.vehicleDoor = 4;
car.vehicleGlass = 8;
car.isMoving(car.model);

Mother mother = new Mother();
mother.name = "Fahriye";
mother.surName = "Gokyar";
mother.age = 60;
mother.gender = false;
mother.fullName(mother.name, mother.surName);
mother.read(mother.name);
mother.write(mother.name);

Father father = new Father();
father.name = "Kasım";
father.surName = "Gokyar";
father.fullName(father.name, father.surName);
father.read(father.name);
father.listen(father.name);

Child child = new Child();
child.fullName("İbrahim", "Gokyar");

SmartChild smartChild = new SmartChild();
smartChild.fullNameAttributeWrite("Hakan", "Yilmaz", "Smart");
smartChild.read("Hakan");
smartChild.listen("Hakan");
smartChild.write("Hakan");

GoodChild goodChild = new GoodChild();
goodChild.name = "Mehmet";
goodChild.surName = "Yildiz";
goodChild.attribute = "Good";
goodChild.fullNameAttributeWrite(goodChild.name, goodChild.surName, goodChild.attribute);
goodChild.listen(goodChild.name);
goodChild.write(goodChild.name);

Mathematics m = new();
int value = m.addition(5, 2);
Console.WriteLine("Toplam: " + value);
m.addition(5, 4, 3);

GeneralManager generalManager = new();
Manager manager = new();
Programmer programmer = new();
Intern intern = new Intern();
double totalSalary = 0.0;
totalSalary += generalManager.salary();
totalSalary += manager.salary();
totalSalary += programmer.salary();
totalSalary += intern.salary();
Console.WriteLine("Total Salary: " + totalSalary);
Employe[] employe = { generalManager, manager, programmer, intern };
double salaryTotal = 0.0;
for (int i = 0; i < employe.Length; i++)
{
    salaryTotal += employe[i].salary();
}
Console.WriteLine("Çalışanların toplam maaşı " + salaryTotal + " TL");

Bmw bmw = new Bmw();
Mercedes mercedes = new Mercedes();
Porche porche = new Porche();
bmw.Fly().Swim(); // Trying method chaining.
bmw.Speed();
mercedes.Fly().Swim();
porche.Speed();
double totalGasoline = bmw.gasolineLiter() + mercedes.gasolineLiter() + porche.gasolineLiter();
Console.WriteLine(totalGasoline + " liter gasoline they spend");

Eye eye = new("Brown");
Ear ear = new("Wide");
Nose nose = new("Belt");
Head head = new(eye, ear, nose);
NewHuman newHuman = new("Mustafa", "Celik", head);
newHuman.appointmentSave();

Brand brand = new("BMW");
Model model = new("X5");
Door door = new(4);
Window window = new(4);
Chassis chassis = new(brand, model, door, window, "Sedan");
NewCar newCar = new(chassis, 20000000.0);
newCar.placeOrder();

//arrays
string[] days = new string[7];
days[0] = "pazartesi";
days[1] = "salı";
days[2] = "çarşamba";
days[3] = "perşembe";
days[4] = "cuma";
days[5] = "cumartesi";
days[6] = "pazar";

for (int i = 0; i < days.Length; i++)
{
    Console.WriteLine(days[i]);
}

int[] numbers = { 2, 4, 6, 7, 9, 11, 22, 33, 44, 55, 66 };
int total = 0;
for (int i = 0; i < numbers.Length; i++)
{
    total += numbers[i];
}
Console.WriteLine("Sayıların toplamı " + total);

List<int> list = new List<int>();
list.Add(35);
list.Add(45);
list.Add(33);
list.Add(22);

List<Personnel> personnelList = new List<Personnel>();
Personnel p1 = new Personnel("ibrahim", "gokyar", 3000.0);
Personnel p2 = new Personnel("hakan", "yilmaz", 4000.0);
Personnel p3 = new Personnel("metin", "yildiz", 5000.0);
personnelList.Add(p1);
personnelList.Add(p2);
personnelList.Add(p3);
double personnelSalaryTotal = 0.0;
//string[] colors = { "yellow", "blue", "green", "white" };
foreach (Personnel item in personnelList)
{
    Console.WriteLine($"Personelin adı {item.name} soyadı {item.surName} maaşı {item.salary}");
    personnelSalaryTotal += item.salary;
}
Console.WriteLine("Personellerin toplam maaşı: " + personnelSalaryTotal + " TL");

//XmlLog xmlLog = new(); // kötü senarya
//DbLog dbLog = new();
//JsonLog jsonLog = new();
//Logger logger = new(dbLog, xmlLog, jsonLog);
//logger.LogSave(LogType.Xml, "303 no lu hata kodu çalıştı");

DbLog dbLog = new DbLog();
Logger logger = new Logger(dbLog); // Burda logger ILog türünden bi sınıf bekliyor. Ve bu interface i implemente eden herangibi bi sınıfı alması gerekiyor.
logger.LogSave("303 nolu hata kodu oluştu"); // Bu sınıfı verdiğimizde LogSave metodu ile dbLog un içindeki log metodunu aktif ediyoruz.

Child1 child1 = new Child1();
child1.write();

Type t = typeof(MyClass);
MethodInfo[] mi = t.GetMethods();
Console.WriteLine("Nesnenin adı:" + t.Name);
foreach (var info in mi)
{
    ParameterInfo[] pi = info.GetParameters();
    Console.WriteLine($"Metod adı: {info.Name} Dönüş tipi: {info.ReturnType}");
    if (pi.Length > 0)
    {
        Console.WriteLine("Parametre var ");
    }
    for (int i = 0; i < pi.Length; i++)
    {
        Console.WriteLine($"{i + 1} .parametre : Dönüş Değeri : {pi[i].ParameterType.Name} Adı : {pi[i].Name}");
    }
}