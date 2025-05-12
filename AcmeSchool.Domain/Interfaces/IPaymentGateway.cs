namespace AcmeSchool.Domain.Interfaces
{
    public interface IPaymentGateway
    {
        /// <summary>
        /// Simulates charging a fee for a student enrollment.
        /// </summary>
        /// <param name="amount">The amount to charge.</param>
        /// <returns>True if the payment was successful.</returns>
        bool Charge(decimal amount);
    }
}
