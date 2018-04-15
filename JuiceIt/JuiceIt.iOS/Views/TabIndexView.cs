using Foundation;
using JuiceIt.Core.ViewModels;
using JuiceIt.iOS.TableViewSources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabIndexView : MvxTableViewController<TabIndexViewModel>
    {
        public TabIndexView (IntPtr handle) : base (handle)
        {
        }

        private RecipeViewSource _recipeViewSource;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            

            _recipeViewSource = new RecipeViewSource(this.TableView, IndexTableCell.Identifier, 125);
            this.TableView.Source = _recipeViewSource;
            this.TableView.ReloadData();
          
            MvxFluentBindingDescriptionSet<TabIndexView, TabIndexViewModel> set = new MvxFluentBindingDescriptionSet<TabIndexView, TabIndexViewModel>(this);
            set.Bind(_recipeViewSource).To(vm => vm.Recipes);
            set.Apply();
        }

    }
}