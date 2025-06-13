namespace WebApi.Examples.Factory
{
    internal class PayPalFactory : PaymentFactory
    {
        public override PaymentGateway CreateGateway()
        {
            throw new NotImplementedException();
        }
    }
}