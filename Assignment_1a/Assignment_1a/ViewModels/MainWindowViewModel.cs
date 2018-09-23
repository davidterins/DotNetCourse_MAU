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
using David_Mvvm_lib.Serialization;

namespace Assignment_1a.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private HouseViewModelCollection _houses;
		private List<string> searchWords = new List<string>();

		string _currentFileInUse = string.Empty;
		public string CurrentFileInUse
		{
			get => _currentFileInUse;
			set { _currentFileInUse = value; OnPropertyChanged(nameof(CurrentFileInUse)); }
		}

		string _searchFilter;
		public string SearchFilter
		{
			get => _searchFilter;
			set { _searchFilter = value; _houseCollection.View.Refresh(); OnPropertyChanged(nameof(SearchFilter)); }
		}

		HouseEditorViewModel _houseEditViewModel;
		public HouseEditorViewModel HouseEditViewModel
		{
			get => _houseEditViewModel;
			set { _houseEditViewModel = value; OnPropertyChanged(nameof(HouseEditViewModel)); }
		}

		public ICommand ExportToXMLCommand { get; set; }
		public ICommand ImportFromXMLCommand { get; set; }

		private CollectionViewSource _houseCollection;
		public ICollectionView CollectionView
		{
			get => _houseCollection.View;
			set { _houseCollection.Source = value; }
		}

		public MainWindowViewModel()
		{
			_houseEditViewModel = new HouseEditorViewModel();
			_houses = new HouseViewModelCollection();

			_houseCollection = new CollectionViewSource();
			_houseCollection.Source = _houses;

			_houses.OnCollectionItemEdited += Houses_OnCollectionItemEdited;
			_houseCollection.Filter += OnHouseCollectionFilter;
			_houseEditViewModel.ItemAddedHandler += _houseEditViewModel_ItemAddedHandler;

			ExportToXMLCommand = new ActionCommand(ExportToXML);
			ImportFromXMLCommand = new ActionCommand(ImportFromXML);
		}

		private void _houseEditViewModel_ItemAddedHandler(object sender, HouseRepresentationViewModel e)
		{
			_houses.Add(e);
			Console.WriteLine("Add house " + e.BuildingType);
			OnPropertyChanged(nameof(CollectionView));
		}

		private void Houses_OnCollectionItemEdited(object sender, EventArgs e)
		{
			var itemToEdit = (HouseRepresentationViewModel)sender;

			_houseEditViewModel.HouseViewModel = itemToEdit;
			_houseEditViewModel.EditItem(itemToEdit);
		}

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

		void ImportFromXML()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "XML files | *.xml;";
			var result = fileDialog.ShowDialog();
			if (result == true)
			{
				Serialization.XMLDeserializeCollection(fileDialog.FileName, ref _houses);
				_houseCollection.Source = _houses;
				OnPropertyChanged(nameof(CollectionView));
				CurrentFileInUse = fileDialog.FileName;
			}
		}
		void ExportToXML()
		{
			SaveFileDialog saveDialog = new SaveFileDialog();
			var result = saveDialog.ShowDialog();
			if (result == true)
			{
				_houses.XMLSerialize(saveDialog.FileName + ".xml");
			}
		}
	}
}
