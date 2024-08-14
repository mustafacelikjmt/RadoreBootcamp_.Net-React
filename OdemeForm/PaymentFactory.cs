using System.Reflection;

namespace OdemeForm
{
    public class PaymentFactory
    {
        public IPaymentType InstanceCreate(string className)
        {
            // Proje içinde parametre olarak gelen bir class olduğunda. runtime da dinamik olarak nesne oluşturur
            // Oluşturulan nesne IPaymentType a cast ederek oluşturur.
            var newInstance = Assembly.GetAssembly(typeof(IPaymentType)).CreateInstance("OdemeForm." + className);
            return (IPaymentType)newInstance;
        }
    }
}