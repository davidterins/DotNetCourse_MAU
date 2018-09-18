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

		HouseRepresentationViewModel _houseViewModel;
		public HouseRepresentationViewModel HouseViewModel
		{
			get => _houseViewModel;
			set
			{
				_houseViewModel = value;
				//houseCollection.View.Refresh();
				Console.WriteLine(_houseViewModel.HouseBase.ID);
				OnPropertyChanged(nameof(SelectedHouse));
			}
		}

		BaseHouseModel _selectedHouse;
		public BaseHouseModel SelectedHouse
		{
			get => _selectedHouse;
			set
			{
				_selectedHouse = value;
				//houseCollection.View.Refresh();
				Console.WriteLine(_selectedHouse.ID);
				OnPropertyChanged(nameof(SelectedHouse));
			}
		}

		private CollectionViewSource houseCollection;

		public Adress HouseAdress { get; set; }

		public MainWindowViewModel()
		{
			houses = new ObservableCollection<HouseRepresentationViewModel>();
			HouseRepresentationViewModel h = new HouseRepresentationViewModel();
			h.HouseBase = new House("lolID")
			{
				HouseAdress = new Adress("lolStreet", 23311, "lolCity", Country.Argentina),
				Category = "Residential",
				ResidentialBuldings = "Villas",
				CommercialBuilding = "Ship",
				LegalForm = "OwnerShip"
			};
		
			houses.Add(h);

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
		public ICommand EditHouseCommand { get; set; }
		public ICommand RemoveHouseCommand { get; set; }
		public ICommand AddHouseCommand { get; set; }

		public ICollectionView CollectionView
		{
			get
			{
				return this.houseCollection.View;
			}
		}

		private ObservableCollection<HouseRepresentationViewModel> houses;
		public ObservableCollection<HouseRepresentationViewModel> Houses
		{
			get => houses;
			set => houses = value;
		}

		void AddHouse()
		{
			var h = new HouseRepresentationViewModel();
			h.HouseBase = new House(_id)
			{
				Category = _category,
				ResidentialBuldings = _residentialBuildings,
				CommercialBuilding = _commercialBuilding,
				LegalForm = _legalForm
			};

			Houses.Add(h);
		}
	}
}
