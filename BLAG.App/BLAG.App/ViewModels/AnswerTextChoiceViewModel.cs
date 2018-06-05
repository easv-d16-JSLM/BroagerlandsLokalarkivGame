using System;
using System.Linq;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        private readonly ReactiveList<AnswerTextChoiceCellViewModel> _answers;

        private AnswerTextChoiceCellViewModel _selectedAnswer;

        public AnswerTextChoiceViewModel(Answer answer, DateTime time)
        {
            _answers = new ReactiveList<AnswerTextChoiceCellViewModel>(answer.Options
                .Select(o => new AnswerTextChoiceCellViewModel(o)));
        }

        public IReadOnlyReactiveList<AnswerTextChoiceCellViewModel> Answers => _answers;

        public AnswerTextChoiceCellViewModel SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }
    }
}