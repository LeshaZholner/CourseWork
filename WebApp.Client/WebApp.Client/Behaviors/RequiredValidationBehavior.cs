using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WebApp.Client.Behaviors
{
    public class RequiredValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = false;
            isValid = e.NewTextValue.Length != 0;
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.Salmon;
        }

        protected override void OnDetachingFrom(Entry binable)
        {
            binable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(binable);
        }
    }
}
