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

namespace Assignment_1a.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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

            AddHouseCommand = new ActionCommand(AddHouse);
        }

        public ICommand AddHouseCommand { get; set; }

        private ObservableCollection<BaseHouseModel> houses;
        public ObservableCollection<BaseHouseModel> Houses
        {
            get => houses;
            set => houses = value;
        }

        void AddHouse()
        {
            Console.WriteLine("AddHouseButton pressed!");
        }
    }
}
