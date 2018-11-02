using Assignment_1a.ViewModels;
using System;
using System.Collections.Specialized;
using David_Mvvm_lib.Collections;

namespace Assignment_1a.Collections
{
    [Serializable]
	public class HouseViewModelCollection : ListManager<HouseRepresentationViewModel>
	{
		/// <summary>
		/// Event that invokes when an an item in the collection is edited
		/// </summary>
		public event EventHandler OnCollectionItemEdited;

		/// <summary>
		/// Happens every time an object in the collection is changed
		/// </summary>
		/// <param name="e">an eventargs which define what type of action occured in the collection (add, remove, replace etc)</param>
		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged(e);

			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				var itemChanged = (HouseRepresentationViewModel)e.NewItems[0];
				
				itemChanged.OnEditHouseHandler += OnEditHouseEvent;
				itemChanged.OnDeleteHouseHandler += OnDeleteHouseEvent;
			}
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				var itemRemoved = (HouseRepresentationViewModel)e.OldItems[0];
				itemRemoved.OnEditHouseHandler -= OnEditHouseEvent;
			}
		}
		/// <summary>
		/// Triggers when an item in the collection is deleted.
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">empty EventArgs</param>
		private void OnDeleteHouseEvent(object sender, EventArgs e)
		{
			var item = (HouseRepresentationViewModel)sender;
			item.OnDeleteHouseHandler -= OnDeleteHouseEvent;
			Remove(item);
		}

		/// <summary>
		/// Triggers when an item in the collection is edited. 
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">empty EventArgs</param>
		private void OnEditHouseEvent(object sender, EventArgs e)
		{
			OnCollectionItemEdited?.Invoke(sender, e);
		}
	}


}
