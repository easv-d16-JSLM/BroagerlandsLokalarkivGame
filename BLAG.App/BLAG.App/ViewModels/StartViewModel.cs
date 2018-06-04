using System;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BLAG.App.Helpers;
using BLAG.App.Services;
using DynamicData;
using ReactiveUI;
using Splat;

namespace BLAG.App.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private readonly ObservableAsPropertyHelper<bool> _isLoading;
        private string _joinCode = "abcde";
        private string _url ="http://localhost:57580/gamesession";
        private string _username = "testtest";

        public StartViewModel()
        {
            var canConnect = this.WhenAnyValue(x => x.Url, x => x.JoinCode, x => x.Username, (url, code, name) =>
                url != null &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute) &&
                code != null &&
                Regex.IsMatch(code, @"^[a-z]{5}$") &&
                name != null &&
                Regex.IsMatch(name, @"^[A-Za-z]{3,20}$"));

            Connect = ReactiveCommand.CreateFromTask(async () =>
            {
                SignalRService service;
                using (var x = this.Log().Measure("Establishing SignalR connection"))
                {
                    service = await SignalRService.Initialize(Url);
                }

                var success = await service.JoinGameSession(Username, JoinCode);
                var vm = new AnswerTextChoiceViewModel(Observable.Interval(TimeSpan.FromSeconds(1))
                    .Select(_ => DateTime.Now.ToString())
                    .Delay(TimeSpan.FromSeconds(2)).ToObservableChangeSet());
                HostScreen.Router.Navigate.Execute(vm).Subscribe();
            }, canConnect);

            Connect.ThrownExceptions.Subscribe(e => throw e);

            _isLoading = this.WhenAnyObservable(x => x.Connect.IsExecuting)
                .StartWith(false)
                .Log(this, "IsLoading")
                .ToProperty(this, x => x.IsLoading);
        }

        public ReactiveCommand Connect { get; }

        public bool IsLoading => _isLoading.Value;

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