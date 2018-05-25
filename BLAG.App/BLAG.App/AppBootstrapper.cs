using System;
using System.Linq;
using System.Reactive.Linq;
using BLAG.App.ViewModels;
using BLAG.App.Views;
using DynamicData;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace BLAG.App
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new AnswerTextChoiceView(),
                typeof(IViewFor<AnswerTextChoiceViewModel>));
            Locator.CurrentMutable.Register(() => new AnswerTextChoiceCellView(),
                typeof(IViewFor<AnswerTextChoiceCellViewModel>));
            //Locator.CurrentMutable.Register(() => new MovieDetailView(), typeof(IViewFor<MovieDetailViewModel>));

            //Locator.CurrentMutable.Register(() => new Cache(), typeof(ICache<,>));
            //Locator.CurrentMutable.Register(() => new ApiService(), typeof(IApiService));


            Router
                .NavigateAndReset
                .Execute(new AnswerTextChoiceViewModel(Observable.Interval(TimeSpan.FromSeconds(2)).Select(i =>
                    Enumerable.Repeat(
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus fermentum tincidunt urna, et laoreet odio tempus id. Pellentesque turpis nisi, fringilla quis libero ac, egestas placerat est. Phasellus sagittis ligula nec nulla convallis gravida. Etiam a quam at lorem commodo fermentum. Donec ipsum metus, interdum in libero at, viverra ultricies est.",
                        Convert.ToInt32(i))).ToObservableChangeSet()))
                .Subscribe();
        }

        public RoutingState Router { get; protected set; }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrappScreen.
            return new RoutedViewHost();
        }
    }
}