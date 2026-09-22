using System.Runtime.CompilerServices;

namespace HotelOOP
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //Skapa list som innehåller klassen HotelBooking
            List<HotelBooking> guestList = new List<HotelBooking>();


            //DEBUG 
            guestList.Add(new HotelBooking("Kalle", DateTime.Now, 5));
            guestList.Add(new HotelBooking("Mathias", DateTime.Now, 1));
            guestList.Add(new HotelBooking("Axel", DateTime.Now, 2));



            bool bookingLoop = true;
            DateTime parsedDate;


            while (true)
            {
                Console.WriteLine("OOP HOTEL!!!!\n");
                Console.WriteLine("\n1.Book Guest\n2.Booking\n3.Exit ");

                int.TryParse(Console.ReadLine(), out int userInput);

                switch (userInput)
                {
                    case 1:

                        Console.WriteLine("Enter Start Date");
                        while (bookingLoop)
                        {

                            string dateString = Console.ReadLine();

                            try
                            {
                                parsedDate = DateTime.ParseExact(dateString, "yyyy-MM-dd", null);


                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ogiltigt datum");
                                continue;
                            }

                            if (parsedDate >= DateTime.Now)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter amount of days");
                                int.TryParse(Console.ReadLine(), out int day);
                                Console.WriteLine("Enter Guest Name");
                                guestList.Add(new HotelBooking(Console.ReadLine(), parsedDate, day));
                            }

                            break;
                        }

                        break;


                    case 2:


                        Console.Clear();

                        for (int i = 0; i < guestList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{guestList[i].GuestName}");
                        }

                        Console.WriteLine("\nVad är ditt bokningsnummer?\n");



                        int.TryParse(Console.ReadLine(), out int guestID);

                        guestID--;

                        if (guestID < 0 || guestID >= guestList.Count)
                        {
                            Console.WriteLine("Ej finns");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("1.Print Guest Info" +
                            "\n2.Add more Days" +
                            "\n3.Checkout");

                        int.TryParse(Console.ReadLine(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                guestList[guestID].PrintGuest();

                                break;
                            case 2:
                                Console.WriteLine("Ange hur många dagar gästen vill addera till sin semster");

                                int.TryParse(Console.ReadLine(), out int value);
                                AddMoreDays(guestID, value);
                                break;
                            case 3:
                                CheckOut(guestID);
                                break;
                            default:
                                Console.WriteLine("knas");
                                break;
                        }

                        break;
                    case 3:

                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("int pls");
                        break;
                }
            }

            void BookingMenu()
            {

            }
            void AddMoreDays(int guestID, int sumDays)
            {


                guestList[guestID].PrintGuest();


                guestList[guestID].AddDays(sumDays);


                guestList[guestID].PrintGuest();
            }

            void CheckOut(int guestID)
            {
                Console.Clear();
                int guestTotaltSum = guestList[guestID].CalculateCheckout();
                Console.WriteLine($"Total Amount: {guestTotaltSum} kr");
                guestList.Remove(guestList[guestID]);

            }

        }
    }
}
