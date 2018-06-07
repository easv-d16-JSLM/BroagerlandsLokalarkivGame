using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using BLAG.App.Helpers;
using BLAG.App.Services;
using ReactiveUI;
using Splat;

namespace BLAG.App.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private readonly ObservableAsPropertyHelper<bool> _isLoading;
        private readonly ReactiveCommand<Unit,Unit> _connect;
        private string _joinCode = "abcde";
        private string _url = "http://localhost:57851/gamesession";
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

            _connect = ReactiveCommand.CreateFromTask(async () =>
            {
                var service = await SignalRService.Initialize(Url);
                var player = await service.JoinGameSession(Username, JoinCode);

                if (player == null)
                {
                    await Error.Handle("The Join Code was invalid");
                    return;
                }

                var vm = new GameViewModel(service, player);
                HostScreen.Router.Navigate.Execute(vm).Subscribe();
            }, canConnect, RxApp.TaskpoolScheduler);

            _isLoading = this.WhenAnyObservable(x => x.Connect.IsExecuting)
                .StartWith(false)
                .ToProperty(this, x => x.IsLoading);
        }

        public ReactiveCommand<Unit,Unit> Connect => _connect;
        public Interaction<string, Unit> Error { get; } = new Interaction<string, Unit>(RxApp.MainThreadScheduler);


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