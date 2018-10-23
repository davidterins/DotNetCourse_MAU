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


  public class BlackJackHand : Hand
  {

    public int HandValue { get; private set; }

    public BlackJackHand(int maxCapacity) : base(maxCapacity)
    {
      Cards.CollectionChanged += UpdateHandValue;
    }

    private void UpdateHandValue(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
      {
        Card newCard = (Card)e.NewItems[0];
        if(newCard.Value == 1 || newCard.Value == 11)
        {
          int tempScore = HandValue;
          if(tempScore + 11 > 21)
          {
            newCard.Value = 1;
          }
        }
        
        UpdateHandScore(newCard);
      }
    }

    private void UpdateHandScore(Card card)
    {
      HandValue += card.Value;// HandCalculator.CalculateBlackJackHandOnNewCard(card);
    }
  }
  public static class HandCalculator
  {
    public static int CalculateBlackJackHandOnNewCard(Card newCard)
    {

      return 1;
    }
  }

}
