using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Helpers;

namespace BookingSystem.Classes
{
    internal class review
    {
        database db = new database();
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookingId { get; set; }
        public string Date { get; set; }
        public string Review { get; set; }

        public review(int id, int customerId, int bookingId, string date, string review)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.BookingId = bookingId;
            this.Date = date;
            this.Review = review;
        }

        public bool addReview(review review)
        {
            bool value = false;
            string query = "insert into reviews Values(" + review.Id + ",'" + review.CustomerId + "','" + review.BookingId + "',  '" + review.Date + "','" + review.Review + "')";
            if (db.insert(query))
            {
                value = true;
            }
            return value;

        }

        public bool updateReview(review review)
        {
            bool value = false;
            string query = "update reviews set customerId='" + review.CustomerId + "', bookingId='" + review.BookingId + "',date='" + review.Date + "',review='" + review.Review + "' where id=" + review.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }

        public bool deleteReview(review review)
        {
            bool value = false;
            string query = "delete from reviews where id=" + review.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }
    }
}
