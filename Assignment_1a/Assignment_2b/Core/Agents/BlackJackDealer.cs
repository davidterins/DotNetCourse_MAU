using Assignment_2b.ViewModels;
using GameCardLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2b.Core.Agents
{
  public class BlackJackDealer : PlayingAgent
  {

    public event EventHandler<DealerAnswerArgs> AskNextPlayerEvent;

    int _numberOfDecks;
    List<CardDeck> _decks;
    CardDeck _cardDeck;

    public BlackJackDealer(int numberOfDecks = 1) : base()
    {
      //On below 25 cards event 
      _numberOfDecks = numberOfDecks;
      _decks = new List<CardDeck>(_numberOfDecks);
      for (int i = 0; i < _numberOfDecks; i++)
      {
        _decks.Add(new CardDeck());
      }
      _cardDeck = new CardDeck();

    }

    public void NewRound()
    {
     
      for (int i = 0; i < _numberOfDecks; i++)
      {
        _decks.Add(new CardDeck());
      }
      _cardDeck = new CardDeck();
      ResetScore();
      DealSelf(1);
    }

    public void Shuffle()
    {
      foreach(CardDeck deck in _decks)
      {
        deck.Shuffle();
      }
      _cardDeck.Shuffle();
    }

    private BlackJackCard DealCard()
    {
      foreach(CardDeck deck in _decks)
      {
        if(deck.CardsLeft > 0)
        {
          return deck.GetTopCard;
        }
      }
      return null;
     // return _cardDeck.GetTopCard;
    }

    public void AnswerPlayer(PlayerViewModel player, PlayerAction action)
    {
      Console.WriteLine("Dealer respond to action: " + action.ToString() + " from player " + player.PlayerID);
      if (player.Score == 21)
      {
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(DealerAnswer.RemoveWinnerAndNext));
      }
      else if (player.Score > 21)
      {
        AskNextPlayerEvent.Invoke(this, new DealerAnswerArgs(DealerAnswer.RemoveLoserAndNext));
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

    private DealerAnswer OverTwentyOneOrBlackJack(PlayerViewModel player)
    {
      if (player.Score > 21)
      {
        player.AgentLost();
        return DealerAnswer.RemoveLoserAndNext;
      }
      else if (player.Score == 21)
      {
        player.AgentWon();
        return DealerAnswer.RemoveWinnerAndNext;
      }
      return DealerAnswer.Next;
    }

    public void CompareScores(ObservableCollection<PlayerViewModel> players)
    {
      while (Score < 17)
      {
        RecieveCard(DealCard());
      }
      foreach (PlayerViewModel player in players)
      {
        if (player.Score <= 21)
        {
          if (Score > 21)
          {
            player.AgentWon();
          }
          else if (Score > player.Score)
          {
            player.AgentLost();
          }
          else if(player.Score > Score)
          {
            player.AgentWon();
          }
          else if (Score == player.Score)
          {//Tie
            player.AgentWon();
          }
        }
        else
        {
          player.AgentLost();
        }
      }
    }

    public void DealSelf(int numberOfCards)
    {
      for (int i = 0; i < numberOfCards; i++)
        RecieveCard(DealCard());
    }

    public void DealPlayer(PlayerViewModel player, int numberOfCards)
    {
      for (int i = 0; i < numberOfCards; i++)
        player.RecieveCard(DealCard());
    }

  }

  public enum DealerAnswer { Next, RemoveLoserAndNext, RemoveWinnerAndNext, Stay }
  public class DealerAnswerArgs : EventArgs
  {
    public DealerAnswer Answer { get; }

    public DealerAnswerArgs(DealerAnswer dealerAnswer)
    {
      Answer = dealerAnswer;
    }
  }
}
