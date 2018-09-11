using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Assignment_1a.Models;
using Assignment_1a.Models.Enums;
using Assignment_1a.ViewModels.Commands;
using System.Windows.Input;
using System.Windows.Data;

namespace Assignment_1a.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		string _category;
		public string Category
		{
			get => _category;
			set
			{
				_category = Helper.ConvertComobboxItemTotext(value);
				OnPropertyChanged(nameof(Category));
			}
		}

		string _residentialBuildings;
		public string ResidentialBuildings
		{
			get => _residentialBuildings;
			set
			{
				_residentialBuildings = Helper.ConvertComobboxItemTotext(value);
				OnPropertyChanged(nameof(ResidentialBuildings));
			}
		}

		string _commercialBuilding;
		public string CommercialBuilding
		{
			get => _commercialBuilding;
			set
			{
				_commercialBuilding = Helper.ConvertComobboxItemTotext(value);
				OnPropertyChanged(nameof(CommercialBuilding));
			}
		}

		string _legalForm;
		public string LegalForm
		{
			get => _legalForm;
			set
			{
				_legalForm = Helper.ConvertComobboxItemTotext(value);
				OnPropertyChanged(nameof(LegalForm));
			}
		}

		string _id;
		public string ID
		{
			get => _id;
			set
			{
				_id = value;
				OnPropertyChanged(nameof(ID));
			}
		}

		string _searchFilter;
		public string SearchFilter
		{
			get => _searchFilter;
			set
			{
				_searchFilter = value;
				houseCollection.View.Refresh();
				OnPropertyChanged(nameof(SearchFilter));
			}
		}

		private CollectionViewSource houseCollection;

		public Adress HouseAdress { get; set; }

		public MainWindowViewModel()
		{
			houses = new ObservableCollection<BaseHouseModel>();
			House house = new House("lolID")
			{
				HouseAdress = new Adress("lolStreet", 23311, "lolCity", Country.Argentina),
				Category = "Residential",
				ResidentialBuldings = "Villas",
				CommercialBuilding = "Ship",
				LegalForm = "OwnerShip"
			};

			houses.Add(house);

			houseCollection = new CollectionViewSource();
			houseCollection.Source = houses;
	
			houseCollection.Filter += usersCollection_Filter;

			AddHouseCommand = new ActionCommand(AddHouse);
		}

		private void usersCollection_Filter(object sender, FilterEventArgs e)
		{
			if (string.IsNullOrEmpty(_searchFilter))
			{
				e.Accepted = true;
				return;
			}

			var usr = e.Item as BaseHouseModel;
			string totalItemString = usr.Category + usr.CommercialBuilding + usr.ID + usr.LegalForm + usr.ResidentialBuldings;
			if (totalItemString.ToUpper().Contains(_searchFilter.ToUpper()))
			{
				e.Accepted = true;
			}
			else
			{
				e.Accepted = false;
			}
		}

		public ICommand AddHouseCommand { get; set; }

		List<BaseHouseModel> houseList;

		public ICollectionView CollectionView
		{
			get
			{
				return this.houseCollection.View;
			}
		}

		private ObservableCollection<BaseHouseModel> houses;
		public ObservableCollection<BaseHouseModel> Houses
		{
			get => houses;
			set => houses = value;
		}

		void AddHouse()
		{
			var house = new House(_id)
			{
				Category = _category,
				ResidentialBuldings = _residentialBuildings,
				CommercialBuilding = _commercialBuilding,
				LegalForm = _legalForm
			};

			Houses.Add(house);
		}
	}
}
