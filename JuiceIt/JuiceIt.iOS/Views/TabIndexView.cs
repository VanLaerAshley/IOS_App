using Foundation;
using JuiceIt.iOS.TableViewSources;
using JuiceIt.Shared.ViewModels;
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

        UISearchBar _searchBar;

        private RecipeViewSource _recipeViewSource;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            

            _recipeViewSource = new RecipeViewSource(this.TableView, IndexTableCell.Identifier, 125);
            this.TableView.Source = _recipeViewSource;
            this.TableView.ReloadData();

            ////BEGIN initialize searchbar 

            var searchController = new UISearchController(searchResultsController: null);

            searchController.SearchBar.SizeToFit();
            searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;

            NavigationItem.HidesSearchBarWhenScrolling = false;
            NavigationItem.SearchController = searchController;

            this.Title = "Search";

            _searchBar = searchController.SearchBar;
            _searchBar.SearchButtonClicked += SearchBar_SearchButtonClicked;
            _searchBar.TextChanged += SearchBarOnTextChanged;
            _searchBar.CancelButtonClicked += SearchBarOnCancelButtonClicked;

            // END initialize searchbar

            MvxFluentBindingDescriptionSet<TabIndexView, TabIndexViewModel> set = new MvxFluentBindingDescriptionSet<TabIndexView, TabIndexViewModel>(this);
            set.Bind(_recipeViewSource).To(vm => vm.FilteredRecepies);
            set.Bind(_recipeViewSource)
               .For(src => src.SelectionChangedCommand)
               .To(vm => vm.NavigateToDetailCommand);
            set.Apply();
        }

        private void SearchBarOnCancelButtonClicked(object sender, EventArgs eventArgs)
        {
            ((TabIndexViewModel)ViewModel).SearchJuices(string.Empty);
            BeginInvokeOnMainThread(() => _searchBar.ResignFirstResponder());
        }


        private void SearchBarOnTextChanged(object sender, UISearchBarTextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_searchBar.Text))
            {
                ((TabIndexViewModel)ViewModel).SearchJuices(string.Empty);

                BeginInvokeOnMainThread(() => _searchBar.ResignFirstResponder());
            }
            else
            {
                ((TabIndexViewModel)ViewModel).SearchJuices(_searchBar.Text);
            }
        }

        private void SearchBar_SearchButtonClicked(object sender, EventArgs e)
        {
            ((TabIndexViewModel)ViewModel).SearchJuices(_searchBar.Text);
            BeginInvokeOnMainThread(() => _searchBar.ResignFirstResponder());
        }

    }
}