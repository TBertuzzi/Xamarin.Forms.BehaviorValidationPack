using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.BehaviorsPack
{
    public class CPFCNPJValidationBehavior : Behavior<Entry>
    {


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.Unfocused += Bindable_Unfocused;
            base.OnAttachedTo(bindable);
        }


        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Unfocused -= Bindable_Unfocused;
            base.OnDetachingFrom(bindable);
        }

        void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            bool IsValid = Validators.CpfCnpjValidator(((Entry)sender).Text);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
