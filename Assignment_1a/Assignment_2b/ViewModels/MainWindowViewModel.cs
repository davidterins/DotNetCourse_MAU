using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCardLib;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using GameCardLib.Agents;

namespace Assignment_2b.ViewModels
{
    public class MainWindowViewModel : David_Mvvm_lib.ViewModels.ViewModelBase
    {
        BlackJackGame _blackJackgame;
        public BlackJackGame BlackJackGame {get {return _blackJackgame; } }

        public PlayerViewModel P1VM { get; }

        public MainWindowViewModel()
        {
            _blackJackgame = new BlackJackGame();
            Player p1 = new Player("Pedro");

            _blackJackgame.AddPlayingAgent(p1);
            P1VM = new PlayerViewModel(p1);

            NewGameCommand = new ActionCommand(StartNewGame);
        }

        public ICommand NewGameCommand { get; }


        void StartNewGame()
        {
		     	P1VM.PlayerHand.Add(new Card(2, Suit.Diamonds, "lol"));
            _blackJackgame.StartGame();

        }
       
    }
}
