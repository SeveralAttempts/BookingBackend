using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Domain.Enums;
using BookingSystem.Domain.Exceptions;
using BookingSystem.Domain.ValueObjects;

namespace BookingSystem.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public RoomComfortType ComfortType { get; }
        public ushort RoomCapacity { get; }
        public Price Price { get; }

        private Room(Guid id, string name, RoomComfortType comfortType, ushort roomCapacity, Price price)
        {
            Id = id;
            Name = name;
            ComfortType = comfortType;
            RoomCapacity = roomCapacity;
            Price = price;
        }

        public static Room Create(Guid id, string name, RoomComfortType comfortType, ushort roomCapacity, Price price)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Room name can not be null, empty or whitespace.");
            }

            if (roomCapacity <= 0)
            {
                throw new DomainException("Room capacity can not be less or equal to zero.");
            }

            return new Room(id, name, comfortType, roomCapacity, price);
        }
    }
}