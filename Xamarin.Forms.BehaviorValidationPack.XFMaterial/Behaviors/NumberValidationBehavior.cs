using System;
using System.Collections.Generic;
using System.Text;

using XF.Material.Forms.UI;

namespace Xamarin.Forms.BehaviorValidationPack.XFMaterial
{
    public class NumberValidationBehavior : Behavior<MaterialTextField>
    {
        private static Color DefaultColor = Color.Default;

        protected override void OnAttachedTo(MaterialTextField entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            DefaultColor = entry.TextColor;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(MaterialTextField entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;

            bool isValid = int.TryParse(args.NewTextValue, out result);

            ((MaterialTextField)sender).TextColor = isValid ? DefaultColor : Color.Red;
        }
    }
}
