using System;
using System.Collections.Generic;
using System.Text;


namespace Xamarin.Forms.BehaviorValidationPack
{
    public class CEPValidationBehavior : Behavior<Entry>
    {
        private static Color DefaultColor = Color.Default;

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.Unfocused += Bindable_Unfocused;
            DefaultColor = bindable.TextColor;
            base.OnAttachedTo(bindable);
        }


        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Unfocused -= Bindable_Unfocused;
            base.OnDetachingFrom(bindable);
        }

        void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            bool IsValid = false;
            IsValid = Validators.CepValidator(((Entry)sender).ValidatedText());
            ((Entry)sender).TextColor = IsValid ? DefaultColor : Color.Red;

        }
    }
}
