using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.BehaviorValidationPack
{
    public class CPFValidationBehavior : Behavior<Entry>
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
            bool IsValid = Validators.CpfValidator(((Entry)sender).Text);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
