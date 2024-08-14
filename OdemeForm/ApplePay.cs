namespace OdemeForm
{
    public class ApplePay : IPaymentType
    {
        public string payment(double amount)
        {
            return $" {GetType().Name} ile {amount} TL ödeme yapıldı";
        }
    }
}