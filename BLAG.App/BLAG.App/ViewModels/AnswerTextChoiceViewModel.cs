using System.Linq;
using BLAG.Common.Models;
using DynamicData;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        private SourceList<AnswerTextChoiceCellViewModel> _answers = new SourceList<AnswerTextChoiceCellViewModel>();
        private string _selectedAnswer;

        public AnswerTextChoiceViewModel(AnswerTextChoice model)
        {
            Answers.AddRange(model.TextChoices.Select(s=> new AnswerTextChoiceCellViewModel(s)));
        }

        public SourceList<AnswerTextChoiceCellViewModel> Answers
        {
            get => _answers;
            set => this.RaiseAndSetIfChanged(ref _answers, value);
        }


        //put answers to observable list


        public string SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }
    }
}