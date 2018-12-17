using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Xamarin.Forms.BehaviorValidationPack
{
    //at least 8 characters
    //at least 1 numeric character
    //at least 1 lowercase letter
    //at least 1 uppercase letter
    //at least 1 special character
    public class PasswordValidationBehavior : Behavior<Entry>
    {
        const string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.Unfocused += Bindable_Unfocused;
            base.OnAttachedTo(bindable);
        }

        void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            bool IsValid = false;
            IsValid = Validators.PasswordValidator(((Entry)sender).ValidatedText());
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Unfocused -= Bindable_Unfocused;
            base.OnDetachingFrom(bindable);
        }
    }
}
