using David_Mvvm_lib.Enums;
using System;
using System.Xml.Serialization;

namespace David_Mvvm_lib.Models
{

	public abstract class BaseHouseModel
	{
		//Residential or commercial
		public string Category { get; set; }
		//Type of residential buildings - houses, villas, apartments, townhouses(row house) //Shops or warehouse
		public string BuildingType { get; set; }
		//Ownership, tenement or rental
		public string LegalForm { get; set; }
		//Object ID
		public string ID { get; }
		//Adress of building
		public Adress HouseAdress { get; set; }
		//Image
		public string Image { get; set; }

		public BuildingType RealEstateObjectType { get; set; }

		public BaseHouseModel() { }

		public BaseHouseModel(string ID)
		{
			this.ID = ID;
		}
	}

	public class Adress
	{
		public string StreetName { get; set; }
		public int? ZipCode { get; set; }
		public string City { get; set; }
		public Country Country { get; set; }

		public Adress() { }

		public Adress(string streetName, int? zipCode, string city, Country country)
		{
			StreetName = streetName;
			ZipCode = zipCode;
			City = city;
			Country = country;
		}


	}
}
