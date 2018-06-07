using System;
using System.Reactive;
using System.Reactive.Linq;
using BLAG.Common.Models;
using Humanizer;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        private readonly ReactiveList<string> _answers;
        private readonly ObservableAsPropertyHelper<string> _timeLeft;

        public ReactiveCommand<Unit, Unit> SubmitAnswer { get; }

        private string _selectedAnswer;

        public AnswerTextChoiceViewModel(Answer answer, DateTime time, Services.SignalRService signal, Player player)
        {
            _answers = new ReactiveList<string>(answer.Options);


            _timeLeft = Observable.Interval(100.Milliseconds()).Select(_ => (time - DateTime.Now).Humanize(1))
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, vm => vm.TimeLeft);

            SubmitAnswer = ReactiveCommand.CreateFromTask(async () =>
            {
                await signal.SubmitAnswer(new PlayerAnswer() { Player = player, PlayerAnswered = SelectedAnswer, TimeAnswered = TimeSpan.Zero, Question = answer.Question });
            },null,RxApp.TaskpoolScheduler);
        
        }

        public IReadOnlyReactiveList<string> Answers => _answers;

        public string SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }

        public string TimeLeft => _timeLeft.Value;
    }
}