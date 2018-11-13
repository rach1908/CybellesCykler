using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bike : IPersistable
    {
        private decimal pricePerDay;
        private string bikeDescription;
        private int id;
        private BikeKind kind;


        public Bike(string bikeDescription, decimal pricePerDay)
        {
            BikeDescription = bikeDescription;
            PricePerDay = pricePerDay;
        }

        public Bike(int id, string bikeDescription, decimal pricePerDay) : this(bikeDescription, pricePerDay)
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

        public decimal PricePerDay
        {
            get { return pricePerDay; }
            set { pricePerDay = value; }
        }

        int IPersistable.id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
