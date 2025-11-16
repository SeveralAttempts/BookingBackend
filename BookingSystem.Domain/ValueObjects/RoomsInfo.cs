using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Domain.Exceptions;

namespace BookingSystem.Domain.ValueObjects
{
    public record RoomsInfo
    {
        public ushort AllRoomsAmount { get; }
        public ushort RoomsAvailable { get; }
        public ushort RoomsReserved { get; }

        private RoomsInfo(ushort allRoomsAmount, ushort roomsAvailable, ushort roomsReserved)
        {
            AllRoomsAmount = allRoomsAmount;
            RoomsAvailable = roomsAvailable;
            RoomsReserved = roomsReserved;
        }

        public static RoomsInfo Create(ushort allRoomsAmount, ushort roomsAvailable, ushort roomsReserved)
        {
            if (allRoomsAmount == 0)
            {
                throw new DomainException("It cant be the place has no rooms at all.");
            }

            if (roomsAvailable + roomsReserved != allRoomsAmount)
            {
                throw new DomainException("Available and reserved rooms in summary should be equal to all rooms amount.");
            }

            return new RoomsInfo(allRoomsAmount, roomsAvailable, roomsReserved);
        }
    }
}