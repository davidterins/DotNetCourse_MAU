using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{

	public class CardDeck
	{
		List<BlackJackCard> _cards;
    Stack<BlackJackCard> _deck;

		public CardDeck()
		{
      _cards = NewDeck();
      Shuffle();
    }

    List<BlackJackCard> NewDeck()
    {
      _deck = new Stack<BlackJackCard>();
      List<BlackJackCard> cards = new List<BlackJackCard>();
      for (int i = 1; i < 15; i++)
      {
        cards.Add(new BlackJackCard(i, Suit.Diamonds, ""));
        //_deck.Push(new Card(i, Suit.Diamonds, ""));
        cards.Add(new BlackJackCard(i, Suit.Hearts, ""));
        //_deck.Push(new Card(i, Suit.Hearts, ""));
        cards.Add(new BlackJackCard(i, Suit.Clubs, ""));
        //_deck.Push(new Card(i, Suit.Clubs, ""));
        cards.Add(new BlackJackCard(i, Suit.Spades, ""));
       // _deck.Push(new Card(i, Suit.Spades, ""));
      }
      return cards;
    }

		public void Shuffle()
		{
      Random rand = new Random();
      for (int i = 0; i< _cards.Count; i++)
			{
				BlackJackCard cardOne = _cards[i];
				int randomCardIndex = rand.Next(0, _cards.Count);

				BlackJackCard cardTwo = _cards[randomCardIndex];

				_cards[i] = cardTwo;
				_cards[randomCardIndex] = cardOne;
        
        _deck.Push(cardTwo);
			}
		
		}

		public int CardsLeft { get { return _deck.Count; } }

		public BlackJackCard GetTopCard { get { return _deck.Pop(); } }

		public void InsertCard(BlackJackCard gameCard)
		{
			_cards.Add(gameCard);
      _deck.Push(gameCard);
		}
	}
}
