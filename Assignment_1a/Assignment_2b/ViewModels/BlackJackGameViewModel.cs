using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCardLib;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using GameCardLib.Agents;
using System.Collections.ObjectModel;

namespace Assignment_2b.ViewModels
{
  public class BlackJackGameViewModel : BlackJackGame
  {

    public BlackJackGameViewModel() : base()
    {
      PlayerViewModel p1 = new PlayerViewModel("Pedro");
      PlayerViewModel p2 = new PlayerViewModel("Lasse");
      PlayerViewModel p3 = new PlayerViewModel("Sharqeisha");
      PlayerViewModel p4 = new PlayerViewModel("Latifa");

      AddPlayingAgent(p1);
      AddPlayingAgent(p2);
      AddPlayingAgent(p3);
      AddPlayingAgent(p4);

      NewGameCommand = new ActionCommand(StartNewGame);
    }

    public ICommand NewGameCommand { get; }

    void StartNewGame()
    {
      StartGame();
    }

  }
}
