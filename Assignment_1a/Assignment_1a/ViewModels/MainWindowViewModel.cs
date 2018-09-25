using System;
using System.ComponentModel;
using David_Mvvm_lib.ViewModels;
using David_Mvvm_lib.ViewModels.Commands;
using Assignment_1a.Collections;
using System.Windows.Input;
using System.Windows.Data;
using System.Collections.Generic;
using Microsoft.Win32;
using David_Mvvm_lib.Serialization;
using System.Windows;

namespace Assignment_1a.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private HouseViewModelCollection _houses;
		public HouseViewModelCollection FilteredHouses;
		private List<string> searchWords = new List<string>();

		string _currentFileInUse = string.Empty;
		public string CurrentFileInUse
		{
			get => _currentFileInUse;
			set { _currentFileInUse = value; OnPropertyChanged(nameof(CurrentFileInUse)); }
		}

		string _searchFilter = "";
		public string SearchFilter
		{
			get => _searchFilter;
			set { _searchFilter = value; _houseCollectionViewSource.View.Refresh(); OnPropertyChanged(nameof(SearchFilter)); }
		}

		HouseEditorViewModel _houseEditViewModel;
		public HouseEditorViewModel HouseEditViewModel
		{
			get => _houseEditViewModel;
			set { _houseEditViewModel = value; OnPropertyChanged(nameof(HouseEditViewModel)); }
		}

		private CollectionViewSource _houseCollectionViewSource;
		public ICollectionView CollectionView { get => _houseCollectionViewSource.View; }

		public ICommand ExportToXMLCommand { get; set; }
		public ICommand ImportFromXMLCommand { get; set; }
		public ICommand SaveCommand { get; set; }

		public MainWindowViewModel()
		{
			_houseEditViewModel = new HouseEditorViewModel();
			_houses = new HouseViewModelCollection();
			FilteredHouses = _houses;

			_houseCollectionViewSource = new CollectionViewSource();
			_houseCollectionViewSource.Source = _houses;

			_houses.OnCollectionItemEdited += Houses_OnCollectionItemEdited;
			_houseCollectionViewSource.Filter += OnHouseCollectionFilter;
			_houseEditViewModel.ItemAddedHandler += _houseEditViewModel_ItemAddedHandler;


			_houseCollectionViewSource.SortDescriptions.Add(
						new SortDescription("SearchHits", ListSortDirection.Descending));


			ExportToXMLCommand = new ActionCommand(ExportToXML);
			ImportFromXMLCommand = new ActionCommand(ImportFromXML);
		}

		public bool OnClosing()
		{
			if (string.IsNullOrEmpty(_currentFileInUse))
			{
				if (MessageBox.Show("Continue without saving?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
				{
					return true;
				}
				else
				{
					ExportToXML();
					return true;
				}
			}
			return false;

		}

		private void _houseEditViewModel_ItemAddedHandler(object sender, HouseRepresentationViewModel e)
		{
			_houses.Add(e);
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

			var item = (HouseRepresentationViewModel)e.Item;

			if (item.IsSearchHit(_searchFilter))
			{
				e.Accepted = true;
			}
			else
			{
				e.Accepted = false;
			}
		}

		void ImportFromXML()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "XML files | *.xml;";
			var result = fileDialog.ShowDialog();
			if (result == true)
			{
				_houses.OnCollectionItemEdited -= Houses_OnCollectionItemEdited;

				Serialization.XMLDeserializeCollection(fileDialog.FileName, ref _houses);
				_houseCollectionViewSource.Source = _houses;
				OnPropertyChanged(nameof(CollectionView));

				_houses.OnCollectionItemEdited += Houses_OnCollectionItemEdited;
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
