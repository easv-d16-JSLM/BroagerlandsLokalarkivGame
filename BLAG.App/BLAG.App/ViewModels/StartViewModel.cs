using System;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private readonly ObservableAsPropertyHelper<bool> _isLoading;
        private string _joinCode = "abcde";
        private string _url;
        private string _username;

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
                //var service = await SignalRService.Initialize(Url);
                await Task.Delay(5000);
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