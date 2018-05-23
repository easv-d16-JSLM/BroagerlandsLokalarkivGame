using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerTextChoiceCellView
	{
		public AnswerTextChoiceCellView ()
		{
			InitializeComponent ();

		    this.WhenActivated(disposables =>
		    {
		        this.OneWayBind(ViewModel, x => x.Text, x => x.Text.Text).DisposeWith(disposables);
		    });
        }
	}
}