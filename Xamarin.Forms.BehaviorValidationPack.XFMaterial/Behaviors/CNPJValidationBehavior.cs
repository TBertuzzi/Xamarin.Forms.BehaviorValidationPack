using System;
using System.Collections.Generic;
using System.Text;

using XF.Material.Forms.UI;

namespace Xamarin.Forms.BehaviorValidationPack.XFMaterial
{
    public class CNPJValidationBehavior : Behavior<MaterialTextField>
    {

        private static Color DefaultColor = Color.Default;

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
            bool IsValid = Validators.CnpjValidator(((MaterialTextField)sender).ValidatedText());
            ((Entry)sender).TextColor = IsValid ? DefaultColor : Color.Red;
        }
    }
}
