using System.Reactive.Disposables;
using BLAG.App.ViewModels;
using ReactiveUI;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartView : ContentPageBase<StartViewModel>
    {
        public StartView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.Bind(ViewModel, x => x.Url, x => x.Url.Text).DisposeWith(d);
                this.Bind(ViewModel, x => x.JoinCode, x => x.Code.Text).DisposeWith(d);
                this.Bind(ViewModel, x => x.Username, x => x.Name.Text).DisposeWith(d);
                //does not bind?

                this.BindCommand(ViewModel, x => x.Connect, x => x.Start).DisposeWith(d);
            });
        }
    }
}