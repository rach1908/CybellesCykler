using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rentee
    {
        private string name;
        private string adress;
        private string phoneNumber;
        private DateTime registerDate;
        private int id;

        public Rentee(DateTime registerDate, string phoneNumber, string adress, string name)
        {
            RegisterDate = registerDate;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Name = name;
        }

        public Rentee(int id, DateTime registerDate, string phoneNumber, string adress, string name) : this(registerDate, phoneNumber, adress, name)
        {
            Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
