using System;
using System.Collections.Generic;
using System.Text;


using XF.Material.Forms.UI;

namespace Xamarin.Forms.BehaviorValidationPack.XFMaterial
{
    public class CompareValidationBehavior : Behavior<MaterialTextField>
    {

        private static Color DefaultColor = Color.Default;

        public static BindableProperty TextProperty =
            BindableProperty.Create<CompareValidationBehavior, string>(tc => tc.Text, string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }


        protected override void OnAttachedTo(MaterialTextField bindable)
        {
            bindable.Unfocused += Bindable_Unfocused;
            DefaultColor = bindable.TextColor;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(MaterialTextField bindable)
        {
            bindable.Unfocused -= Bindable_Unfocused;
            base.OnDetachingFrom(bindable);
        }

        void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            bool IsValid = false;
            IsValid = ((MaterialTextField)sender).ValidatedText() == Text;

            ((MaterialTextField)sender).TextColor = IsValid ? DefaultColor : Color.Red;
        }
    }
    
}
