using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{

	public class CardDeck
	{
		List<Card> _cards;
    Stack<Card> _deck;

		public CardDeck()
		{
      _cards = NewDeck();
      Shuffle();
    }

    List<Card> NewDeck()
    {
      _deck = new Stack<Card>();
      List<Card> cards = new List<Card>();
      for (int i = 1; i < 15; i++)
      {
        cards.Add(new Card(i, Suit.Diamonds, ""));
        //_deck.Push(new Card(i, Suit.Diamonds, ""));
        cards.Add(new Card(i, Suit.Hearts, ""));
        //_deck.Push(new Card(i, Suit.Hearts, ""));
        cards.Add(new Card(i, Suit.Clubs, ""));
        //_deck.Push(new Card(i, Suit.Clubs, ""));
        cards.Add(new Card(i, Suit.Spades, ""));
       // _deck.Push(new Card(i, Suit.Spades, ""));
      }
   
      return cards;
    }

		public void Shuffle()
		{
      Random rand = new Random();
      for (int i = 0; i< _cards.Count; i++)
			{
				
				Card cardOne = _cards[i];
				int randomCardIndex = rand.Next(0, _cards.Count);

				Card cardTwo = _cards[randomCardIndex];

				_cards[i] = cardTwo;
				_cards[randomCardIndex] = cardOne;
        
        _deck.Push(cardTwo);
			
			}
		
		}

		public int CardsLeft { get { return _deck.Count; } }

		public Card GetTopCard { get { return _deck.Pop();  } }

		public void InsertCard(Card gameCard)
		{
			_cards.Add(gameCard);
      _deck.Push(gameCard);
		}
	}
}
