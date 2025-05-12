using AcmeSchool.Domain.Interfaces;

namespace AcmeSchool.Infrastructure.Payment
{
    public class MockPaymentGateway : IPaymentGateway
    {
        /// <summary>
        /// Simulates a payment process with additional validation.
        /// </summary>
        public bool Charge(decimal amount)
        {
            // Simulate network latency
            Thread.Sleep(100); // 100 ms delay

            // Reject negative or zero payments
            if (amount <= 0)
                return false;

            // Simulate random payment failure (e.g. insufficient funds, card declined)
            var rand = new Random();
            int outcome = rand.Next(1, 101); // 1 to 100

            if (outcome <= 5) // 5% failure rate
                return false;

            return true;
        }
    }
}
