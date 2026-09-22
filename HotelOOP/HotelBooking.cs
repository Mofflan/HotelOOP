using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOOP
{
    internal class HotelBooking
    {
        public string GuestName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LengthOfStayInDays { get; set; }

        public int GuestKundvagn { get; set; } = 0;

        public HotelBooking() {}

        public HotelBooking(string guestName, DateTime startDate, int lengthOfStayInDays)
        {
            GuestName = guestName;
            StartDate = startDate;
            LengthOfStayInDays = lengthOfStayInDays;
            EndDate = StartDate.AddDays(LengthOfStayInDays);
            //GuestKundvagn = 1337 * lengthOfStayInDays;

        }
         public void PrintGuest()
        {
            Console.WriteLine($" \n{GuestName} \nStartDate: {StartDate}\nEndDate: {EndDate.ToShortDateString()}\n");
            
        }

        public void AddDays(int sumDays)
        {
            sumDays = sumDays + LengthOfStayInDays;
            EndDate = StartDate.AddDays(sumDays);
        }

        public int CalculateCheckout()
        {
            GuestKundvagn = 1337 * LengthOfStayInDays;
            //cart = nötter;

            return GuestKundvagn;
        }

    }
}
