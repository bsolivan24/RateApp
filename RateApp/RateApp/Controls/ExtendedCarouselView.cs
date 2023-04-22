using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RateApp.Controls
{
    public class ExtendedCarouselView : CarouselView
    {
        public ExtendedCarouselView() : base()
        {

        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(ExtendedCarouselView), null, BindingMode.TwoWay, propertyChanged: SelectedItemChanged);

        public object SelectedItem
        {
            get { return (object)this.GetValue(SelectedItemProperty); }
            set { this.SetValue(SelectedItemProperty, value); }
        }

        protected override void OnPositionChanged(PositionChangedEventArgs args)
        {
            base.OnPositionChanged(args);

            SelectedItem = CurrentItem;
        }

        private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ecv = (ExtendedCarouselView)bindable;

            var position = ecv.ItemsSource.Cast<object>().IndexOf(ecv.SelectedItem);
            if(position >= 0)
            {
                ecv.Position = position;
            }
        }
    }
}
