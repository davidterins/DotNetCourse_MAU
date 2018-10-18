using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib.Agents
{

  public class BlackJackDealer : PlayingAgent
  {
    public event EventHandler AskNextPlayerEvent;

    CardDeck _cardDeck;

    public BlackJackDealer() : base()
    {
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
      for(int i = 0; i < numberOfCardsToDeal; i++)
      {
        newHand.Add(DealCard());
      }
      return newHand;
    }

    public void AnswerPlayer(BlackJackPlayer player, PlayerAction action)
    {
      Console.WriteLine("Dealer respond to action: " + action.ToString() + " from player " + player.PlayerID);
      if (action == PlayerAction.Hit)
      {
        player.RecieveCard(DealCard());
        AskNextPlayerEvent.Invoke(this, new EventArgs());
      }
      else if (action == PlayerAction.Shuffle)
      {
        Shuffle();
      }
      else if (action == PlayerAction.Stand)
      {
        AskNextPlayerEvent.Invoke(this, new EventArgs());
      }
      else if (action == PlayerAction.Split)
      {
        AskNextPlayerEvent.Invoke(this, new EventArgs());
      }
      else if (action == PlayerAction.Double)
      {
        AskNextPlayerEvent.Invoke(this, new EventArgs());
      }
    }

    private void CheckPlayerScore(BlackJackPlayer player)
    {
      if(player.Score > 21)
      {
        
      }
    }

    private void CheckScore()
    {
      if(Score < 17)
      {
        RecieveCard(DealCard());
      }
    }



  }
}
