using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.SOLID.SRP
{
    /// <summary>
    /// Single Responsibility Principle (SRP): Bir class ya da method tek bir sorumluluk almalıdır.
    /// Bir method birden fazla iş yapıyorsa kohezyonu düşer.Ama SRP uygulanırsa yüksek kohezyon elde etmiş oluruz.
    /// Yüksek Kohezyon => Temiz ve sürdürülebilir kod.
    /// </summary>

    //BAD 
    public enum EPaymentType
    {
        CreditCard,
        BankTransfer
    }

    public class BadPaymentService
    {
        public void Payment(double amount, EPaymentType paymentType)
        {
            switch (paymentType)
            {
                case EPaymentType.CreditCard:
                    Console.WriteLine("credit card");
                    //kredi kartı ödeme işlemleri burada yapılır.
                    break;
                case EPaymentType.BankTransfer:
                    Console.WriteLine("bank transfer");
                    //Banka transfer ödeme işlemleri burada yapılır.
                    break;
            }
        }
    }

    //GOOD
    public interface IPaymentProcessor
    {
        void Payment(double amount);
    }
    public class PaymentWithCreditCard : IPaymentProcessor
    {
        public void Payment(double amount)
        {
            Console.WriteLine("credit card");
            //Kredi kartı ödeme işlemleri burada yapılır.
        }
    }
    public class PaymentWithBankTransfer : IPaymentProcessor
    {
        public void Payment(double amount)
        {
            Console.WriteLine("bank transfer");
            //Banka transfer ödeme işlemleri burada yapılır
        }
    }
    public class GoodPaymentService
    {
        private IPaymentProcessor _paymentProcessor;
        public GoodPaymentService(IPaymentProcessor payment)
        {
            _paymentProcessor = payment;
        }
        public void MakePayment(double amount)
        {
            _paymentProcessor.Payment(amount);
        }
    }
}
