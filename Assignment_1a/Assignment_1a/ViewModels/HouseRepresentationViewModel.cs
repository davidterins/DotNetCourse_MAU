﻿
using System;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using David_Mvvm_lib.ViewModels;
using David_Mvvm_lib.Enums;
using David_Mvvm_lib.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Assignment_1a.ViewModels
{
	[Serializable]
	public class HouseRepresentationViewModel : ViewModelBase
	{
		public event EventHandler OnEditHouseHandler;
		public event EventHandler OnDeleteHouseHandler;

		public string Category
		{
			get => HouseBase.Category; private set
			{
				HouseBase.Category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		public string BuildingType
		{
			get => HouseBase.BuildingType; private set
			{
				HouseBase.BuildingType = value;
				OnPropertyChanged(nameof(BuildingType));
			}
		}

		public string LegalForm
		{
			get => HouseBase.LegalForm; private set
			{
				HouseBase.LegalForm = value; OnPropertyChanged(nameof(LegalForm));
			}
		}

		public string ImageFilePath { get { return HouseBase.Image; } private set { HouseBase.Image = value; OnPropertyChanged(nameof(ImageFilePath)); } }

		public string City { get { return HouseBase.HouseAdress.City; } private set { HouseBase.HouseAdress.City = value; OnPropertyChanged(nameof(City)); } }

		public int? Zip { get { return HouseBase.HouseAdress.ZipCode; } private set { HouseBase.HouseAdress.ZipCode = value; OnPropertyChanged(nameof(Zip)); } }

		public Country Country_ { get { return HouseBase.HouseAdress.Country; } private set { HouseBase.HouseAdress.Country = value; OnPropertyChanged(nameof(Country_)); } }

		public string Street { get { return HouseBase.HouseAdress.StreetName; } private set { HouseBase.HouseAdress.StreetName = value; OnPropertyChanged(nameof(Street)); } }

		string _id;
		public string ID { get => _id; set { _id = value; OnPropertyChanged(nameof(ID)); } }

		public BaseHouseModel HouseBase { get; set; }

		public ICommand DeleteCommand { get; set; }
		public ICommand EditCommand { get; set; }

		bool _editMode;
		public bool EditMode { get { return _editMode; } set { _editMode = value; OnPropertyChanged(nameof(EditMode)); } }


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

		public override string ToString()
		{
			return base.ToString();
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
	}
}
