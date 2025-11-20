using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Domain.Exceptions;

namespace BookingSystem.Domain.ValueObjects
{
    public class CheckInTimeRange
    {
        public TimeOnly TimeFrom { get; }
        public TimeOnly TimeTo { get; }

        private CheckInTimeRange(TimeOnly timeFrom, TimeOnly timeTo)
        {
            TimeFrom = timeFrom;
            TimeTo = timeTo;
        }

        public static CheckInTimeRange Create(TimeOnly timeFrom, TimeOnly timeTo)
        {
            if (timeFrom > timeTo)
            {
                throw new DomainException("Check-in start time can not be higher than end time.");
            }

            return new CheckInTimeRange(timeFrom, timeTo);
        }

        public TimeSpan GetDuration() => TimeTo - TimeFrom;
    }
}