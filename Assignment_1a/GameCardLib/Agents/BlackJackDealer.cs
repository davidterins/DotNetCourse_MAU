using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib.Agents
{

  public class BlackJackDealer : PlayingAgent
  {
    
    public event EventHandler<DealerAnswerArgs> AskNextPlayerEvent;

    int _numberOfDecks;
    List<CardDeck> _decks;
    CardDeck _cardDeck;

    public BlackJackDealer(int numberOfDecks) : base()
    {
      //On below 25 cards event 
      _numberOfDecks = numberOfDecks;
      _decks = new List<CardDeck>(numberOfDecks);
      for(int i= 0; i< _numberOfDecks; i++)
      {
        _decks.Add(new CardDeck());
      }
      _cardDeck = new CardDeck();

    }

    public void Shuffle()
    {
      _cardDeck.Shuffle();
    }

    public Card DealCard()
    {
      return _cardDeck.GetTopCard;
    }

    public Hand DealNewHand(int maxHandCapacity, int numberOfCardsToDeal)
    {
      Hand newHand = new Hand(maxHandCapacity);
      for (int i = 0; i < numberOfCardsToDeal; i++)
      {
        newHand.Add(DealCard());
      }
      return newHand;
    }

    public void AnswerPlayer(BlackJackPlayer player, PlayerAction action)
    {
      Console.WriteLine("Dealer respond to action: " + action.ToString() + " from player " + player.PlayerID);
      if(player.Score == 21)
      {//
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(DealerAnswer.RemoveWinnerAndNext));

      }
      if (action == PlayerAction.Hit)
      {
        player.RecieveCard(DealCard());
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(OverTwentyOneOrBlackJack(player)));
      }
      else if (action == PlayerAction.Shuffle)
      {
        Shuffle();
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(DealerAnswer.Stay));

      }
      else if (action == PlayerAction.Stand)
      {
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(DealerAnswer.Next));
      }
      else if (action == PlayerAction.Split)
      {
        //Future
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(DealerAnswer.Stay));
      }
      //else if (action == PlayerAction.Double)
      //{
      //  AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs());
      //}
    }

    private DealerAnswer OverTwentyOneOrBlackJack (BlackJackPlayer player)
    {
      if (player.Score > 21)
      {
        player.Lost();
        return DealerAnswer.RemoveLoserAndNext;
      }
      else if(player.Score == 21)
      {
        player.Won();
        return DealerAnswer.RemoveWinnerAndNext;
      }
      return DealerAnswer.Next;
    }

    private void CompareScores(List<BlackJackPlayer> players)
    {
      while (Score < 17)
      {
        RecieveCard(DealCard());
      }
      foreach(BlackJackPlayer player in players)
      {
        if(player.Score > Score && player.IsInGame)
        {
          player.Won();
        }
        else
        {
          player.Lost();
        }
      }
    }
  }

  public enum DealerAnswer { Next, RemoveLoserAndNext, RemoveWinnerAndNext, Stay}
  public class DealerAnswerArgs : EventArgs
  {
    public DealerAnswer Answer { get; }

    public DealerAnswerArgs(DealerAnswer dealerAnswer)
    {
      Answer = dealerAnswer;
    }
  }
}
