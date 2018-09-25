
using System;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using David_Mvvm_lib.ViewModels;
using David_Mvvm_lib.Enums;
using David_Mvvm_lib.Models;
using System.Xml.Serialization;
using David_Mvvm_lib.Helpers;

namespace Assignment_1a.ViewModels
{
	[Serializable]
	public class HouseRepresentationViewModel : ViewModelBase
	{
		public event EventHandler OnEditHouseHandler;
		public event EventHandler OnDeleteHouseHandler;

		[XmlIgnore]
		public string Category
		{
			get => HouseDataModel.Category;
			set { HouseDataModel.Category = value; OnPropertyChanged(nameof(Category)); }
		}
		[XmlIgnore]
		public string BuildingType
		{
			get => HouseDataModel.BuildingType;
			set { HouseDataModel.BuildingType = value; OnPropertyChanged(nameof(BuildingType)); }
		}
		[XmlIgnore]
		public string LegalForm
		{
			get => HouseDataModel.LegalForm;
			set { HouseDataModel.LegalForm = value; OnPropertyChanged(nameof(LegalForm)); }
		}

		[XmlIgnore]
		public string ImageFilePath
		{
			get { return HouseDataModel.Image; }
			set { HouseDataModel.Image = value; OnPropertyChanged(nameof(ImageFilePath)); }
		}

		[XmlIgnore]
		public string City
		{
			get { return HouseDataModel.HouseAdress.City; }
			set { HouseDataModel.HouseAdress.City = value; OnPropertyChanged(nameof(City)); }
		}

		[XmlIgnore]
		public int? Zip
		{
			get { return HouseDataModel.HouseAdress.ZipCode; }
			set { HouseDataModel.HouseAdress.ZipCode = value; OnPropertyChanged(nameof(Zip)); }
		}

		[XmlIgnore]
		public Country Country_
		{
			get { return HouseDataModel.HouseAdress.Country; }
			set { HouseDataModel.HouseAdress.Country = value; OnPropertyChanged(nameof(Country_)); }
		}

		[XmlIgnore]
		public string Street
		{
			get { return HouseDataModel.HouseAdress.StreetName; }
			set { HouseDataModel.HouseAdress.StreetName = value; OnPropertyChanged(nameof(Street)); }
		}

		string _id;
		[XmlIgnore]
		public string ID
		{
			get => _id;
			set { _id = value; OnPropertyChanged(nameof(ID)); }
		}

		int _searchHits = 0;
		[XmlIgnore]
		public int SearchHits
		{
			get => _searchHits;
			set { _searchHits = value; OnPropertyChanged(nameof(SearchHits)); }
		}

		bool _editMode;
		[XmlIgnore]
		public bool EditMode
		{
			get { return _editMode; }
			set { _editMode = value; OnPropertyChanged(nameof(EditMode)); }
		}

		[XmlIgnore]
		public ICommand DeleteCommand { get; set; }
		[XmlIgnore]
		public ICommand EditCommand { get; set; }

		public BaseHouseModel HouseDataModel { get; set; }

		public HouseRepresentationViewModel()
		{
			DeleteCommand = new ActionCommand(Delete);
			EditCommand = new ActionCommand(Edit);
		}

		public void EditValues(string id, string legalForm, string buildingType, string image, string category,
		string street, int? zipCode, string city, Country country)
		{

			ImageFilePath = image;
			LegalForm = legalForm;
			BuildingType = buildingType;
			Category = category;
			Street = street;
			Zip = zipCode;
			City = city;
			Country_ = country;
		}

		void Delete()
		{
			OnDeleteHouseHandler.Invoke(this, EventArgs.Empty);
		}
		void Edit()
		{
			EditMode = true;
			OnEditHouseHandler.Invoke(this, EventArgs.Empty);
		}

		public bool IsSearchHit(string searchString)
		{
			SearchHits = 0;
			bool contains = false;
			if (Wpf_StringHelper.IsMatch(searchString, Category))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, LegalForm))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, BuildingType))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, ID))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, Country_.ToString()))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, Street))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, City))
			{
				SearchHits++;
				contains = true;
			}
			if (Wpf_StringHelper.IsMatch(searchString, Zip.ToString()))
			{
				SearchHits++;
				contains = true;
			}
			if (contains)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
