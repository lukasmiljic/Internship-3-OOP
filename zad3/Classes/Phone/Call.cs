using System;
using zad3.Enums;

namespace zad3.Classes
{
    public class Call
    {
        public DateTime CallDate;
        public Status Status;
        public int Length { get; set; } = 0;

        public override string ToString()
        {
            return $"{CallDate.ToString("d/M/yyyy")} {Length} - {Status}\n";
        }
    }
}
