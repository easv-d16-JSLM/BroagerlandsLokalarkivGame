﻿using System.Reactive.Linq;
using BLAG.App.Services;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly Player _player;
        private readonly ObservableAsPropertyHelper<int> _playerCount;
        private readonly SignalRService _signal;

        public GameViewModel(SignalRService signal, Player player)
        {
            _signal = signal;
            _player = player;

            _playerCount = _signal.PlayerCountUpdated.ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.PlayerCount);
        }

        public Answer CurrentAnswer { get; set; }
        public int PlayerCount => _playerCount.Value;
    }
}