using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Helpers;

namespace BookingSystem.Classes
{
    internal class room
    {
        database db = new database();
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public float Price { get; set; }

        public room(int id, string roomnumber, string type, string status, float price)
        {
            Id = id;
            RoomNumber = roomnumber;
            Type = type;
            Status = status;
            Price = price;
        }

        public bool addRoom(room room)
        {
            bool value = false;
            string query = "insert into room Values(" + room.Id + ",'" + room.RoomNumber + "','" + room.Type + "', '" + room.Price + "', '" + room.Status + "')";
            if (db.insert(query))
            {
                value = true;
            }
            return value;

        }

        public bool updateRoom(room room)
        {
            bool value = false;
            string query = "update room set roomnumber='" + room.RoomNumber + "', type='" + room.Type + "', price='" + room.Price + "',status='" + room.Status + "' where id=" + room.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }

        public bool deleteRoom(room room)
        {
            bool value = false;
            string query = "delete from room where id=" + room.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }
    }
}
