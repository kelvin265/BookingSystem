using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Helpers;

namespace BookingSystem.Classes
{
    internal class user
    {
        database db = new database();
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }

        public user(int id, string username, string name, string email,  string phone, string type, string password)
        {
            Id = id;
            Username = username;
            Name = name;
            Email = email;
            Phone = phone;
            Type = type;
            Password = password;
        }

        public bool addUser(user user)
        {
            bool value = false;
            string query = "insert into user Values(" + user.Id + ",'" + user.Username + "','" + user.Name + "', '" + user.Email+ "',  '" + user.Phone + "', '" + user.Type + "', '" + user.Password + "')";
            if (db.insert(query))
            {
                value = true;
            }
            return value;

        }

        public bool updateUser(user user)
        {
            bool value = false;
            string query = "update user set username='" + user.Username + "', name='" + user.Name + "', email='" + user.Email + "',phone='" + user.Phone + "',type='" + user.Type + "',password='" + user.Password + "' where id=" + user.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }

        public bool deleteUser(user user)
        {
            bool value = false;
            string query = "delete from user where id=" + user.Id + "";
            if (db.update(query))
            {
                value = true;
            }
            return value;

        }
    }
}
