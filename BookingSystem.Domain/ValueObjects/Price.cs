using BookingSystem.Domain.Exceptions;

namespace BookingSystem.Domain.ValueObjects
{
    public record Price
    {
        public decimal Amount { get; }

        private Price(decimal amount)
        {
            Amount = amount;
        }

        public static Price Create(decimal amount)
        {
            if (amount < 0)
            {
                throw new DomainException("Price can not be less than zero.");
            }

            return new Price(amount);
        }
    }
}