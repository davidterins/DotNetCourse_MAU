using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameCardLib
{
	public class Hand
	{
	 // public List<Card> Cards;
		public ObservableCollection<Card> Cards { get; }

		public Hand()
		{
			Cards = new ObservableCollection<Card>();
		}

		public void Add(Card newCard)
		{
			Cards.Add(newCard);
		}

		public void RemoveLast()
		{
			Cards.RemoveAt(Cards.Count - 1);
		}

		public void Remove(Card card)
		{
			Cards.Remove(card);
		}

	}
}
