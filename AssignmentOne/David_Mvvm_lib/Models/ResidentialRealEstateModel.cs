﻿using System;
using David_Mvvm_lib.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace David_Mvvm_lib.Models
{
	[Serializable]
	public class ResidentialRealEstateModel : BaseHouseModel
	{
		protected BuildingType ResBuildingType { get; set; }

		public ResidentialRealEstateModel() { }

		public ResidentialRealEstateModel(string ID) : base(ID)
		{
			Category = "Residential";
		}
	}
}
