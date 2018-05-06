
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

        [TestCase]
        public void wines_property_return_all_wines()
        {
            var recipes = new List<Recipe>();
            recipes.Add(new Recipe() { Id = "1", Appelation = "Appel1", Name = "wine1", Price = "100", Region = "Region1", Year = "2018" });
            recipes.Add(new Recipe() { Id = "2", Appelation = "Appel2", Name = "wine2", Price = "100", Region = "Region2", Year = "2018" });

            var mockWineService = new Mock<>();
            mockWineService.Setup(ws => ws.GetWines()).Returns(Task.FromResult(Recipe));
            var vm = new JuiceItTabsViewModel(mockWineService.Object, null);

            var allWines = vm.Wines;

            Assert.IsNotNull(allWines);
            Assert.IsTrue(allWines.Count == 2);

        }
    }
}
