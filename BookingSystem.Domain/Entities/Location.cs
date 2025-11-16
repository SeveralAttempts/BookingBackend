using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Domain.Exceptions;

namespace BookingSystem.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; }
        public string Country { get; } = string.Empty;
        public string City { get; } = string.Empty;
        public string Address { get; } = string.Empty;

        private Location(Guid id, string country, string city, string address)
        {
            Id = id;
            Country = country;
            City = city;
            Address = address;
        }

        public static Location Create(Guid id, string country, string city, string address)
        {
            if (id == Guid.Empty)
            {
                throw new DomainException("Location Id can not be empty.");
            }

            if (string.IsNullOrEmpty(country) || string.IsNullOrWhiteSpace(country))
            {
                throw new DomainException("Country can not be empty, null or whitespace.");
            }

            if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city))
            {
                throw new DomainException("City can not be empty, null or whitespace.");
            }

            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                throw new DomainException("Address can not be empty, null or whitespace.");
            }

            return new Location(id, country, city, address);
        }
    }
}