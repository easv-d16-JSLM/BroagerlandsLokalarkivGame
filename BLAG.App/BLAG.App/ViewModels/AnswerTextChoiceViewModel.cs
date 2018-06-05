using System;
using System.Linq;
using System.Reactive.Linq;
using BLAG.Common.Models;
using Humanizer;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        private readonly ReactiveList<string> _answers;

        private string _selectedAnswer;
        private readonly ObservableAsPropertyHelper<string> _timeLeft;

        public AnswerTextChoiceViewModel(Answer answer, DateTime time)
        {
            _answers = new ReactiveList<string>(answer.Options);


            _timeLeft = Observable.Interval(100.Milliseconds()).Select(_ => (time - DateTime.Now).Humanize(2))
                .ToProperty(this, vm => vm.TimeLeft);
        }

        public string TimeLeft => _timeLeft.Value;

        public IReadOnlyReactiveList<string> Answers => _answers;

        public string SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }
    }
}