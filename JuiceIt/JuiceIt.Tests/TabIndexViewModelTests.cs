
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using JuiceIt.Shared.ViewModels;
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
    public class TabIndexViewModelTests : MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher;

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }

        [Test]
        public void GetAllRecipes()
        {
            var recipe = new List<Recipe>();
            recipe.Add(new Recipe() { id = 1, name = "First Juice", picture = "picture Url 1", thumbnail = "thumbnail Url 1", description = "First description. It describes how to make your Juice." });
            recipe.Add(new Recipe() { id = 2, name = "Second Juice", picture = "picture Url 2", thumbnail = "thumbnail Url 2", description = "Second description. It describes how to make your Juice." });

            var mockStationService = new Mock<IRecipeService>();
            mockStationService.Setup(rec => rec.GetRecipes()).Returns(Task.FromResult(recipe));

            var vm = new TabIndexViewModel(mockStationService.Object, null);

            var AllRecipes = vm.Recipes;

            Assert.IsNotNull(AllRecipes);
            Assert.IsTrue(AllRecipes.Count == 2);
        }
    }
}
