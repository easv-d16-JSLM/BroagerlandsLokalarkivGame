using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        private string _selectedAnswer;

        public AnswerTextChoiceViewModel(AnswerTextChoice model)
        {
            Model = model;
        }

        public AnswerTextChoice Model { get; }


        //put answers to observable list
        

        public string SelectedAnswer
        {
            get => _selectedAnswer;
            set => this.RaiseAndSetIfChanged(ref _selectedAnswer, value);
        }
    }
}