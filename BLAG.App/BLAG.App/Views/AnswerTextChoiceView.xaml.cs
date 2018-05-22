using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAG.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BLAG.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerTextChoiceView : ContentPageBase<AnswerTextChoiceViewModel>
	{
		public AnswerTextChoiceView ()
		{
			InitializeComponent ();
		}
	}
}