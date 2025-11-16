using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Domain.Exceptions;
using BookingSystem.Domain.ValueObjects;

namespace BookingSystem.Domain.Entities
{
    public class Place
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public ushort Rating { get; }
        public Location Location { get; }
        public RoomsInfo RoomsInfo { get; }
        public Price AvaragePrice { get; }

        private Place(Guid id, string name, string description, ushort rating,
         Location location, RoomsInfo roomsInfo, Price avaragePrice)
        {
            Id = id;
            Name = name;
            Description = description;
            Rating = rating;
            Location = location;
            RoomsInfo = roomsInfo;
            AvaragePrice = avaragePrice;    
        }

        public static Place Create(Guid id, string name, string description, ushort rating,
         Location location, RoomsInfo roomsInfo, Price avaragePrice)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Place name can not be null, empty or whitespace.");
            }

            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("Place description can not be null, empty or whitespace.");
            }

            if (rating < 0 || rating >= 6)
            {
                throw new DomainException("Rating should be in range from 0 to 5.");
            }

            return new Place(id, name, description, rating, location, roomsInfo, avaragePrice);
        }
    }
}