using Assignment_1a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1a.ViewModels
{
    public class HouseRepresentationViewModel : ViewModelBase
    {
        public BaseHouseModel HouseBase { get; set; }


		    bool _editMode;
				public bool EditMode { get {return _editMode; } set { _editMode = value; OnPropertyChanged(nameof(EditMode)); } }


    }
}
