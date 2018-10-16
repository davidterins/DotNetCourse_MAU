using GameCardLib.Agents;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{
    public class BlackJackGame
    {
        Dealer _dealer;
        List<Player> _players;

        int currentPlayerIndex;

        List<IPlayingAgent> PlayersAndDealer;

        public BlackJackGame()
        {

        }

        public Dealer Dealer { get { return _dealer; } }

        public void NewGame()
        {
            _dealer = new Dealer();
            _players = new List<Player>();
            
            PlayersAndDealer.Add(_dealer);
            PlayersAndDealer.AddRange(_players);
        }

        public void StartGame()
        {
            Console.WriteLine("StartedGame");
        }

       
        private void IterateToNextPlayer(object sender, FinishTurnEventArgs e)
        {
           
        }
       
        
        private void GameRound()
        {

        }

        public void AddPlayingAgent(IPlayingAgent agent)
        {
            agent.FinishTurnEvent += IterateToNextPlayer;
        }

        public void RemovePlayingAgent(IPlayingAgent agent)
        {
            agent.FinishTurnEvent -= IterateToNextPlayer;
        }
    }
}

