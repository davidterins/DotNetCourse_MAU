using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{
  public class BlackJackCard : Card
  {
    public BlackJackCard(int value, Suit suit, string imgPath) : base(value, suit, imgPath)
    {
      SetBlackJackCardValue(value);
    }

    private void SetBlackJackCardValue(int value)
    {
      if (value > 10 && value < 14)
      {
        Value = 10;
      }
      else if (value > 13)
      {
        Value = 11;
      }
    }
  }
}
