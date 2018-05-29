using System;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using DynamicData;
using Humanizer;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private string _joinCode = "";
        private string _url = "";
        private string _username = "";

        public StartViewModel()
        {
            var canConnect = this.WhenAnyValue(x => x.Url, x => x.JoinCode, x => x.Username)
                .Select(tuple => Uri.IsWellFormedUriString(tuple.Item1, UriKind.Absolute) &&
                                 Regex.IsMatch(tuple.Item2, @"^[a-z]{5}$") &&
                                 Regex.IsMatch(tuple.Item3, @"^[A-Za-z]{3,20}$"));

            Connect = ReactiveCommand.Create(() =>
            {
                var vm = new AnswerTextChoiceViewModel(Observable.Interval(TimeSpan.FromSeconds(1))
                    .Select(_ => DateTime.Now.Humanize())
                    .Delay(TimeSpan.FromSeconds(2)).ToObservableChangeSet());
                vm.Activator.Activate();
                HostScreen.Router.Navigate.Execute(vm).Subscribe();
            }, canConnect);
        }

        public ReactiveCommand Connect { get; }

        public string JoinCode
        {
            get => _joinCode;
            set => this.RaiseAndSetIfChanged(ref _joinCode, value);
        }

        public string Url
        {
            get => _url;
            set => this.RaiseAndSetIfChanged(ref _url, value);
        }

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }
    }
}