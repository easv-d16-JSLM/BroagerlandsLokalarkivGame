using System;
using BLAG.App.Services;
using BLAG.App.ViewModels;
using BLAG.App.Views;
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

            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();

            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            //Locator.CurrentMutable.RegisterViewsForViewModels(typeof(App).Assembly);
            Locator.CurrentMutable.Register(() => new AnswerTextChoiceView(),
                typeof(IViewFor<AnswerTextChoiceViewModel>));
            Locator.CurrentMutable.Register(() => new AnswerTextChoiceCellView(),
                typeof(IViewFor<AnswerTextChoiceCellViewModel>));
            Locator.CurrentMutable.Register(() => new StartView(),
                typeof(IViewFor<StartViewModel>));

            

            Locator.CurrentMutable.RegisterConstant(new LoggingService {Level = LogLevel.Debug}, typeof(ILogger));


            Router
                .NavigateAndReset
                .Execute(new StartViewModel())
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