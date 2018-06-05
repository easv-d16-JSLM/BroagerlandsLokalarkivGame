using System.Reactive.Linq;
using BLAG.App.Services;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly ObservableAsPropertyHelper<AnswerTextChoiceViewModel> _currentAnswer;
        private readonly Player _player;
        private readonly ObservableAsPropertyHelper<int> _playerCount;
        private readonly SignalRService _signal;

        public GameViewModel(SignalRService signal, Player player)
        {
            _signal = signal;
            _player = player;

            _playerCount = _signal.PlayerCountUpdated.ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.PlayerCount);

            _currentAnswer = _signal.CurrentAnswer.Select(a => new AnswerTextChoiceViewModel(a.Item1, a.Item2))
                .ToProperty(this, vm => vm.CurrentAnswer);

            
        }

        public AnswerTextChoiceViewModel CurrentAnswer => _currentAnswer.Value;

        public int PlayerCount => _playerCount.Value;
    }
}