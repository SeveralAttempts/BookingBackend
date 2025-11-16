using BookingSystem.Domain.Exceptions;

namespace BookingSystem.Domain.ValueObjects
{
    public record Price
    {
        public decimal Amount { get; }
        public ushort Discount { get; }

        private Price(decimal amount, ushort discount)
        {
            Amount = amount;
            Discount = discount;
        }

        public static Price Create(decimal amount, ushort discount)
        {
            if (amount < 0)
            {
                throw new DomainException("Price can not be less than zero.");
            }

            if (discount >= 0 && discount <= 100)
            {
                throw new DomainException("Price discount should be in range between 0 and 100.");
            }

            return new Price(amount, discount);
        }

        public decimal GetDiscountPrice()
        {
            return Amount - (Amount * (Discount / 100.0m));
        }
    }
}