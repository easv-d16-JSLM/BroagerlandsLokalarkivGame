using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
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

            this.WhenActivated(() =>
                new List<IDisposable>
                {
                    this.Bind(ViewModel, x => x.Url, x => x.Url.Text),
                    this.Bind(ViewModel, x => x.JoinCode, x => x.Code.Text),
                    this.Bind(ViewModel, x => x.Username, x => x.Name.Text),
                    this.BindCommand(ViewModel, x => x.Connect, x => x.Start),
                    Disposable.Create(() => this.Log().Debug("deactivated"))
                });
        }
    }
}