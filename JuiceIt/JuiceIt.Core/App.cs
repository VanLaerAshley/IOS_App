using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace JuiceIt.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Repository").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.JuiceItTabsViewModel>();
        }
    }
}
