using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.BehaviorsPack
{
    public class MaxLengthValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty = 
            BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidationBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (e.NewTextValue.Length >= MaxLength)
                ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);

        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;

        }
    }
}
