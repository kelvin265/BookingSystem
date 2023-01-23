using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Helpers;

namespace BookingSystem.Classes
{
    internal class booking
    {
        database db = new database();
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public string OpenDate { get; set; }
        public int TotalDays { get; set; }

        public float TotalCost { get; set; }

        public string Status { get; set; }


        public booking(int id, int customerId, int roomId, string openDate, int totalDays, float totalCost, string status)
        {
            Id = id;
            CustomerId = customerId;
            RoomId = roomId;
            OpenDate = openDate;
            TotalDays = totalDays;
            TotalCost = totalCost;
            Status = status;
        }

        public bool addBooking(booking booking)
        {
            bool value = false;
            string query = "insert into bookings Values(" + booking.Id + ",'" + booking.CustomerId + "','" + booking.RoomId + "', '" + booking.OpenDate + "','" + booking.TotalDays + "', '" + booking.TotalCost + "','" + booking.Status + "')";
            if (db.insert(query))
            {
                value = true;
            }
            return value;

        }

        public bool updateBooking(booking booking)
        {
            bool value = false;
            string query = "update bookings set customerId='" + booking.CustomerId + "', roomId='" + booking.RoomId + "', openDate='" + booking.OpenDate + "', totalDays='" + booking.TotalDays + "',totalCost='" + booking.TotalCost + "' ,status='" + booking.Status + "' where id=" + booking.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }

        public bool deleteBooking(booking booking)
        {
            bool value = false;
            string query = "delete from bookings where id=" + booking.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }

    }
}
