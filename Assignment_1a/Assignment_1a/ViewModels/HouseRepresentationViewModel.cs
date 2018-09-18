using Assignment_1a.Models;
using Assignment_1a.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment_1a.ViewModels
{
	public class HouseRepresentationViewModel : ViewModelBase
	{
		public event EventHandler OnEditHouseHandler;
		public event EventHandler OnDeleteHouseHandler;

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
