using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.BehaviorsPack
{
    public class DateValidationBehavior : Behavior<DatePicker>
    {
        protected override void OnAttachedTo(DatePicker datepicker)
        {
            datepicker.DateSelected += Datepicker_DateSelected;
            base.OnAttachedTo(datepicker);
        }

        private void Datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {

            bool isValid = Validators.DateValidator(e.NewDate);
           ((DatePicker)sender).BackgroundColor = isValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(DatePicker datepicker)
        {
            datepicker.DateSelected -= Datepicker_DateSelected;
            base.OnDetachingFrom(datepicker);
        }


    }
}
