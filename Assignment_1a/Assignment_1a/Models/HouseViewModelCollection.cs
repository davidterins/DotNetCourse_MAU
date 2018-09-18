using Assignment_1a.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1a.Models
{
	public class HouseViewModelCollection : ObservableCollection<HouseRepresentationViewModel>
	{
		public event EventHandler OnCollectionItemEdited;

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged(e);
			var itemChanged = (HouseRepresentationViewModel)e.NewItems[0];
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				itemChanged.OnEditHouseHandler += OnEditHouseEvent;
			}
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				itemChanged.OnEditHouseHandler -= OnEditHouseEvent;
			}
		}

		private void OnEditHouseEvent(object sender, EventArgs e)
		{
			OnCollectionItemEdited.Invoke(sender, e);
			var item = (HouseRepresentationViewModel)sender;
			Console.WriteLine("HouseEditEvent, houseID " + item.HouseBase.ID);
		}
	}


}
