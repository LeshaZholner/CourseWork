using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WebApp.Client.Behaviors
{
    public class PhonenumberValidationBehavior : Behavior<Entry>
    {
        const string emailRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public static readonly BindableProperty IsValidPropperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(RegisterPageValidationBehavior), false, BindingMode.OneWayToSource);
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidPropperty); }
            set { SetValue(IsValidPropperty, value); }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).BackgroundColor = IsValid ? Color.Default : Color.Salmon;
        }

        protected override void OnDetachingFrom(Entry binable)
        {
            binable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(binable);
        }
    }
}
