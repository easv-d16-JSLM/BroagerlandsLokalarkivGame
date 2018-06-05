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

            this.OneWayBind(ViewModel, x => x.Answers, x => x.AnswerList.ItemsSource);
            this.OneWayBind(ViewModel, x => x.Answers.Count, x => x.Title);
            this.Bind(ViewModel, x => x.SelectedAnswer, x => x.AnswerList.SelectedItem);
            this.OneWayBind(ViewModel, vm => vm.TimeLeft, v => v.TimeLeftLabel.Text);
        }
    }
}