namespace OdemeForm
{
    public class GooglePay : IPaymentType
    {
        public string payment(double amount)
        {
            return $" {GetType().Name} ile {amount} TL ödeme yapıldı";
        }
    }
}