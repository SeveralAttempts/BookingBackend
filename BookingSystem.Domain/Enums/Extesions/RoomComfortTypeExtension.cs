using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Domain.Exceptions;

namespace BookingSystem.Domain.Enums.Extesions
{
    public static class RoomComfortTypeExtension
    {
        public static string ToDisplay(this RoomComfortType type)
        {
            return type switch
            {
                RoomComfortType.Standart => "Standart",
                RoomComfortType.Premium => "Premium",
                RoomComfortType.Luxe => "Luxe",
                RoomComfortType.PresidentLuxe => "PresidentLuxe",
                _ => throw new DomainException("Unhandled RoomComfortType enum value in ToDisplay extension method.")
            };
        }
    }
}