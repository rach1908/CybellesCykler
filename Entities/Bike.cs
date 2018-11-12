using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Bike : IPersistable
    {
        private double pricePerDay;
        private string bikeDescription;
        private int id;
        private BikeKind kind;


        public Bike(string bikeDescription, double pricePerDay)
        {
            BikeDescription = bikeDescription;
            PricePerDay = pricePerDay;
        }

        public Bike(int id, string bikeDescription, double pricePerDay) : this(bikeDescription, pricePerDay)
        {
            Id = id;
        }
        public BikeKind Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BikeDescription
        {
            get { return bikeDescription; }
            set { bikeDescription = value; }
        }

        public double PricePerDay
        {
            get { return pricePerDay; }
            set { pricePerDay = value; }
        }

    }
}
