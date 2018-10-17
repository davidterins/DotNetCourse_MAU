using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib.Agents
{

  public class Dealer : PlayingAgent
  {
    public event EventHandler AskNextPlayerEvent;

    CardDeck _cardDeck;

    public Dealer() : base()
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

    public void AnswerPlayer(Player player, AgentAction action)
    {
      Console.WriteLine("Dealer respond to action: " + action.ToString() + " from player " + player.PlayerID);
      if(action == AgentAction.Hit)
      {
        RecieveCard(DealCard());
        var s = Hand;
        player.RecieveCard(DealCard());
      }
      else if (action == AgentAction.Shuffle)
      {
        Shuffle();
        Console.WriteLine("Deck Shuffled");
      }
      else if(action == AgentAction.Stand)
      {
        AskNextPlayerEvent.Invoke(this, new EventArgs());
      }
    }



  }
}
