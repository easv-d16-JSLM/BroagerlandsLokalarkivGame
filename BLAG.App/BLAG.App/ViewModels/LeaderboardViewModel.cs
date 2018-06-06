using System.Collections.Generic;
using System.Linq;
using BLAG.Common.Models;
using ReactiveUI;

namespace BLAG.App.ViewModels
{
    public class LeaderboardViewModel : ViewModelBase
    {
        private readonly ReactiveList<string> _players;

        public LeaderboardViewModel(IEnumerable<Player> players)
        {
            _players = new ReactiveList<string>(players.Select(p => $"{p.Score.ToString().PadLeft(7)} {p.Name}"));
        }

        public IReadOnlyReactiveList<string> Players => _players;
    }
}