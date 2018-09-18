﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment_1a.Models.Enums;
using System.Threading.Tasks;

namespace Assignment_1a.Models
{
    public abstract class BaseHouseModel
    {
        //Residential or commercial
        public string Category { get; set; }
        //Type of residential buildings - houses, villas, apartments, townhouses(row housed)
        public string ResidentialBuldings { get; set; }
        //Shops or warehouse, etc
        public string CommercialBuilding { get; set; }
        //Ownership, tenement or rental
        public string LegalForm { get; set; }
        //Object ID
        public string ID { get; }
        //Adress of building
        public Adress HouseAdress { get; set; }

        public BaseHouseModel(string ID)
        {
            this.ID = ID;
        }
    }

    public class Adress
    {
        public string StreetName { get; }
        public int ZipCode { get; }
        public string City { get; }
        public Country Country { get; }

        public Adress(string streetName, int zipCode, string city, Country country)
        {
            StreetName = streetName;
            ZipCode = zipCode;
            City = city;
			      Country = Country;
        }


    }
}
