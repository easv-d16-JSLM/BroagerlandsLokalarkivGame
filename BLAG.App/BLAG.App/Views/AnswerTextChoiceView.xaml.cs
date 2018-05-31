using BLAG.App.ViewModels;
using ReactiveUI;
using Splat;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnswerTextChoiceView : ContentPageBase<AnswerTextChoiceViewModel>, IEnableLogger
    {
        public AnswerTextChoiceView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                ViewModel.SelectedAnswer = null;
                d(this.OneWayBind(ViewModel, x => x.Answers, x => x.AnswerList.ItemsSource));
                d(this.OneWayBind(ViewModel, x => x.Answers.Count, x => x.Title));
                d(this.Bind(ViewModel, x => x.SelectedAnswer, x => x.AnswerList.SelectedItem));
            });
        }
    }
}