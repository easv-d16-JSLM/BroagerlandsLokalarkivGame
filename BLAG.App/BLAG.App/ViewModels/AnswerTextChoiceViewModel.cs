using System;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.ReactiveUI;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        private readonly ReactiveList<AnswerTextChoiceCellViewModel> _answers =
            new ReactiveList<AnswerTextChoiceCellViewModel>();

        private AnswerTextChoiceCellViewModel _selectedAnswer;

        public AnswerTextChoiceViewModel(IObservable<IChangeSet<string>> answers)
        {
            answers
                .Transform(answer => new AnswerTextChoiceCellViewModel(answer))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(_answers)
                .DisposeMany()
                .Subscribe();
        }

        public IReadOnlyReactiveList<AnswerTextChoiceCellViewModel> Answers => _answers;

        public AnswerTextChoiceCellViewModel SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }
    }
}