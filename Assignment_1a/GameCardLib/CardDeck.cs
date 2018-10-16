using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{

	public class CardDeck
	{
		List<Card> _cards;

		public CardDeck()
		{
			_cards = new List<Card>();
		}

		public void Shuffle()
		{
		  for (int i = 0; i< _cards.Count; i++)
			{
				Random rand = new Random();
				Card cardOne = _cards[i];
				int randomCardIndex = rand.Next(0, _cards.Count);
				Card cardTwo = _cards[randomCardIndex];

				_cards[i] = cardTwo;
				_cards[randomCardIndex] = cardOne;
			
			}
		
		}

		public int CardsLeft { get { return _cards.Count; } }

		public Card GetTopCard { get { return _cards[0]; } }

		public void InsertCard(Card gameCard)
		{
			_cards.Add(gameCard);
		}
	}
}
