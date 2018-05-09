
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MvvmCross.Core.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Tests;
using NUnit.Framework;
using WineApp.Tests.Plumbing;

namespace JuiceIt.Tests
{
    [TestFixture]
    public class JuiceItTabsViewModelTests : MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher;

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            //Ioc.RegisterSingleton<IMvxStringToTypeParser>(new IMvxStringToTypeParser());
        }
    }
}
