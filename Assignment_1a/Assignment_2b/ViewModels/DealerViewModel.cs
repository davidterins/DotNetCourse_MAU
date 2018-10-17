using David_Mvvm_lib.ViewModels;
using GameCardLib;
using GameCardLib.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2b.ViewModels
{
  public class DealerViewModel : ViewModelBase
  {
    Dealer _dealer;
    public Dealer Dealer { get { return _dealer; } }

    public DealerViewModel(Dealer dealer)
    {
      _dealer = dealer;
    }

    public Hand DealerHand { get { return _dealer.Hand; } }

    public void Deal(List<PlayerViewModel> players, int cardsEach)
    {
      foreach (PlayerViewModel pVM in players)
      {
        for (int i = 0; i < cardsEach; i++)
        {
          pVM.Player.RecieveCard(_dealer.DealCard());
        }
      }
    }
   
  }
}
