using System;
using System.Reactive.Disposables;
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

        private string _selectedAnswer;

        public AnswerTextChoiceViewModel(IObservable<IChangeSet<string>> answers)
        {
            this.WhenActivated(d =>
            {
                answers
                    .Transform(answer => new AnswerTextChoiceCellViewModel(answer))
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Bind(_answers)
                    .DisposeMany()
                    .Subscribe()
                    .DisposeWith(d);
            });
        }

        public IReadOnlyReactiveList<AnswerTextChoiceCellViewModel> Answers => _answers;


        public string SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }
    }
}