using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using David_Mvvm_lib.Enums;

namespace David_Mvvm_lib.Models
{
	public class ComercialRealEstateModel : BaseHouseModel
	{
		public ComercialRealEstateModel () { }
		public ComercialRealEstateModel(string ID) : base(ID)
		{
			Category = "Comercial";
		}
	}
}
