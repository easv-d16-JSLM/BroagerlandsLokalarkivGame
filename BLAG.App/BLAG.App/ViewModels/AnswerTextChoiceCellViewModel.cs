using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class AnswerTextChoiceCellViewModel : ViewModelBase
    {
        public string Text { get; }

        public AnswerTextChoiceCellViewModel(string text,IScreen hostScreen = null) : base(hostScreen)
        {
            Text = text;
        }
    }
}
