using System;
using System.Collections.Generic;
using System.Text;

using XF.Material.Forms.UI;

namespace Xamarin.Forms.BehaviorValidationPack.XFMaterial
{
    public class MaxLengthValidationBehavior : Behavior<MaterialTextField>
    {
        public static readonly BindableProperty MaxLengthProperty = 
            BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidationBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(MaterialTextField bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (e.NewTextValue.Length >= MaxLength)
                ((MaterialTextField)sender).Text = e.NewTextValue.Substring(0, MaxLength);

        }

        protected override void OnDetachingFrom(MaterialTextField bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;

        }
    }
}
