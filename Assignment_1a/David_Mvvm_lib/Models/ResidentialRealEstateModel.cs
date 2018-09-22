using System;
using David_Mvvm_lib.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David_Mvvm_lib.Models
{
	public class ResidentialRealEstateModel : BaseHouseModel
	{
		protected BuildingType ResBuildingType { get; set; }

		public ResidentialRealEstateModel(string ID) : base(ID)
		{
			Category = "Residential";
		}
	}
}
