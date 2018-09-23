using David_Mvvm_lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using David_Mvvm_lib.ViewModels;
using David_Mvvm_lib.Helpers;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using David_Mvvm_lib.Models;
using Microsoft.Win32;

namespace Assignment_1a.ViewModels
{
	public class HouseEditorViewModel : ViewModelBase
	{
		public event EventHandler<HouseRepresentationViewModel> ItemAddedHandler;

		public List<BuildingType> _buildingTypesList;
		public List<BuildingType> BuildingTypesList
		{
			get { return _buildingTypesList; }
			private set { _buildingTypesList = value; OnPropertyChanged(nameof(BuildingTypesList)); }
		}

		private readonly Dictionary<string, BuildingType[]> _buildtypeDictionary = new Dictionary<string, BuildingType[]>
		{
			{"Residential", new BuildingType[]{BuildingType.Appartment, BuildingType.TownHouse, BuildingType.Villa } },
			{"Commercial", new BuildingType[]{BuildingType.WareHouse, BuildingType.Store} },
		};

		bool _inEditMode = false;
		public bool InEditMode
		{
			get => _inEditMode;
			set { _inEditMode = value; OnPropertyChanged(nameof(InEditMode)); }
		}

		BaseHouseModel _selectedHouse;
		public BaseHouseModel SelectedHouse
		{
			get => _selectedHouse;
			set { _selectedHouse = value; OnPropertyChanged(nameof(SelectedHouse)); }
		}

		string _category = null;
		public string Category
		{
			get => _category;
			set
			{
				_category = Wpf_StringHelper.ConvertComobboxItemTotext(value);
				BuildingTypesList = _buildtypeDictionary[_category].ToList(); OnPropertyChanged(nameof(Category));
			}
		}

		string _selectedBuildingType;
		public string SelectedBuildingType
		{
			get => _selectedBuildingType;
			set { _selectedBuildingType = Wpf_StringHelper.ConvertComobboxItemTotext(value); OnPropertyChanged(nameof(SelectedBuildingType)); }
		}
		string _legalForm;
		public string LegalForm
		{
			get => _legalForm;
			set { _legalForm = Wpf_StringHelper.ConvertComobboxItemTotext(value); OnPropertyChanged(nameof(LegalForm)); }
		}

		string _id;
		public string ID
		{
			get => _id;
			set { _id = value; OnPropertyChanged(nameof(ID)); }
		}

		string _imageFilePath;
		public string ImageFilePath
		{
			get { return _imageFilePath; }
			set { _imageFilePath = value; OnPropertyChanged(nameof(ImageFilePath)); }
		}
		string _city;
		public string City
		{
			get { return _city; }
			set { _city = value; OnPropertyChanged(nameof(City)); }
		}
		int? _zip;
		public int? Zip
		{
			get { return _zip; }
			set { _zip = value; OnPropertyChanged(nameof(Zip)); }
		}
		Country _country;
		public Country Country_
		{
			get { return _country; }
			set { _country = value; OnPropertyChanged(nameof(Country_)); }
		}
		string _street;
		public string Street
		{
			get { return _street; }
			set { _street = value; OnPropertyChanged(nameof(Street)); }
		}

		public List<Country> Countries { get => Enum.GetValues(typeof(Country)).Cast<Country>().ToList(); }

		public HouseRepresentationViewModel HouseViewModel { get; set; }

		public ICommand FinishEditCommand { get; set; }
		public ICommand AddHouseCommand { get; set; }
		public ICommand AddImageCommand { get; set; }

		public HouseEditorViewModel()
		{
			AddImageCommand = new ActionCommand(AddImage);
			AddHouseCommand = new ActionCommand(AddHouse);
			FinishEditCommand = new ActionCommand(FinishEdit);
		}

		public void EditItem(HouseRepresentationViewModel itemToEdit)
		{
			HouseViewModel = itemToEdit;
			InEditMode = true;
		}

		void AddImage()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			var result = fileDialog.ShowDialog();
			if (result == true)
			{
				ImageFilePath = fileDialog.FileName;
			}
		}
		void FinishEdit()
		{
			HouseViewModel.EditValues(_id, _legalForm, _selectedBuildingType, _imageFilePath,
				_category, _street, _zip, _city, _country);

			HouseViewModel.EditMode = false;
			InEditMode = false;
		}

		void AddHouse()
		{
			if (!string.IsNullOrEmpty(_category))
			{
				var houseRepViewModel = new HouseRepresentationViewModel();

				if (Category == "Residential")
				{
					houseRepViewModel.HouseDataModel = new ResidentialRealEstateModel(_id);
				}
				else if (Category == "Commercial")
				{
					houseRepViewModel.HouseDataModel = new ComercialRealEstateModel(_id);
				}
				houseRepViewModel.HouseDataModel.Image = _imageFilePath;
				houseRepViewModel.HouseDataModel.BuildingType = _selectedBuildingType;
				houseRepViewModel.HouseDataModel.HouseAdress = new Adress(Street, Zip, City, Country_);
				houseRepViewModel.HouseDataModel.LegalForm = _legalForm;

				ItemAddedHandler.Invoke(this, houseRepViewModel);
			}
		}
	}

}
