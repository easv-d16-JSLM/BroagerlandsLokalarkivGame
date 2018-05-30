using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BLAG.App.Helpers;
using BLAG.Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Splat;

namespace BLAG.App.Services
{
    public class SignalRService : IEnableLogger, IDisposable
    {
        private readonly HubConnection _client;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private SignalRService(HubConnection client)
        {
            _client = client;
            
            GameStarted = _client.Observe(nameof(GameStarted)).Publish();
            GameStarted.Connect().DisposeWith(_disposable);

            PlayerCountUpdated = _client.Observe<int>(nameof(PlayerCountUpdated)).Publish();
            PlayerCountUpdated.Connect().DisposeWith(_disposable);
        }

        //Client method that server calls. Has to be defined beforehand, other parts of app can subscribe.
        public IConnectableObservable<Unit> GameStarted { get; }
        public IConnectableObservable<int> PlayerCountUpdated { get; }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        public static async Task<SignalRService> Initialize(string url)
        {
            var client = new HubConnectionBuilder().WithUrl(url).Build();
            var service = new SignalRService(client);
            await client.StartAsync();
            return service;
        }

        //Server method definition. Signature has to be kept in sync with server hub manually.
        public Task<bool> JoinGameSession(string userName, string joinCode)
        {
            return _client.InvokeAsync<bool>(nameof(JoinGameSession), userName, joinCode);
        }


        public Task SubmitAnswer(PlayerAnswer answer)
        {
            return _client.InvokeAsync(nameof(SubmitAnswer), answer);
        }
    }
}