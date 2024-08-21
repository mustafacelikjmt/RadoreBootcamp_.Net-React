namespace OdemeForm
{
    public class CreditCard : IPaymentType
    {
        public string payment(double amount)
        {
            return $" {GetType().Name} ile {amount} TL ödeme yapıldı";
        }
    }
}