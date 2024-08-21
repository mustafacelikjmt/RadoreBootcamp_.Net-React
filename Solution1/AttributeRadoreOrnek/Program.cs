using AttributeRadoreOrnek;

Student student = new();
student.name = "Mustafa";
student.surName = "Çelik";
student.department = "Yazılım";

Car car = new Car();
var i = car;
if (!RequirementCheck.Verify(i))
{
    Console.WriteLine($"{i.GetType().Name} bilgileri girilmelidir.");
}
else
{
    Console.WriteLine("Form başarılı");
}