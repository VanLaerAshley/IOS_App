using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;


namespace JuiceIt.Shared
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Repository").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            //Mvx.LazyConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();
            RegisterAppStart<ViewModels.JuiceItTabsViewModel>();

        }
    }
}
