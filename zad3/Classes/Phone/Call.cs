using System;
using zad3.Enums;

namespace zad3.Classes
{
    public class Call
    {
        public DateTime callDate;
        public Status status;
        public int Length { get; set; } = 0;

        public override string ToString()
        {
            return $"{callDate.ToString("d/M/yyyy")} {Length} - {status}\n";
        }
    }
}
