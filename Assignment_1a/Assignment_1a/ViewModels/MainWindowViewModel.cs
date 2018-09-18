using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Assignment_1a.Models;
using Assignment_1a.Models.Enums;
using Assignment_1a.ViewModels.Commands;
using System.Windows.Input;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

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

		string _imageFilePath;
		public string ImageFilePath { get { return _imageFilePath; } set { _imageFilePath = value; OnPropertyChanged(nameof(ImageFilePath)); } }
		string _city;
		public string City { get { return _city; } set { _city = value; OnPropertyChanged(nameof(City)); } }
		int? _zip;
		public int? Zip { get { return _zip; } set { _zip = value; OnPropertyChanged(nameof(Zip)); } }
		Country _country;
		public Country Country_ { get { return _country; } set { _country = value; OnPropertyChanged(nameof(Country_)); } }
		string _street;
		public string Street { get { return _street; } set { _street = value; OnPropertyChanged(nameof(Street)); } }
		public List<Country> Countries { get { return Enum.GetValues(typeof(Country)).Cast<Country>().ToList(); } }


		HouseRepresentationViewModel _houseViewModel;
		public HouseRepresentationViewModel HouseViewModel
		{
			get => _houseViewModel;
			set
			{
				_houseViewModel = value;
				OnPropertyChanged(nameof(HouseViewModel));
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
			houses = new HouseViewModelCollection();
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

			houses.OnCollectionItemEdited += Houses_OnCollectionItemEdited;
			houseCollection.Filter += usersCollection_Filter;
			AddImageCommand = new ActionCommand(AddImage);
			AddHouseCommand = new ActionCommand(AddHouse);
			FinishEditCommand = new ActionCommand(FinishEdit);
		}

		public ICommand FinishEditCommand { get; set; }

		private void Houses_OnCollectionItemEdited(object sender, EventArgs e)
		{
			var itemToEdit = (HouseRepresentationViewModel)sender;
			HouseViewModel = itemToEdit;
			ID = itemToEdit.HouseBase.ID;
			Category = itemToEdit.HouseBase.Category;
			CommercialBuilding = itemToEdit.HouseBase.CommercialBuilding;
			LegalForm = itemToEdit.HouseBase.LegalForm;
			ResidentialBuildings = itemToEdit.HouseBase.ResidentialBuldings;
			City = itemToEdit.HouseBase.HouseAdress.City;
			Country_ = itemToEdit.HouseBase.HouseAdress.Country;
			Street = itemToEdit.HouseBase.HouseAdress.StreetName;
			Zip = itemToEdit.HouseBase.HouseAdress.ZipCode;
			Console.WriteLine("ITEM EDIT");
		}

		private void usersCollection_Filter(object sender, FilterEventArgs e)
		{
			if (string.IsNullOrEmpty(_searchFilter))
			{
				e.Accepted = true;
				return;
			}

			var viewModelItem = e.Item as HouseRepresentationViewModel;
			string totalItemString = viewModelItem.HouseBase.Category +
								viewModelItem.HouseBase.CommercialBuilding + viewModelItem.HouseBase.ID +
								viewModelItem.HouseBase.LegalForm + viewModelItem.HouseBase.ResidentialBuldings;
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
		public ICommand AddImageCommand { get; set; }

		public ICollectionView CollectionView
		{
			get
			{
				return this.houseCollection.View;
			}
		}

		private HouseViewModelCollection houses;
		public HouseViewModelCollection Houses
		{
			get => houses;
			set => houses = value;
		}

		void AddImage()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			Nullable<bool> result = fileDialog.ShowDialog();
			if (result == true)
			{
				ImageFilePath = fileDialog.FileName;
			}
		}
		void FinishEdit()
		{
			HouseViewModel.HouseBase.Category = Category;
			HouseViewModel.HouseBase.ResidentialBuldings = ResidentialBuildings;
			HouseViewModel.HouseBase.Category = Category;
			HouseViewModel.HouseBase.Category = Category;
		}

		void AddHouse()
		{
			var h = new HouseRepresentationViewModel();
			h.HouseBase = new House(_id)
			{
				HouseAdress = new Adress(Street, Zip, City, Country_),
				Image = _imageFilePath,
				Category = _category,
				ResidentialBuldings = _residentialBuildings,
				CommercialBuilding = _commercialBuilding,
				LegalForm = _legalForm
			};
			Houses.Add(h);
		}
	}
}
