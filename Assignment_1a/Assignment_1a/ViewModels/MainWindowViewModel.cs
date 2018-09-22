using System;
using System.ComponentModel;
using David_Mvvm_lib.ViewModels;
using David_Mvvm_lib.ViewModels.Commands;
using David_Mvvm_lib.Helpers;
using David_Mvvm_lib.Models;
using Assignment_1a.Collections;
using David_Mvvm_lib.Enums;
using System.Windows.Input;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Assignment_1a.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public List<BuildingType> _buildingTypesList;
		public List<BuildingType> BuildingTypesList { get { return _buildingTypesList; } private set { _buildingTypesList = value; OnPropertyChanged(nameof(BuildingTypesList)); } }
		private readonly Dictionary<string, BuildingType[]> _buildtypeDictionary = new Dictionary<string, BuildingType[]>
		{
			{"Residential", new BuildingType[]{BuildingType.Appartment, BuildingType.TownHouse, BuildingType.Villa } },
			{"Commercial", new BuildingType[]{BuildingType.WareHouse, BuildingType.Store} },
		};

		string _category = null;
		public string Category
		{
			get => _category;
			set
			{
				_category = Wpf_StringHelper.ConvertComobboxItemTotext(value);
				BuildingTypesList = _buildtypeDictionary[_category].ToList();
				OnPropertyChanged(nameof(Category));
			}
		}

		string _selectedBuildingType;
		public string SelectedBuildingType
		{
			get => _selectedBuildingType;
			set
			{
				_selectedBuildingType = Wpf_StringHelper.ConvertComobboxItemTotext(value);
				OnPropertyChanged(nameof(SelectedBuildingType));
			}
		}
		string _legalForm;
		public string LegalForm
		{
			get => _legalForm;
			set
			{
				_legalForm = Wpf_StringHelper.ConvertComobboxItemTotext(value);
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
			h.HouseBase = new ResidentialRealEstateModel("lolID")
			{
				RealEstateObjectType = BuildingType.TownHouse,
				HouseAdress = new Adress("Malmövägen 5", 23311, "Malmö", Country.Sverige),
				BuildingType = "Villa",
				LegalForm = "OwnerShip"
			};

			houses.Add(h);

			houseCollection = new CollectionViewSource();
			houseCollection.Source = houses;

			houses.OnCollectionItemEdited += Houses_OnCollectionItemEdited;
			houseCollection.Filter += OnHouseCollectionFilter;
			AddImageCommand = new ActionCommand(AddImage);
			AddHouseCommand = new ActionCommand(AddHouse);
			FinishEditCommand = new ActionCommand(FinishEdit);
		}



		private void Houses_OnCollectionItemEdited(object sender, EventArgs e)
		{
			var itemToEdit = (HouseRepresentationViewModel)sender;
			HouseViewModel = itemToEdit;
			ID = itemToEdit.HouseBase.ID;
			Category = itemToEdit.HouseBase.Category;
			
			LegalForm = itemToEdit.HouseBase.LegalForm;
			SelectedBuildingType = itemToEdit.HouseBase.BuildingType;
			City = itemToEdit.HouseBase.HouseAdress.City;
			Country_ = itemToEdit.HouseBase.HouseAdress.Country;
			Street = itemToEdit.HouseBase.HouseAdress.StreetName;
			Zip = itemToEdit.HouseBase.HouseAdress.ZipCode;
			Console.WriteLine("ITEM EDIT");
		}

		List<string> searchWords = new List<string>();
		private void OnHouseCollectionFilter(object sender, FilterEventArgs e)
		{

			if (string.IsNullOrEmpty(_searchFilter))
			{
				e.Accepted = true;
				return;
			}
			string[] words = _searchFilter.Split(' ');

			var viewModelItem = e.Item as HouseRepresentationViewModel;
			string totalItemString = viewModelItem.Category +
								viewModelItem.ID + viewModelItem.LegalForm + viewModelItem.BuildingType +
								viewModelItem.City + viewModelItem.Country_.ToString() + viewModelItem.Street + viewModelItem.Zip;
			foreach (var word in words)
			{
				Console.WriteLine(word);
				if (totalItemString.ToUpper().Contains(word.ToUpper()) && word != string.Empty)
				{
					e.Accepted = true;
				
				}
				else
				{
					e.Accepted = false;
				}
			}
		}

		public ICommand FinishEditCommand { get; set; }
		public ICommand AddHouseCommand { get; set; }
		public ICommand AddImageCommand { get; set; }

		public ICollectionView CollectionView { get => houseCollection.View; }

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
			Console.WriteLine(HouseViewModel.HouseBase.Category);
			HouseViewModel.EditValues(_id, _legalForm, _selectedBuildingType,_imageFilePath, _category,
				_street, _zip, _city, _country);
			HouseViewModel.EditMode = false;
		}

		void AddHouse()
		{
			if (!string.IsNullOrEmpty(_category))
			{
				var houseRepViewModel = new HouseRepresentationViewModel();

			if (Category == "Residential")
			{
				houseRepViewModel.HouseBase = new ResidentialRealEstateModel(_id);
			}
			else if(Category == "Commercial")
			{
				houseRepViewModel.HouseBase = new ComercialRealEstateModel(_id);
			}
				houseRepViewModel.HouseBase.Image = _imageFilePath;
				houseRepViewModel.HouseBase.BuildingType = _selectedBuildingType;
				houseRepViewModel.HouseBase.HouseAdress = new Adress(Street, Zip, City, Country_);
				houseRepViewModel.HouseBase.LegalForm = _legalForm;
				Houses.Add(houseRepViewModel);
			}
		}
	}
}
