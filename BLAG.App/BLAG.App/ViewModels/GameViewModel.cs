using System;
using System.Collections.Generic;
using System.Text;
using BLAG.App.Services;

namespace BLAG.App.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly SignalRService _signal;
        public GameViewModel(SignalRService signal)
        {
            _signal = signal;
        }
    }
}
