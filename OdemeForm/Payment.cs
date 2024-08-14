namespace OdemeForm
{
    public class Payment
    {
        public IPaymentType _paymentType;

        public Payment(IPaymentType paymentType)
        {
            _paymentType = paymentType;
        }

        public string MakePayment(double amount)
        {
            return _paymentType.payment(amount);
        }
    }
}