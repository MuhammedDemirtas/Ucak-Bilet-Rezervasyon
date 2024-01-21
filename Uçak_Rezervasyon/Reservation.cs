using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uçak_Rezervasyon
{
    internal class Reservation
    {
        public Aircraft Aircraft { get; set; }
        public Location Departure { get; set; }
        public Location Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Customer Customer { get; set; }
        public int SeatNumber { get; set; }
        public TimeSpan ReservationTime { get; }

        private static readonly Random random = new Random();

        int hour = random.Next(0, 24);
        int minute = random.Next(0, 60);

        public Reservation(Aircraft aircraft, Location departure, Location destination,
                           DateTime departureDate, DateTime returnDate, Customer customer)
        {
            Aircraft = aircraft;
            Departure = departure;
            Destination = destination;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
            Customer = customer;
            ReservationTime = new TimeSpan(hour, minute, 0);
            SeatNumber = random.Next(1, aircraft.Capacity + 1);
        }

            public override string ToString()
            {
                return $" - SAHİP(OWNER) = {Customer} \n - UÇAK(AİRCRAFT) = {Aircraft}  \n - LOKASYON(LOCATİONS) = Kalkış Noktası -> {Departure} / Varış Noktası -> {Destination}  \n \n - TARİH(DATE)/SAAT(TIME) = {DepartureDate.ToShortDateString()} - {ReturnDate.ToShortDateString()} - {ReservationTime} \n \n - KOLTUK NO (Seat Number) = {SeatNumber} \n \n >Rezervasyonunuz alınmıştır iyi uçuşlar dileriz.(Process done thanks!) \n !! Rezervasyon bilgileriniz ve ücretler e-mail adresinize gönderilmiştir !!(Check your e-mail)\n DEVAM İÇİN ENTER ";
            }

    }
}
