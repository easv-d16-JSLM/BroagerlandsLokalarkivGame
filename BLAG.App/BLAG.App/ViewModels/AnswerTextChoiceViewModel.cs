using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceViewModel : ReactiveObject
    {
        private readonly AnswerTextChoice _model;

        public AnswerTextChoiceViewModel(AnswerTextChoice model)
        {
            _model = model;
        }
    }
}
