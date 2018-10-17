using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameCardLib
{
	public class Hand
	{
		int _maxCapacity;
		public ObservableCollection<Card> Cards { get; }

		public Hand(int maxCapacity)
		{
			Cards = new ObservableCollection<Card>();
			_maxCapacity = maxCapacity;
		}

		public void Add(Card newCard)
		{
			if (Cards.Count + 1 <= _maxCapacity)
			{
				Cards.Add(newCard);
			}
				
		}

		public void RemoveLast()
		{
			if (Cards.Count > 1)
				Cards.RemoveAt(Cards.Count - 1);
		}

		public void Remove(Card card)
		{
			Cards.Remove(card);
		}

	}
}
