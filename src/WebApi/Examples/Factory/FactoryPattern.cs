namespace WebApi.Examples.Factory
{
    public abstract class Order
    {
        public abstract void PlaceOrder();
    }

    public abstract class OrderFactory
    {
        public abstract Order CreateOrder();
    }

    public class CodOrder : Order
    {
        public override void PlaceOrder()
        {
            Console.WriteLine("Placing COD Order");
        }
    }

    public class CodOrderFactory : OrderFactory
    {
        public override Order CreateOrder()
        {
            Console.WriteLine("Creating COD Order request");
            return new CodOrder();
        }
    }


    public abstract class PaymentGateway
    {
        public abstract void ProcessPayment();
    }

    public abstract class PaymentFactory
    {
        public abstract PaymentGateway CreateGateway();
    }

    public class PayPalGateway : PaymentGateway
    {
        public override void ProcessPayment() => Console.WriteLine("Processing payment via PayPal");
    }

    public class StripeGateway : PaymentGateway
    {
        public override void ProcessPayment() => Console.WriteLine("Processing payment via Stripe");
    }

    // Abstract Factory for different payment providers
    public abstract class PaymentAbstractFactory
    {
        public abstract PaymentFactory CreatePaymentFactory();
    }

    public class PayPalAbstractFactory : PaymentAbstractFactory
    {
        public override PaymentFactory CreatePaymentFactory() => new PayPalFactory();
    }

    public class StripeAbstractFactory : PaymentAbstractFactory
    {
        public override PaymentFactory CreatePaymentFactory() => new StripeFactory();
    }
}
