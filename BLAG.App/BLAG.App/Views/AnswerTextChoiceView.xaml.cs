using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using BLAG.App.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerTextChoiceView : ContentPageBase<AnswerTextChoiceViewModel>
	{
		public AnswerTextChoiceView ()
		{
			InitializeComponent ();

		    this.WhenActivated(disposables =>
		    {
		        ViewModel.SelectedAnswer = null;

		        this.OneWayBind(ViewModel, x => x.Answers, x => x.AnswerList.ItemsSource)
		            .DisposeWith(disposables);

		        this.OneWayBind(ViewModel, x => x.Answers.Count, x => x.Title)
		            .DisposeWith(disposables);

                this.Bind(ViewModel, x => x.SelectedAnswer, x => x.AnswerList.SelectedItem)
		            .DisposeWith(disposables);

		        //AnswerList
		        //    .Events()
		        //    .ItemAppearing
		        //    .Select((e) => e.Item as UpcomingMoviesCellViewModel)
		        //    .BindTo(this, x => x.ViewModel.ItemAppearing)
		        //    .DisposeWith(disposables);

		    });
        }
	}
}