using System;
using System.Reactive.Linq;
using BLAG.App.Services;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly ObservableAsPropertyHelper<ViewModelBase> _currentContent;
        private readonly Player _player;
        private readonly ObservableAsPropertyHelper<int> _playerCount;
        private readonly SignalRService _signal;

        public GameViewModel(SignalRService signal, Player player)
        {
            _signal = signal;
            _player = player;

            _playerCount = _signal.PlayerCountUpdated.ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.PlayerCount);

            var answer = _signal.CurrentAnswer.Select(a => new AnswerTextChoiceViewModel(a.Item1, a.Item2));
            var leaderboard = _signal.CurrentLeaderboard.Select(l => new LeaderboardViewModel(l));
            _currentContent= Observable.Merge<ViewModelBase>(answer, leaderboard).ObserveOn(RxApp.MainThreadScheduler).ToProperty(this, x => x.CurrentContent);
                

            _currentContent.ThrownExceptions
                .Subscribe(e => throw e);
            _playerCount.ThrownExceptions
                .Subscribe(e => throw e);
        }

        public ViewModelBase CurrentContent => _currentContent.Value;

        public int PlayerCount => _playerCount.Value;
    }
}