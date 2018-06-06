using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BLAG.App.Helpers;
using BLAG.Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using ReactiveUI;
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

            CurrentAnswer = _client
                .Observe<Answer, DateTime>(nameof(CurrentAnswer))
                .Log(this, nameof(CurrentAnswer))
                .Publish();
            CurrentAnswer
                .Connect()
                .DisposeWith(_disposable);

            CurrentLeaderboard = _client
                .Observe<IList<Player>>(nameof(CurrentLeaderboard))
                .Log(this, nameof(CurrentLeaderboard))
                .Publish();
            CurrentLeaderboard
                .Connect()
                .DisposeWith(_disposable);

            PlayerCountUpdated = _client
                .Observe<int>(nameof(PlayerCountUpdated))
                .Log(this, nameof(PlayerCountUpdated))
                .Publish();
            PlayerCountUpdated
                .Connect().DisposeWith(_disposable);
        }

        public IConnectableObservable<Tuple<Answer, DateTime>> CurrentAnswer { get; }

        public IConnectableObservable<IList<Player>> CurrentLeaderboard { get; }

        public IConnectableObservable<int> PlayerCountUpdated { get; }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        [Obsolete]
        public Task StartGame(int currentSessionId)
        {
            return _client.InvokeAsync(nameof(StartGame), currentSessionId);
        }

        public static async Task<SignalRService> Initialize(string url)
        {
            var client = new HubConnectionBuilder().WithUrl(url).Build();
            var service = new SignalRService(client);
            await client.StartAsync();
            return service;
        }

        public Task<Player> JoinGameSession(string userName, string joinCode)
        {
            return _client.InvokeAsync<Player>(nameof(JoinGameSession), userName, joinCode);
        }

        public Task SubmitAnswer(PlayerAnswer answer)
        {
            return _client.InvokeAsync(nameof(SubmitAnswer), answer);
        }
    }
}