using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ViewModelBase
    {
        public AnswerTextChoice Model { get; }

        public AnswerTextChoiceViewModel(AnswerTextChoice model)
        {
            Model = model;
        }

        public string SelectedAnswer { get; set; }
    }
}
