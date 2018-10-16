using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib.Agents
{

    public class Dealer : PlayingAgent
    {
        CardDeck _cardDeck;

        public Dealer()
        {
            _cardDeck = new CardDeck();
        }

        void Deal()
        {

        }

        public override void OnTurn()
        {
            base.OnTurn();
            
        }
    }
}
