using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WebApp.Client.Behaviors
{
    public class PasswordValidationBehavior : Behavior<Entry>
    {
        const string passwordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
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

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, passwordRegex));
            ((Entry)sender).BackgroundColor = IsValid ? Color.Default : Color.Salmon;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
