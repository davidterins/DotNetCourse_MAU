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
        public ICommand ImportSavedCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// ctr
        /// </summary>
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

            ImportSavedCommand = new ActionCommand(ImportSavedFile);
            ExportToXMLCommand = new ActionCommand(ExportToXML);
            ImportFromXMLCommand = new ActionCommand(ImportFromXML);
        }


        /// <summary>
        /// Called when the program closes
        /// </summary>
        /// <returns></returns>
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
                    ///ExportToXML();
                    SaveFile();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a house to the house list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void _houseEditViewModel_ItemAddedHandler(object sender, HouseRepresentationViewModel e)
        {
            _houses.Add(e);
            OnPropertyChanged(nameof(CollectionView));
        }

        /// <summary>
        /// Handles the edit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Houses_OnCollectionItemEdited(object sender, EventArgs e)
        {
            var itemToEdit = (HouseRepresentationViewModel)sender;

            _houseEditViewModel.HouseViewModel = itemToEdit;
            _houseEditViewModel.EditItem(itemToEdit);
        }


        /// <summary>
        /// Handles the filter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Import an xml file
        /// </summary>
        void ImportSavedFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Binary files | *.bin;";
            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                string err;
                _houses.OnCollectionItemEdited -= Houses_OnCollectionItemEdited;

                HouseRepresentationViewModel v = Serialization.BinaryFileDeSerialize<HouseRepresentationViewModel>(fileDialog.FileName, out err);
               // _houses = Serialization.BinaryFileDeSerialize<HouseViewModelCollection>(fileDialog.FileName, out err);

                _houseCollectionViewSource.Source = _houses;
                OnPropertyChanged(nameof(CollectionView));

                _houses.OnCollectionItemEdited += Houses_OnCollectionItemEdited;
                CurrentFileInUse = fileDialog.FileName;
            }
        }

        void SaveFile()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            var result = saveDialog.ShowDialog();
            if (result == true)
            {
                _houses.BinarySerialize(saveDialog.FileName + ".bin");
            }
        }

        /// <summary>
        /// Import an xml file
        /// </summary>
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

        /// <summary>
        /// exports to a xml file
        /// </summary>
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
