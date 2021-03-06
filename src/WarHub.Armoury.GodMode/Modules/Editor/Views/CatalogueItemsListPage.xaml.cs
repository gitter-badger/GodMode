﻿// WarHub licenses this file to you under the MIT license.
// See LICENSE file in the project root for more information.

namespace WarHub.Armoury.GodMode.Modules.Editor.Views
{
    using System.Collections.Specialized;
    using System.Linq;
    using Xamarin.Forms;
    using FacadeGrouping = Bindables.IBindableGrouping<Models.IModelFacade>;
    using FacadeGroupings = System.Collections.Generic.IEnumerable<Bindables.IBindableGrouping<Models.IModelFacade>>;

    public partial class CatalogueItemsListPage : ContentPage
    {
        public static BindableProperty ElementsProperty = BindableProperty.Create(nameof(Elements),
            typeof(FacadeGroupings), typeof(CatalogueItemsListPage),
            new FacadeGrouping[0], propertyChanged: OnElementsPropertyChanged);

        public static BindableProperty ElementsCountProperty = BindableProperty.Create(nameof(ElementsCount),
            typeof(int), typeof(CatalogueItemsListPage), default(int));

        public CatalogueItemsListPage()
        {
            InitializeComponent();
            SetBinding(ElementsProperty,
                new Binding(nameof(ItemsListView.ItemsSource), source: ItemsListView));
        }

        public FacadeGroupings Elements
        {
            get { return (FacadeGroupings) GetValue(ElementsProperty); }
            set { SetValue(ElementsProperty, value); }
        }

        public int ElementsCount
        {
            get { return (int) GetValue(ElementsCountProperty); }
            set { SetValue(ElementsCountProperty, value); }
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsListView.Filter(e.NewTextValue);
        }

        private static void OnElementsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CatalogueItemsListPage) bindable).OnElementsPropertyChanged(oldValue, newValue);
        }

        private void OnElementsPropertyChanged(object oldValue,
            object newValue)
        {
            if (Equals(oldValue, newValue))
            {
                return;
            }
            Unsubscribe((FacadeGroupings) oldValue);
            Subscribe((FacadeGroupings) newValue);
            UpdateElementsCount();
        }

        private void Unsubscribe(FacadeGroupings oldValue)
        {
            if (oldValue == null)
            {
                return;
            }
            var newNotifyCollectionChanged = oldValue as INotifyCollectionChanged;
            if (newNotifyCollectionChanged != null)
            {
                newNotifyCollectionChanged.CollectionChanged -= OnElementsCollectionChanged;
            }
            foreach (var grouping in oldValue)
            {
                grouping.CollectionChanged -= OnGroupingCollectionChanged;
            }
        }

        private void Subscribe(FacadeGroupings newValue)
        {
            if (newValue == null)
            {
                return;
            }
            var newNotifyCollectionChanged = newValue as INotifyCollectionChanged;
            if (newNotifyCollectionChanged != null)
            {
                newNotifyCollectionChanged.CollectionChanged += OnElementsCollectionChanged;
            }
            foreach (var grouping in newValue)
            {
                grouping.CollectionChanged += OnGroupingCollectionChanged;
            }
        }

        private void OnGroupingCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateElementsCount();
        }

        private void OnElementsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                Unsubscribe(e.OldItems.Cast<FacadeGrouping>());
            }
            if (e.NewItems != null)
            {
                Subscribe(e.NewItems.Cast<FacadeGrouping>());
            }
            UpdateElementsCount();
        }

        private void UpdateElementsCount()
        {
            ElementsCount = Elements?.Aggregate(0, (sum, grouping) => sum + grouping.Count()) ?? 0;
        }
    }
}
