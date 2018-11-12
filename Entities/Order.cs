using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Order
    {
        private Bike bike;
        private Rentee rentee;
        private DateTime rentDate;
        private DateTime deliveryDate;
        private int id;

        public Order(DateTime deliveryDate, DateTime rentDate, Rentee rentee, Bike bike)
        {
            DeliveryDate = deliveryDate;
            RentDate = rentDate;
            Rentee = rentee;
            Bike = bike;
        }

        public Order(int id, DateTime deliveryDate, DateTime rentDate, Rentee rentee, Bike bike) : this(deliveryDate, rentDate, rentee, bike)
        {
            Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        public DateTime RentDate
        {
            get { return rentDate; }
            set { rentDate = value; }
        }

        public Rentee Rentee
        {
            get { return rentee; }
            set { rentee = value; }
        }

        public Bike Bike
        {
            get { return bike; }
            set { bike = value; }
        }

    }
}
