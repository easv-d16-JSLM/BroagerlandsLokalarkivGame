using System.Reactive;
using BLAG.App.ViewModels;
using ReactiveUI;
using Splat;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartView : ContentPageBase<StartViewModel>, IEnableLogger
    {
        public StartView()
        {
            InitializeComponent();

            this.Bind(ViewModel, x => x.Url, x => x.Url.Text);
            this.Bind(ViewModel, x => x.JoinCode, x => x.Code.Text);
            this.Bind(ViewModel, x => x.Username, x => x.Name.Text);
            this.BindCommand(ViewModel, x => x.Connect, x => x.Start);
            this.OneWayBind(ViewModel, x => x.IsLoading, v => v.Start.Text, b => b ? "Connecting...": "Connect");

            this.WhenActivated(d =>
            {
                ViewModel.Error.RegisterHandler(async interaction =>
                {
                    await DisplayAlert("Error", interaction.Input, "OK");
                    interaction.SetOutput(Unit.Default);
                });
            });
        }
    }
}