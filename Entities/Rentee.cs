using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rentee : IPersistable
    {
        private string name;
        private string address;
        private string phoneNumber;
        private DateTime registerDate;
        private int id;

        public Rentee(DateTime registerDate, string phoneNumber, string address, string name)
        {
            if (registerDate != null)
            {
                RegisterDate = registerDate;
            }
            PhoneNumber = phoneNumber;
            if (!string.IsNullOrEmpty(address))
            {
                Address = address;
            }
            Name = name;
        }

        public Rentee(int id, DateTime registerDate, string phoneNumber, string address, string name) : this(registerDate, phoneNumber, address, name)
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

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return Name + ", adresse: " + Address + ", tlf: " + PhoneNumber;
        }
        int IPersistable.id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
