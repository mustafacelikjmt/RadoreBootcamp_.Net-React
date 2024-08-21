namespace OdemeForm
{
    public class MailOrder : IPaymentType
    {
        public string payment(double amount)
        {
            return $" {GetType().Name} ile {amount} TL ödeme yapıldı";
        }
    }
}