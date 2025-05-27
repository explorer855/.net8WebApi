namespace WebApi.Examples.Factory
{
    internal class StripeFactory : PaymentFactory
    {
        public override PaymentGateway CreateGateway()
        {
            throw new NotImplementedException();
        }
    }
}