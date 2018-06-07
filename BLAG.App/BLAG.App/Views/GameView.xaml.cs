using ReactiveUI;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView
    {
        public GameView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.PlayerCount, v => v.PlayersLabel.Text);
            this.OneWayBind(ViewModel, vm => vm.CurrentContent, v => v.Content.ViewModel);
        }
    }
}