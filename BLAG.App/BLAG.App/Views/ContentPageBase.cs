using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI.XamForms;

namespace BLAG.App.Views
{
    public class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : class
    {
    }
}
