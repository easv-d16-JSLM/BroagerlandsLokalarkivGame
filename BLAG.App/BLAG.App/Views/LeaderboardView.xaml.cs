using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LeaderboardView
	{
		public LeaderboardView ()
		{
			InitializeComponent ();

		    this.OneWayBind(ViewModel, vm => vm.Players, v => v.playerList.ItemsSource);
		}
	}
}